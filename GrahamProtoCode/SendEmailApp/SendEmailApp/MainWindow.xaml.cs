using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.Security;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;

namespace SendEmailApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ComposeMsgWndw composeWndw;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string message;
            string username = username_txtbx.Text;
            string password = pass_txtbx.Password;
            TcpClient client = new TcpClient();
            client.Connect("imap.gmail.com", 993);

            // Establish stream, reader, and writer
            SslStream stream = new SslStream( client.GetStream() );
            stream.AuthenticateAsClient( "imap.gmail.com" );

            if (stream.IsAuthenticated)
            {
                // Declare reader and writer streams
                StreamWriter writer = new StreamWriter(stream);
                StreamReader reader = new StreamReader(stream);

                // Recieve first message from server
                message = reader.ReadLine();
                //Console.WriteLine(message);
                //Console.ReadLine();

                // Send login information
                message = "01 LOGIN " + username + " " + password;
                writer.WriteLine(message);
                writer.Flush();

                // Read second and third message from server
                message = reader.ReadLine();
                string[] firstCheck = message.Split(' ');
                if (firstCheck[1] != "NO")
                {
                    //Console.WriteLine(message);
                    message = reader.ReadLine();
                    //Console.WriteLine(message);
                    //Console.ReadLine();
                    string[] checkmessage = message.Split(' ');

                    if (checkmessage[1] == "OK")
                    {

                        var client2 = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential(username, password),
                            EnableSsl = true
                        };
                        debug_lbl.Content = "You have valid credentials";
                    }
                }
                else
                    debug_lbl.Content = "Your credentials are invalid";
            }
            //if (client.EnableSsl == true)
            /*if (client != null)
                debug_lbl.Content = "You have valid credentials";
            else
                debug_lbl.Content = "Your credentials are invalid";
                    */
            //Authentication checks out, open new window for user to compose mail
            //composeWndw = new ComposeMsgWndw();
            //composeWndw.Show();
            
        }
    }
}
