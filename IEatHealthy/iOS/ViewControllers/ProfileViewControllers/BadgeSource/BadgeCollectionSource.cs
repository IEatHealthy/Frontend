using System;
using Foundation;
using UIKit;
using System.Collections.Generic;


namespace IEatHealthy.iOS
{
    public class BadgeCollectionSource : UICollectionViewSource
    {
        public BadgeCollectionSource()
        {
            Rows = new List<BadgeElement>();
        }

        public List<BadgeElement> Rows { get; private set; }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Rows.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var badgeCell = (BadgeCell)collectionView.DequeueReusableCell(BadgeCell.BadgeID, indexPath);

            BadgeElement row = Rows[indexPath.Row];
            badgeCell.UpdateRow(row);
            return badgeCell;
        }
    }

    public class BadgeElement
    {
        public BadgeElement(UIImage image, string title, string description)
        {
            Image = image;
            Title = title;
            Description = description;
        }

        public UIImage Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
