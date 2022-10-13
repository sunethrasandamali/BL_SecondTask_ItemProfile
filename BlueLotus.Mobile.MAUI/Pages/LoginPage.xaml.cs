using BlueLotus.Mobile.MAUI.Extensions;
using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using Microsoft.Extensions.Configuration;

namespace BlueLotus.Mobile.MAUI.Pages;
public partial class LoginPage : ContentPage
{
    private readonly IConfiguration configuration;

    public LoginPage(UserLoginModel loginModel)
    {
        configuration = MAUIConfiguration.configuration;
        var appInfo = configuration.GetRequiredSection("AppInfo:ApplicaionName");
        UserLoginModel model = loginModel;
        BindingContext = model;
        model.ApplicationName = appInfo.Value;
        InitializeComponent();

    }

    private void Button_Clicked(object sender, EventArgs e)
    {


    }
}