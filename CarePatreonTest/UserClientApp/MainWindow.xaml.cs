using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace UserClientApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HubConnection notificationHubConnection;
        private const string accessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkaGF2ZWRheWFvIiwianRpIjoidXNlcjAwMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJkaGF2ZWRheWFvIiwiVXNlcklkIjoidXNlcjAwMSIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6InN0YW5kYXJkIiwiZXhwIjoxNjcwNjQ1NDY4LCJpc3MiOiJqd3QiLCJhdWQiOiJqd3QifQ.Sq4Awjk7BDT20DODQNaJNGxfZBxHuW9UVorBU1woDKI";

        public MainWindow()
        {
            InitializeComponent();

            notificationHubConnection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7074/notificationHub", option =>
                {
                    option.AccessTokenProvider = () =>
                    {
                        return Task.FromResult(accessToken);
                    };
                })
                .WithAutomaticReconnect()
                .Build();
        }

        private async void connectButton_Click(object sender, RoutedEventArgs e)
        {
            notificationHubConnection.On<object>("ClientCreated", (message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"Client Created: {message}";
                    messagesList.Items.Add(newMessage);
                });
            });

            notificationHubConnection.On<object>("ClientUpdated", (message) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    var newMessage = $"Client Updated: {message}";
                    messagesList.Items.Add(newMessage);
                });
            });

            try
            {
                await notificationHubConnection.StartAsync();
                messagesList.Items.Add("Connection started");
                connectButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                messagesList.Items.Add(ex.Message);
            }
        }
    }
}
