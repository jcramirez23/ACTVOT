
namespace ACTVOT.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {

        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email",
                    "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password",
                    "Accept");
                return;
            }

            if (!this.Email.Equals("jcamilor.454@gmail.com") || !this.Email.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "OK",
                    "User or password wrong",
                    "Accept");

            }
            await Application.Current.MainPage.DisplayAlert(
                    "Ok",
                    "Fuck yeahh¡¡¡",
                    "Accept");

        }
    }
}
