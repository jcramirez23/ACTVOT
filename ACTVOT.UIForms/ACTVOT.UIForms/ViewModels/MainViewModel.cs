
namespace ACTVOT.UIForms.ViewModels
{
   public class MainViewModel
    {

        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }

        public ActvotsViewModel Actvots { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
    }
}
