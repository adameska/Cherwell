using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
//using Trebuchet.API;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Cherwell_Unofficial
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();

            //if we have username and password info then login automatically, otherwise fill in last username
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            //Try and connect to cherwell servers.

            if (loginAutomatically.IsChecked ?? false)
            {
                //todo store username/password info
            }
            else
            {
                //todo delete any saved password info so we stop logging in automatically
            }
        }

        private async void server_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var serverDialog = new ServerSelectionDialog();
            await serverDialog.ShowAsync();  
        }
    }
}
