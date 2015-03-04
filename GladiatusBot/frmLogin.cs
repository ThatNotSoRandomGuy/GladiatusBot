using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GladiatusBot
{
    public partial class frmLogin : Form
    {
        private Dictionary<string,string> _Countries = 
            new Dictionary<string,string>() { 
                {"United Kingdom","en"}, 
                {"USA","us"}
            };

        string filePath = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ), "GladiatusBot\\userinfo.dat" );
        RestClient _RestClient;
        public frmLogin() {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            foreach(var kv in _Countries) {
                inputCountry.Items.Add( kv.Key );
            }
            inputCountry.SelectedIndex = 0;

            if(File.Exists( filePath )) {
                string[] content = File.ReadAllLines( filePath );
                try {
                    inputUsername.Text = ( from cont in content
                                           where cont.StartsWith( "username" )
                                           select cont.Split( '=' ).Last() ).First();

                    inputPassword.Text = ( from cont in content
                                           where cont.StartsWith( "password" )
                                           select cont.Split( '=' ).Last() ).First();

                    inputProvince.Text = ( from cont in content
                                           where cont.StartsWith( "province" )
                                           select cont.Split( '=' ).Last() ).First();

                    inputCountry.SelectedItem = ( from cont in content
                                                  where cont.StartsWith( "country" )
                                                  select cont.Split( '=' ).Last() ).First();

                    inputRememberMe.Checked = ( from cont in content
                                                  where cont.StartsWith( "remember" )
                                                  select cont.Split( '=' ).Last() ).First().Equals("True");

                } catch(InvalidOperationException ex) {

                    MessageBox.Show( ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                } catch(Exception ex) {
                    MessageBox.Show( ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }

        }

        private void buttonLogin_Click( object sender, EventArgs e ) {
            
            int server = 0;
            if(!int.TryParse( inputProvince.Text, out server )) {
                MessageBox.Show( "Please type a province number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            if(inputUsername.Text.Length == 0 || inputPassword.Text.Length == 0) {
                MessageBox.Show( "Please type a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }


            var url = String.Format( "http://s{0}.{1}.gladiatus.gameforge.com", server, _Countries[(string)inputCountry.SelectedItem] );
            _RestClient = new RestClient(url);

            Core.Login login = new Core.Login( _RestClient, inputUsername.Text, inputPassword.Text );
            var session = login.DoLogin();
            if(!session.IsLogged) {
                MessageBox.Show( "Failed to login. Make sure the country and province are correct." );
                return;
            }

            if(inputRememberMe.Checked) {
                string[] lines = {
                    "username=" + inputUsername.Text,
                    "password=" + inputPassword.Text,
                    "province=" + inputProvince.Text,
                    "country=" + (string)inputCountry.SelectedItem,
                    "remember=" + inputRememberMe.Checked.ToString()
                };
                if(!Directory.Exists( Directory.GetParent( filePath ).FullName)) {
                    Directory.CreateDirectory( filePath );
                }
                File.WriteAllLines( filePath, lines );
            } else {
                if(File.Exists( filePath )) {
                    File.Delete( filePath );
                }
            }

            frmMainForm mainForm = new frmMainForm( this, _RestClient, session );
            this.Hide();
            mainForm.Show();
        }
    }
}
