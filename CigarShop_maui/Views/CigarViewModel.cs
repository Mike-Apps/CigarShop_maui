using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using CigarShop_maui.xamlpages;
using Microsoft.Maui.Networking;


namespace CigarShop_maui.Views
{
    public partial class CigarViewModel : BaseViewModel
    {
        public ObservableCollection<CigarModel> cigarmodel_observablecollection{ get; } = new();
        CigarServices cigarServices;


        public CigarViewModel(CigarServices cigarServices)
        {
            //Title = "Cigar Shop";
            this.cigarServices = cigarServices;

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
                //if (connectivity.NetworkAccess != NetworkAccess.Internet)
                //{
                //    await Shell.Current.DisplayAlert("No connectivity!",
                //        $"Please check internet and try again.", "OK");
                //    return;
                //}

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

        //test pages

        //[ICommand]
        //async Task GoToTestPage()
        //{


        //    await Shell.Current.GoToAsync(nameof(TestPage));
        
  
        //}
    }
}
