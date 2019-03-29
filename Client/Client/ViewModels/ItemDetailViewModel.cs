using Core;
using System.ComponentModel;

namespace Client.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
