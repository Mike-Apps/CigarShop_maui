
namespace CigarShop_maui.Views
{
    public partial class CigarViewModel : BaseViewModel
    {
        public ObservableCollection<CigarModel> cigarmodel_observablecollection{ get; } = new();
        CigarServices cigarServices;

        IConnectivity connectivity;
        IGeolocation geolocation;
        IMap map;
        public CigarViewModel(CigarServices cigarServices, IConnectivity connectivity, IGeolocation geolocation, IMap map)
        {
            //Title = "Cigar Shop";
            this.cigarServices = cigarServices;
            this.connectivity = connectivity;
            this.geolocation = geolocation;
            this.map = map;
        }

        [ObservableProperty]
        bool isRefreshing;

        [ICommand]
        async Task GetCigarsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                IsBusy = true;
                var cigars = await cigarServices.GetCigars();

                if (cigarmodel_observablecollection.Count != 0)
                {
                    cigarmodel_observablecollection.Clear();
                }

                foreach (var cigar in cigars)
                {
                    cigarmodel_observablecollection.Add(cigar);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }


        [ICommand]
        async Task GoToDetails(CigarModel cigarModel)
        {
            if (cigarModel == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            {"CigarModel", cigarModel }
        });
        }


        [ICommand]
        async Task FindClosestCigar()
        {
            if (IsBusy || cigarmodel_observablecollection.Count == 0)
            {
                return;
            }
            else
            {
                try
                {
                    // Get cached location, else get real location.
                    Location location = await geolocation.GetLastKnownLocationAsync();
                    if (location == null)
                    {
                        location = await geolocation.GetLocationAsync(new GeolocationRequest
                        {
                            DesiredAccuracy = GeolocationAccuracy.Medium, 
                            Timeout = TimeSpan.FromSeconds(30)
                        });
                    }

                    // Find closest Cigar to you
                    

                    CigarModel first = cigarmodel_observablecollection.OrderBy(m => location.CalculateDistance(new Location(m.Latitude, m.Longitude), DistanceUnits.Miles)).FirstOrDefault();

                    await Shell.Current.DisplayAlert("", first.Name + " " + first.Location, "OK");





                    //how to find a targt point on the map...

                   

                       

                    // how to calculate distance between two points...
                    Location currentlocation = new Location(first.Latitude, first.Longitude);
                    Location targetlocation = new Location();
                    double distance = currentlocation.CalculateDistance(targetlocation, DistanceUnits.Miles);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Unable to query location: {ex.Message}");
                    await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
                }
            }
        }

    }
}
