namespace CigarShop_maui;



public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Routing.RegisterRoute(nameof(Details), typeof(Details));

        //Testpage

        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage)) ;

    }
}
