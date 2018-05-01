using System;
using Foundation;
using UIKit;
using System.Collections.Generic;


namespace IEatHealthy.iOS
{
    public class CreationCollectionSource : UICollectionViewSource
    {
        public CreationCollectionSource()
        {
            Rows = new List<CreationElement>();
        }

        public List<CreationElement> Rows { get; private set; }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Rows.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var creationCell = (CreationCell)collectionView.DequeueReusableCell(CreationCell.CreationID, indexPath);

            CreationElement row = Rows[indexPath.Row];
            creationCell.UpdateRow(row);
            return creationCell;
        }
    }

    public class CreationElement
    {
        public CreationElement(UIImage image, string title)
        {
            Image = image;
            Title = title;
        }

        public UIImage Image { get; set; }
        public string Title { get; set; }
    }
}