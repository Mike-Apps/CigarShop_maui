namespace CigarShop_maui;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(CigarDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}