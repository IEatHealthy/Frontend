using Foundation;
using System;
using System.Collections;
using UIKit;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IEatHealthy.iOS
{
    public partial class SelectIngredient : UITableViewController
    {
        // Recipe
        public ItemDetailViewModel ViewModel { get; set; }

        // Array for Table
        ArrayList tableItems = new ArrayList();

        // Cell Identifier
        protected string cellIdentifer = "TableCell";

        public SelectIngredient(IntPtr handle) : base(handle)
        {

        }


        // Initial Load into Memory
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Gets ingredient string into local string
            List<IngredientItem> Items = ViewModel.Item.ingredients;

            Ingredient placeholder = new Ingredient();

            // for each ingredient place into the tableitems.
            foreach (IngredientItem ingre in Items)
            {
                placeholder.Name = ingre.desc;
                tableItems.Add(placeholder.Name);
            }
        }

        // Refreshes the page incase of changes to the JSON file
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            TableView.ReloadData();
        }

        // Number of rows should be the amount of items in the tableItems array.
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return tableItems.Count;
        }

        // Display the tableItems
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifer);

            if (cell == null)
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifer);

            cell.TextLabel.Text = (string)tableItems[indexPath.Row];


            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            // Checkmarks ingredient when selected, deselects when selected again.
            UITableViewCell cell = tableView.CellAt(indexPath);
            if (cell.Accessory == UITableViewCellAccessory.None)
                cell.Accessory = UITableViewCellAccessory.Checkmark;
            else
                cell.Accessory = UITableViewCellAccessory.None;
            tableView.DeselectRow(indexPath, true);
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, Foundation.NSIndexPath indexPath)
        {
            switch (editingStyle)
            {
                case UITableViewCellEditingStyle.Delete:
                    tableItems.RemoveAt(indexPath.Row);
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                    break;
                case UITableViewCellEditingStyle.None:
                    break;
            }
        }

        partial void Add_Activated(UIBarButtonItem sender)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "myshoppingcart.json");

            // if JSON file does not exist, create a new one.
            if (!File.Exists(filename))
            {
                List<Ingredient> ingredients = new List<Ingredient> { };
                foreach (Ingredient ingre in tableItems)
                {
                    ingredients.Add(ingre);
                }
                File.WriteAllText(@filename, JsonConvert.SerializeObject(ingredients));
                tableItems.Clear();
            }
            // if JSON file does exist, deserializes the objects, adds ingredients to table and inputs them into the tableItems array
            else
            {
                List<Ingredient> ingredients = JsonConvert.DeserializeObject<List<Ingredient>>(File.ReadAllText(@filename));
                foreach (string name in tableItems)
                {
                    Ingredient ingre = new Ingredient();
                    ingre.Name = name;
                    ingredients.Add(ingre);
                }
                File.WriteAllText(@filename, JsonConvert.SerializeObject(ingredients));
                tableItems.Clear();
                TableView.ReloadData();
            }

        }
    }
}