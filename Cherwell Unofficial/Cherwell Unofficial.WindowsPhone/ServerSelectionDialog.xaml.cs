using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Cherwell_Unofficial
{
    public sealed partial class ServerSelectionDialog : ContentDialog
    {
        public ServerSelectionDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// OkButton, returns selected server info back to the main dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if(url.Text.Length > 3)
            {
                //save all connection info and return selected one to main page
            }
            else
            {
                //display popup of bad url
            }
        }

        /// <summary>
        /// CancelButton, doesn't return info to main dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        /// <summary>
        /// When clicked, will add a new connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addConnection_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
