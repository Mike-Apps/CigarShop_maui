

namespace CigarShop_maui.Views
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        // [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;

    }
}
