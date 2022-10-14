using BlueLotus.Mobile.MAUI.Context;
using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using BlueLotus360.Core.Domain.Entity.Base;

namespace BlueLotus.Mobile.MAUI.Pages;

public partial class CompanySelectionPage : ContentPage
{
	public CompanySelectionPage(CompanySelectionModel m)
	{
		CompanySelectionModel model = m;
		BindingContext = model;
		InitializeComponent();
		model.ReadCompanies();

    }
}