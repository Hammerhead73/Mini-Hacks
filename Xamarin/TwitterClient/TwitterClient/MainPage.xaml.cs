using System;
using System.Collections.Generic;
using TwitterAPI;
using TwitterAPI.Abstractions;
using Xamarin.Forms;

namespace TwitterClient
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();
			TweetsSearchBar.Text = "Cellenza";
			UserSearchBar.Text = "Msft";
			RefreshSearch(this, EventArgs.Empty);
			RefreshUsers(this, EventArgs.Empty);
		}

		private async void RefreshSearch(object sender, EventArgs e)
		{
			TweetsList.IsRefreshing = true;
			TweetsList.ItemsSource = await TwitterAPI.TwitterApi.Instance.SearchTweetsAsync(TweetsSearchBar.Text, 30, ResultType.Recent);
			TweetsList.IsRefreshing = false;
		}

		private async void RefreshUsers(object sender, EventArgs e)
		{
			UsersList.IsRefreshing = true;
			UsersList.ItemsSource = await TwitterAPI.TwitterApi.Instance.SearchUserAsync(UserSearchBar.Text, 30);
			UsersList.IsRefreshing = false;
		}
    }
}
