using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cimena_App
{
    public partial class Start_app : Form
    {
        SqlConnection con;
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\marina.oleinik\projects\Cimena_App\Cimena_App\CinemaDB.mdf;Integrated Security=True");
        
        SqlDataAdapter Saalide_adapter;
        public int i=0, j=0;
        ListBox saalide_list;
        int[] read_list;//reade list
        int[] kohad_list;//kohade list
        public Start_app()
        {   this.Text = "SuperKino";
            this.BackgroundImage = Image.FromFile(@"..\..\tere.png");
            this.Size = new Size(360, 300);
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\CinemaDB.mdf;Integrated Security=True");
            con.Open();
            
            Saalide_adapter = new SqlDataAdapter("SELECT * FROM Saalid_tabel", con);
            DataTable salid_tabel = new DataTable();
            Saalide_adapter.Fill(salid_tabel);
            saalide_list = new ListBox();
            saalide_list.Location = new Point(10, 10);
            saalide_list.Font= new Font(DefaultFont.FontFamily, 14);
            saalide_list.Size = new Size(150, 30);
                       
            foreach (DataRow row in salid_tabel.Rows)
            {
                saalide_list.Items.Add(row["Saalinimetus"]);
            }

            read_list = new int[salid_tabel.Rows.Count];
            kohad_list = new int[salid_tabel.Rows.Count];
            int a = 0;
            foreach (DataRow row in salid_tabel.Rows)
            {
                read_list[a] = (int)row["Read"];
                kohad_list[a] = (int)row["Kohad"];
                a=a+1;
            }
            con.Close();
            //saalide_list.Items.Add("Vali saal");
            //saalide_list.Items.Add("Väike");
            //saalide_list.Items.Add("Keskmine");
            //saalide_list.Items.Add("Suur");
            this.Controls.Add(saalide_list);
            saalide_list.SelectedIndexChanged += Saalide_list_SelectedIndexChanged;
        }

        private void Saalide_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            i = read_list[saalide_list.SelectedIndex]; 
            j = kohad_list[saalide_list.SelectedIndex];
            Saalid saalid = new Saalid(i, j);
            saalid.Show();
        }

        
    }
}
