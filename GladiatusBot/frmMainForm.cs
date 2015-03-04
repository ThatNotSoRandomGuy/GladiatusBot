using GladiatusBot.Core;
using MetroFramework;
using MetroFramework.Forms;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GladiatusBot {
    public partial class frmMainForm : MetroForm {

        private GladiatusClient _Gladiatus;

        public frmMainForm( ) {
            InitializeComponent();

            InitializeStyleManager();

            Login();
        }

        private void Login() {
            frmLogin loginForm = new frmLogin(this.metroStyleManager);
            if(loginForm.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                _Gladiatus = loginForm.GetClient();
            } else {
                //This will close the form
                Shown += ( s, e ) => Close();
            }
        }

        private void InitializeStyleManager() {
            metroStyleManager.Owner = this;
            metroStyleManager.Theme = MetroThemeStyle.Dark;
            metroStyleManager.Style = MetroColorStyle.Blue;
            this.StyleManager = metroStyleManager;
        }
    }
}
