using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cimena_App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start_app());


            //using (var ctx = new CimenaDBContext())
            //{
            //    var film = new Film() { Filmi_nimetus = "New film" };

            //    ctx.Films.Add(film);
            //    ctx.SaveChanges();
            //}


        }
    }
}
