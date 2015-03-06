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
        }

        protected override void OnLoad( EventArgs e ) {
            base.OnLoad( e );

            //Login();
            //FillUI();
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

        private void FillUI() {
            var overview = _Gladiatus.GetOverview();
            if(overview == null){
                throw new Exception( "Error trying to parse player overview." );
            }
            outputExperience.Text = overview.CurrentXP + "/" + overview.RequiredXP;
            outputExperienceBar.Value = (overview.CurrentXP * 100) / overview.RequiredXP;

            outputHP.Text = overview.CurrentHP + "/" + overview.MaxHP;
            outputHPBar.Value = (overview.CurrentHP * 100) / overview.MaxHP;

            outputGold.Text = overview.Gold.ToString();
            outputRubies.Text = overview.Rubies.ToString();
            outputRank.Text = overview.Ranking.ToString();
            outputLevel.Text = overview.Level.ToString();


        }

        private void InitializeStyleManager() {
            metroStyleManager.Owner = this;
            metroStyleManager.Theme = MetroThemeStyle.Dark;
            metroStyleManager.Style = MetroColorStyle.Blue;
            this.StyleManager = metroStyleManager;
        }
    }
}
