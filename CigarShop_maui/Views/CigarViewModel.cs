using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using CigarShop_maui.xamlpages;


namespace CigarShop_maui.Views
{
    public partial class CigarViewModel : BaseViewModel
    {
        CigarServices cigarServices;
        public CigarViewModel(CigarServices cigarServices)
        {
            //Title = "Cigar Shop";
            this.cigarServices = cigarServices;
        }

        public ObservableCollection<CigarModel> cigarmodel { get; } = new();



        [ICommand]
        async Task GetCigarsAsync()
        {
            //if (IsBusy)
            //{
            //    return;
            //}

            try
            {
                //IsBusy = true;
                var cigars = await cigarServices.GetCigars();

                if (cigarmodel.Count != 0)
                {
                    cigarmodel.Clear();
                }
                
                foreach (var cigar in cigars)
                {
                    cigarmodel.Add(cigar);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                //IsBusy = false;
              
               
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
