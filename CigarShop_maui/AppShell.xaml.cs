﻿namespace CigarShop_maui;
using CigarShop_maui.xamlpages;


public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Details), typeof(Details));
        
	}
}