namespace CigarShop_maui.xamlpages;

public partial class Details : ContentPage
{
	public Details(CigarDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}