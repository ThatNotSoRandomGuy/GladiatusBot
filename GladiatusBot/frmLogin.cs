using GladiatusBot.Core;
using MetroFramework.Components;
using MetroFramework.Forms;
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
    public partial class frmLogin : MetroForm
    {
        private Dictionary<string,string> _Countries = 
            new Dictionary<string,string>() { 
                {"United Kingdom","en"}, 
                {"USA","us"}
            };

        private string SaveFile = Path.Combine( Environment.GetFolderPath( Environment.SpecialFolder.CommonApplicationData ), "GladiatusBot\\userinfo.dat" );
        private GladiatusClient _Client;

        public frmLogin(MetroStyleManager style) {
            InitializeComponent();
            InitializeStyleManager( style );

            InitializeCountriesComboBox();

            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void InitializeCountriesComboBox() {
            inputCountry.Items.Clear();
            foreach(KeyValuePair<string, string> kv in _Countries) {
                inputCountry.Items.Add( kv.Key );
            }
            inputCountry.SelectedIndex = 0;
        }

        private void InitializeStyleManager( MetroStyleManager style ) {
            this.StyleManager = new MetroFramework.Components.MetroStyleManager( this.components );
            this.StyleManager.Theme = style.Theme;
            this.StyleManager.Style = style.Style;
            this.StyleManager.Owner = this;
        }

        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            if(File.Exists( SaveFile )) {
                string[] content = File.ReadAllLines( SaveFile );
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

            if(!CanLogin()) { 
                MessageBox.Show( "Make sure all fields are filled." ); 
                return; 
            }

            _Client = new GladiatusClient(
                new LoginInfo(
                    inputUsername.Text,
                    inputPassword.Text,
                    "s" + inputProvince.Text,
                    _Countries[(string)inputCountry.SelectedItem] ) );

            if(!_Client.Login()) {
                MessageBox.Show( "Login failed. Make sure your information is correct." );
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
                if(!Directory.Exists( Directory.GetParent( SaveFile ).FullName)) {
                    Directory.CreateDirectory( SaveFile );
                }
                File.WriteAllLines( SaveFile, lines );
            } else {
                if(File.Exists( SaveFile )) {
                    File.Delete( SaveFile );
                }
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private bool CanLogin() {
            int server;
            return int.TryParse( inputProvince.Text, out server ) && inputUsername.Text.Length != 0 && inputPassword.Text.Length != 0;
        }

        public GladiatusClient GetClient() {
            return _Client;
        }
    }
}
