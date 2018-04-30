using System;

namespace IEatHealthy
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            if (item != null)
            {
                Title = item.name;
                Item = item;





            }
        }
    }
}
