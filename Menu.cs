using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MostDrive
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form form = new MainForm();
            form.FormClosing += form_FormClosing;
            form.ShowDialog();
        }

        void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form)sender).Dispose();
        }

        private void Scores_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
