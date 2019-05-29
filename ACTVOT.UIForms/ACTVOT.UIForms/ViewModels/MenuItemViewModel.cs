
namespace ACTVOT.UIForms.ViewModels
{
    using ACTVOT.common.Models;
    using ACTVOT.UIForms.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MenuItemViewModel : common.Models.Menu
    {
        public ICommand SelectMenuCommand { get { return new RelayCommand(this.SelectMenu); } }

        private async void SelectMenu()
        {
            App.Master.IsPresented = false;
            var mainViewModel = MainViewModel.GetInstance();

            switch (this.PageName)
            {
                case "AboutPage":
                    await App.Navigator.PushAsync(new AboutPage());
                    break;
                case "SetupPage":
                    await App.Navigator.PushAsync(new SetupPage());
                    break;
                default:
                    MainViewModel.GetInstance().Login = new LoginViewModel();
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                    break;
            }
        }
    }
}
