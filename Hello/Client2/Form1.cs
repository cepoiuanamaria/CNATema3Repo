using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client2
{
    public partial class Form1 : MaterialForm
    {
        private static Form1 _instance;
        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1();
                return _instance;
            }
        }
        public Form1()
        {
            InitializeComponent();
            MaterialSkinManager manager = MaterialSkinManager.Instance;
            manager.AddFormToManage(this);
            manager.Theme = MaterialSkinManager.Themes.LIGHT;
            manager.ColorScheme = new ColorScheme(Primary.Blue400, Primary.Blue500, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);

        }

        private void MainContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        public Panel Content
        {
            get 
            {
                return MainContainer;
            }
            set
            {
                MainContainer = value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _instance = this;
            MainContainer.Controls.Add(new Login() { Dock = DockStyle.Fill });
        }
    }
}
