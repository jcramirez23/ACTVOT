
namespace ACTVOT.UIForms.ViewModels
{

    using common.Models;
    using common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ActvotsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<ActVote> actvots;

        public ObservableCollection<ActVote> Actvots
        {
            get { return this.actvots; }
            set { this.SetValue(ref this.actvots, value); }
        }


        public ActvotsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadActVotes();
        }

        private async void LoadActVotes()
        {
            var response = await this.apiService.GetListAsync<ActVote>(
                "https://myactivityvote.azurewebsites.net",
                "/api",
                "/ActVotes"
                );
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            var MyActvote = (List<ActVote>)response.Result;
            this.Actvots  = new ObservableCollection<ActVote>(MyActvote);
        }
    }
}
    