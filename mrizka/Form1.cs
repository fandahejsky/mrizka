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

        public bool holding = false;

        int zeleny = 0;
        int cerveny = 0;
        int modry = 0;
        int zluty = 0;

       

        bool showNumbers = false;
        bool superclickCharged = false;
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
            
            holding = true;
            for (int i = 0; i < ctverecky.Count; i++)
            {
                if (ctverecky[i].isMouseOverObject(e.Location))
                {
                    if(ctverecky[i].CurrentColor == Brushes.Blue)
                    {
                        return;
                    }

                    //MessageBox.Show("");
                    ctverecky[i].CurrentColor = Brushes.Red;
                    ctverecky[i].Locked = true;
                    
                }
            }
            


         

            canvas1.Refresh();
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
            holding = false;
            for (int i = 0; i < ctverecky.Count; i++)
            {
                if (ctverecky[i].isMouseOverObject(e.Location))
                {
                    //MessageBox.Show("");
                    if((ctverecky[i].Locked == false))
                    ctverecky[i].CurrentColor = Brushes.Yellow;

                }
            }
            canvas1.Refresh();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (holding)
            {
                for (int i = 0; i < ctverecky.Count; i++)
                {
                    if (ctverecky[i].isMouseOverObject(e.Location))
                    {
                        //MessageBox.Show("");
                        if ((ctverecky[i].Locked == false))
                            ctverecky[i].CurrentColor = Brushes.Blue;

                    }
                }
                canvas1.Refresh();
            }
           
        }

        private void canvas1_Paint(object sender, PaintEventArgs e)
        {
            label2.Text = "Červené: 0     0%";
            label3.Text = "Modré: 0     0%";
            label4.Text = "Žluté: 0     0%";
         
            zeleny = 0;
            cerveny = 0;
            modry = 0;
            zluty = 0;
            foreach (Ctverecek ctverecek in ctverecky)
                ctverecek.Draw(e.Graphics);
           
            for (int i = 0; i < ctverecky.Count; i++)
            {
                if(showNumbers == true)
                e.Graphics.DrawString(ctverecky[i].ColorsChanged.ToString(), SystemFonts.DefaultFont, Brushes.Black, ctverecky[i].position.X, ctverecky[i].position.Y);

                if (ctverecky[i].CurrentColor == Brushes.Green)
                    zeleny++;

                if(ctverecky[i].CurrentColor == Brushes.Red)
                    cerveny++;

                if(ctverecky[i].CurrentColor == Brushes.Blue)
                    modry++;

                if(ctverecky[i].CurrentColor == Brushes.Yellow)
                    zluty++;
            }

            label1.Text = "Zelené: " + zeleny.ToString() + "    " +  zeleny.ToString() +"%";
            label2.Text = "Červené: " + cerveny.ToString() + "    " + cerveny.ToString() + "%";
            label3.Text = "Modré: " + modry.ToString() + "    " + modry.ToString() + "%";
            label4.Text = "Žluté: " + zluty.ToString() + "    " + zluty.ToString() + "%";

         
        }

        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            if (holding)
            {
                for (int i = 0; i < ctverecky.Count; i++)
                {
                    
                    if (ctverecky[i].isMouseOverObject(e.Location))
                    {
                        //MessageBox.Show("");
                        if ((ctverecky[i].Locked == false))
                        {
                            ctverecky[i].CurrentColor = Brushes.Blue;
                            ctverecky[i].ColorsChanged++;
                            ctverecky[i].Locked = true;
                        }
                            

                    }
                }
                canvas1.Refresh();
            }
        }

        private void canvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < ctverecky.Count; i++)
                {
                    ctverecky[i].Locked = false;
                    if (ctverecky[i].isMouseOverObject(e.Location))
                    {
                        ctverecky[i].CurrentColor = Brushes.Green;
                        ctverecky[i].ColorsChanged++;

                    }
                }
            }

            if (e.Button == MouseButtons.Left)
            {
             
                if (superclickCharged)
                {
                    superclickCharged = false;
                    for (int i = 0; i < ctverecky.Count; i++)
                    {
                        
                        if (ctverecky[i].isMouseOverObject(e.Location))
                        {
                            ctverecky[i].CurrentColor = Brushes.Red;
                         

                        }
                        int tvojemama = 50;
                        
                        for (int j = 0; j < 100; j++)
                        {
                            //diagonala dolu
                            if (ctverecky[i].isMouseOverObject(new Point(e.X + tvojemama, e.Y + tvojemama)))
                            {
                                ctverecky[i].CurrentColor = Brushes.Red;
                            }
                            tvojemama += 50;
                        }
                        int tvujtata = 50;
                        for (int z = 0; z < 100; z++)
                        {
                            if (ctverecky[i].isMouseOverObject(new Point(e.X -tvujtata, e.Y -tvujtata)))
                            {
                                ctverecky[i].CurrentColor = Brushes.Red;
                            }
                            tvujtata += 50;
                        }

                        int tvojebabicka = 50;
                        for (int a = 0; a < 100; a++)
                        {
                            if (ctverecky[i].isMouseOverObject(new Point(e.X + tvojebabicka, e.Y - tvojebabicka)))
                            {
                                ctverecky[i].CurrentColor = Brushes.Red;
                            }
                            tvojebabicka += 50;
                        }

                        int tvujdeda = 50;
                        for (int a = 0; a < 100; a++)
                        {
                            if (ctverecky[i].isMouseOverObject(new Point(e.X - tvujdeda, e.Y + tvujdeda)))
                            {
                                ctverecky[i].CurrentColor = Brushes.Red;
                            }
                            tvujdeda += 50;
                        }


                    }
                }

                holding = true;
                for (int i = 0; i < ctverecky.Count; i++)
                {
                    if (ctverecky[i].isMouseOverObject(e.Location))
                    {
                        if (ctverecky[i].CurrentColor == Brushes.Blue)
                        {
                            return;
                        }

                        //MessageBox.Show("");
                        ctverecky[i].CurrentColor = Brushes.Red;
                        ctverecky[i].ColorsChanged++;
                        ctverecky[i].Locked = true;

                    }
                }



            }
            canvas1.Refresh();
        }

        private void canvas1_MouseUp(object sender, MouseEventArgs e)
        {
            
    if (e.Button == MouseButtons.Right)
            {

            }

    if(e.Button == MouseButtons.Left)
            {
                holding = false;
                for (int i = 0; i < ctverecky.Count; i++)
                {
                    if (ctverecky[i].isMouseOverObject(e.Location))
                    {
                        //MessageBox.Show("");
                        if (ctverecky[i].Locked == true)
                        {
                            if(ctverecky[i].CurrentColor != Brushes.Red) {
                                ctverecky[i].CurrentColor = Brushes.Yellow;
                                ctverecky[i].ColorsChanged++;
                            }
                            
                        }
                          

                    }
                }
                canvas1.Refresh();
            }
          
        }

        private void canvas1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
             
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(showNumbers == false)
            showNumbers = true;

            else
                showNumbers = false;

            canvas1.Refresh();
        }

        private void canvas1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                superclickCharged = true;
            
                
            }
        }
    }
}
