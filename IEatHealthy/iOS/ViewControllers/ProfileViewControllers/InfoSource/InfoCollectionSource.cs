using System;
using Foundation;
using UIKit;
using System.Collections.Generic;


namespace IEatHealthy.iOS
{
    public class InfoCollectionSource : UICollectionViewSource
    {
        public InfoCollectionSource()
        {
            Rows = new List<InfoElement>();
        }

        public List<InfoElement> Rows { get; private set; }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Rows.Count;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var infoCell = (InfoCell)collectionView.DequeueReusableCell(InfoCell.InfoID, indexPath);

            InfoElement row = Rows[indexPath.Row];
            infoCell.UpdateRow(row);
            return infoCell;
        }
    }

    public class InfoElement
    {
        public InfoElement(UIImage image, string title)
        {
            Image = image;
            Title = title;
        }

        public UIImage Image { get; set; }
        public string Title { get; set; }
    }
}