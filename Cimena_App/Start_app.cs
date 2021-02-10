using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cimena_App
{
    public partial class Start_app : Form
    {
        public int i=0, j=0;
        ListBox saalide_list;
        public Start_app()
        {
            this.Text = "SuperKino";
            this.BackgroundImage = Image.FromFile(@"..\..\tere.png");
            this.Size = new Size(360, 300);
            saalide_list = new ListBox();
            saalide_list.Location = new Point(10, 10);
            saalide_list.Font= new Font(DefaultFont.FontFamily, 14);
            saalide_list.Size = new Size(150, 30);
            saalide_list.Items.Add("Vali saal");
            saalide_list.Items.Add("Väike");
            saalide_list.Items.Add("Keskmine");
            saalide_list.Items.Add("Suur");
            this.Controls.Add(saalide_list);
            saalide_list.SelectedIndexChanged += Saalide_list_SelectedIndexChanged;
        }

        private void Saalide_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (saalide_list.SelectedIndex == 1)
            {
                i = 5; j = 5;
            }
            else if (saalide_list.SelectedIndex == 2)
            {
                i = 10; j = 10;
            }
            else if (saalide_list.SelectedIndex == 3)
            {
                i = 15; j = 15;
            }
            else
            {
                MessageBox.Show("Viga!", "Vaja saal valida");
            }
            Saalid saalid = new Saalid(i, j);
            saalid.Show();
        }

        
    }
}
