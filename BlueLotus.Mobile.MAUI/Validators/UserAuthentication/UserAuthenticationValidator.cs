using BlueLotus.Mobile.MAUI.ViewModels.UserAuthentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus.Mobile.MAUI.Validators.UserAuthentication
{
    public class UserAuthenticationValidator : AbstractValidator<UserLoginModel>
    {
        public UserAuthenticationValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username Cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Cannot be empty");
        }

        private bool BeAValidPostcode(string postcode)
        {
            // custom postcode validating logic goes here
            return false;
        }
    }
}
