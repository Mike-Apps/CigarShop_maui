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

        [ICommand]
        async Task GetCigarsAsync()
        {
            try
            {
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
            }
        }


        [ICommand]
        async Task GoToDetails(CigarModel cigarModel)
        {


            if (cigarModel is null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(Details), true, new Dictionary<string, object>
        {
            {"CigarModel", cigarModel }
        });


        }
    }
}
