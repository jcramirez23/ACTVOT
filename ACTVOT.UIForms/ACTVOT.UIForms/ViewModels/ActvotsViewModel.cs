
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
        private bool isRefreshing;

        public ObservableCollection<ActVote> Actvots
        {
            get { return this.actvots; }
            set { this.SetValue(ref this.actvots, value); }
        }
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }


        public ActvotsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadActVotes();
        }

        private async void LoadActVotes()
        {
            this.IsRefreshing = true;
            var response = await this.apiService.GetListAsync<ActVote>(
                "https://myactivityvote.azurewebsites.net",
                "/api",
                "/ActVotes"
                );
            this.IsRefreshing = false;
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }
            var MyActvote = (List<ActVote>)response.Result;
            this.Actvots = new ObservableCollection<ActVote>(MyActvote);
        }
    }
}
