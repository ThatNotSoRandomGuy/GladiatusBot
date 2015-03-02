using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        public frmLogin() {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            foreach(var kv in _Countries) {
                inputCountry.Items.Add( kv.Key );
            }
            inputCountry.SelectedIndex = 0;

            if(File.Exists( Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "GladiatusBot\\userinfo.dat" ) )) {
                string[] content = File.ReadAllLines( Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData ), "GladiatusBot\\userinfo.dat" ) );

                inputUsername.Text = ( from cont in content
                                       where cont.StartsWith( "username" )
                                       select cont.Split( '=' ).Last() ).First();

                inputPassword.Text = ( from cont in content
                                       where cont.StartsWith( "password" )
                                       select cont.Split( '=' ).Last() ).First();

                inputProvince.Text = ( from cont in content
                                       where cont.StartsWith( "province" )
                                       select cont.Split( '=' ).Last() ).First();

                inputCountry.SelectedText = ( from cont in content
                                              where cont.StartsWith( "country" )
                                              select cont.Split( '=' ).Last() ).First();

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

            var url = String.Format( "http://s{0}.{1}.gladiatus.gameforge.com", server, _Countries[(string)inputCountry.SelectedText] );
            RestSharp.RestClient client = new RestSharp.RestClient( url );

            Core.Login login = new Core.Login( client, inputUsername.Text, inputPassword.Text );
            if(!login.DoLogin()) MessageBox.Show( "Failed to login. Make sure the country and province are correct." );
            var sh = login.SecureHash;

            if(inputRememberMe.Checked) {
                //save info
            } else {
                //delete save
            }
        }
    }
}
