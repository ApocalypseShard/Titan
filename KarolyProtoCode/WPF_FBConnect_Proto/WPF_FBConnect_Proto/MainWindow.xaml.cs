using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;

namespace WPF_FBConnect_Proto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /* Various Fields to which GUI supports access
         * Auth: string oauthTestString = "https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=211505718975007&redirect_uri=https%3A%2F%2Fwww.facebook.com/connect/login_success.html&scope=read_friendlists,read_mailbox";
         * De-auth: "https://graph.facebook.com/me/permissions?method=delete"
         * View Friends "https://graph.facebook.com/me/friends?accesstoken="
         * Profile Feed "https://graph.facebook.com/me/
         * Likes "https://graph.facebook.com/me/likes?accesstoken="
         * Photos "https://graph.facebook.com/me/albums?accesstoken="
         * Profile Pic "https://graph.facebook.com/me/picture?=accesstoken="
         */

        private string appID = "211505718975007";
        private string redirectURI = "https://www.facebook.com/connect/login_success.html";
        string responseType = "token";
        string display = "popup";
        string extendedPerms = "read_friendlists, read_mailbox";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void auth_Btn_Click(object sender, RoutedEventArgs e)
        {
            string oauthTestString = "https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=211505718975007&redirect_uri=https%3A%2F%2Fwww.facebook.com/connect/login_success.html&scope=read_friendlists,read_mailbox";

            HttpWebRequest httpWebReq = (HttpWebRequest)WebRequest.Create(oauthTestString);

            HttpWebResponse response = (HttpWebResponse)httpWebReq.GetResponse();

            auth_Lbl.Content = response.ToString();

        }

        private void viewFriends_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deAuth_Btn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
