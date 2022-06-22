

namespace CigarShop_maui.Views
{
    [QueryProperty(nameof(CigarModel), "CigarModel")]
    public partial class CigarDetailsViewModel : BaseViewModel
    {
        
        public CigarDetailsViewModel()
        {
            
        }

        [ObservableProperty]
        CigarModel cigarModel;

        //Optional Back Button

        [ICommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
            //await Shell.Current.GoToAsync("../.."); goes back two pages
            //await Shell.Current.GoToAsync("../MainPage"); goes back the mainpage

        }

        [ICommand]
        async Task OpenMap()
        {
            try
            {
                await Map.OpenAsync(CigarModel.Latitude, CigarModel.Longitude, new MapLaunchOptions { Name = CigarModel.Name, NavigationMode = NavigationMode.None });
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Somethign is wrong with Maps", "try to enable GPS ", "OK");
            }
        }
    }
}
