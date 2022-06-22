namespace CigarShop_maui;

public partial class MainPage : ContentPage
{

	public MainPage(CigarViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		
	}
}

