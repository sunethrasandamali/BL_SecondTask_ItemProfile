using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class CompanySelectionPage : ContentPage
{
	public CompanySelectionPage()
	{
		CompanySelectionModel model = new CompanySelectionModel();
		model.Companies.Add(new Company() { CompanyCode = "BL", CompanyName = "Blue Lotus 360" });
		BindingContext = model;
		InitializeComponent();
		
	}
}