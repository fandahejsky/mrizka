using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mrizka
{
    public partial class Form1 : Form
    {

        public List<Ctverecek> ctverecky = new List<Ctverecek>();
       
        public Form1()
        {
            InitializeComponent();
            
        }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Ctverecek ctverecek = new Ctverecek( new Point(0,0));
            //ctverecek.Draw(e.Graphics);

            /*       for (int i = 0; i <= 500; i++)
                   {


                       for (int j = 0; j <= 500; j++)
                       {
                           Ctverecek ctverecek = new Ctverecek(new Point(i, j));
                           ctverecek.Draw(e.Graphics);
                           ctverecky.Add(ctverecek);

                           j += 50;
                       }
                       i += 50;
                   }*/
            foreach (Ctverecek ctverecek in ctverecky)
                ctverecek.Draw(e.Graphics);

           

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ctverecky.Count; i++)
            {
                if (ctverecky[i].isMouseOverObject(e.Location))
                {
                    //MessageBox.Show("");
                    ctverecky[i].CurrentColor = Brushes.Red;
                    
                }
            }
          panel1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 500; i++)
            {


                for (int j = 0; j <= 500; j++)
                {
                    Ctverecek ctverecek = new Ctverecek(new Point(i, j));
                  //  ctverecek.Draw(e.Graphics);
                    ctverecky.Add(ctverecek);

                    j += 50;
                }
                i += 50;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < ctverecky.Count; i++)
            {
                if (ctverecky[i].isMouseOverObject(e.Location))
                {
                    //MessageBox.Show("");
                    ctverecky[i].CurrentColor = Brushes.Yellow;

                }
            }
            panel1.Refresh();
        }
    }
}
