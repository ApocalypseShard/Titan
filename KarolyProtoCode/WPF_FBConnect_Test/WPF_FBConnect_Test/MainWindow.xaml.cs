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
using System.Web;


namespace WPF_FBConnect_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string accessToken;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void testauth_Btn_Click(object sender, RoutedEventArgs e)
        {
            string appID = "211505718975007";
            string redirectURI = "https://www.facebook.com/connect/login_success.html";
            string responseType = "token";
            string display = "popup";
            string extendedPerms = "read_friendlists,read_mailbox";

            //Failed
            //"https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=116122545078207&redirect_uri=http%3A%2F%2Fbenbiddington.wordpress.com&scope=user_photos,email,user_birthday,user_online_presence"

            //Web browser test success
            //https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=211505718975007&redirect_uri=https%3A%2F%2Fwww.facebook.com/connect/login_success.html&scope=read_friendlists,read_mailbox

            string oauthTestString = "https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=211505718975007&redirect_uri=https%3A%2F%2Fwww.facebook.com/connect/login_success.html&scope=read_friendlists,read_mailbox";
            
            webBrowser1.Navigate(oauthTestString);
        }

        private void requestFriendsBtn_Click(object sender, RoutedEventArgs e)
        {
            string getFriendsUrl = "https://graph.facebook.com/me/friends?access_token=" + accessToken;
            webBrowser1.Navigate(getFriendsUrl);
        }

        private void webBrowser1_LoadCompleted(object sender, NavigationEventArgs e)
        {
            
            string[] url = webBrowser1.Source.AbsoluteUri.Split('#');

            if (url.Length > 1)
            {
                string[] prms = url[1].Split('=');
                accessToken = prms[1].Split('&')[0];

                accessToken_Lbl.Content = accessToken;//webBrowser1.Source.AbsoluteUri;
            }


        }

       
    }
}
