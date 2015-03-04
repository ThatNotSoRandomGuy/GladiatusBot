using GladiatusBot.Core;
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
    public partial class frmMainForm : Form {
        private RestClient  _RestClient;
        private SessionInfo _Session;
        private Form        _Parent;
        public frmMainForm( Form parent, RestClient client, SessionInfo session ) {
            _RestClient = client;
            _Session = session;
            _Parent = parent;

            InitializeComponent();
        }

        protected override void OnClosed( EventArgs e ) {
            base.OnClosed( e );
            _Parent.Close();
        }
    }
}
