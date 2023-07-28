using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ksiazka1
{
    public partial class Form1 : Form
    {

        int passenger;
        bool goLeft, goRight, goDown, goUp;
        int ruch = 4;
        int fala = 1;
        double paliwo = 800;
        double money = 200;
        int x = 0;
        int gwiazdki = 0;
        int i1 = 0;
        int i2 = 0;
        int i3 = 0;
        int c = 0;
        private int elapsedSeconds = 600;
        public Form1()
        {
            InitializeComponent();
        }
       private void restart()
        {
            boat.Location = new Point(odbiorludzi.Top - boat.Width, odbiorludzi.Left ); ;
           paliwo = 800;
             money = 200;
             gwiazdki = 0;
             i1 = 0;
            i2 = 0;
            i3 = 0;
            elapsedSeconds = 600;
            gwiazd1.Visible = true;
            gwiazd2.Visible = true;
            gwiazd3.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            c++;
            if (c > 5)
            {
                elapsedSeconds++;
                c = 0;
            }
            int minutes = elapsedSeconds / 60;
            int seconds = elapsedSeconds % 60;
            money1.Text = $"Twój portfel: {money} zł";
            paliwo1.Text = $"Ilość paliwa: {paliwo} litrów";
            godz.Text = "Jest godzina: " + string.Format("{0:00}:{1:00}", minutes, seconds);
            if (elapsedSeconds >= 1200)
            {
                elapsedSeconds = 600;
            }
            if(elapsedSeconds >=720&& elapsedSeconds <= 960){

                fala1.Visible = true;
                fala2.Visible = true;
                fala3.Visible = true;
                fala4.Visible = true;
                fala5.Visible = true;


                if (boat.Bounds.IntersectsWith(port.Bounds))
                {
                    x = 1;
                }
                else
                {
                    boat.Location = new Point(boat.Left, boat.Top += fala);
                    slad.Location = new Point(boat.Left, boat.Top += fala);
                }
                
            }
            else
            {
                fala1.Visible = false;
                fala2.Visible = false;
                fala3.Visible = false;
                fala4.Visible = false;
                fala5.Visible = false;

            }
            if (boat.Bounds.IntersectsWith(molo.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(portgora.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(portlewo.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(portprawo.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(rafa1.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(rafa2.Bounds))
            {
                restart();
            }
            if (boat.Bounds.IntersectsWith(rafa3.Bounds))
            {
                restart();
            }

            if (goLeft == true && boat.Left > 0)                                         //ruch gracza
            {
                boat.Left -= ruch;
                
                if (passenger == 0)
                {
                    boat.Image = Properties.Resources.saulel;
                    slad.Image = Properties.Resources.sladl;
                    boat.Width = 80;
                    boat.Height = 40;
                    slad.Location = new Point(boat.Left + boat.Width , boat.Top );
                }
                else
                {
                    boat.Image = Properties.Resources.sauleln;
                    slad.Image = Properties.Resources.sladl;
                    boat.Width = 80;
                    boat.Height = 40;
                    slad.Location = new Point(boat.Left + boat.Width, boat.Top );
                }
               
            }
            if (goRight == true && boat.Left + boat.Width < this.ClientSize.Width)
            {
                boat.Left += ruch;
               
                if (passenger == 0)
                {
                    boat.Image = Properties.Resources.saulep;
                    slad.Image = Properties.Resources.sladp;
                    boat.Width = 80;
                    boat.Height = 40;
                    slad.Location = new Point(boat.Left - boat.Width/2, boat.Top );
                }
                else
                {
                    boat.Image = Properties.Resources.saulepn;
                    slad.Image = Properties.Resources.sladp;
                    boat.Width = 80;
                    boat.Height = 40;
                    slad.Location = new Point(boat.Left - boat.Width / 2, boat.Top );
                }
                
            }
            if (goUp == true && boat.Top > 0) 
            {
                boat.Top -= ruch;
                
                if (passenger == 0)
                {
                    boat.Image = Properties.Resources.sauleg;
                    
                    slad.Image = Properties.Resources.sladg;
                    boat.Width = 40;
                    boat.Height = 80;
                    slad.Location = new Point(boat.Left , boat.Top + boat.Height);
                }
                else
                {
                    boat.Image = Properties.Resources.saulegn;
                    slad.Image = Properties.Resources.sladg;
                    boat.Width = 40;
                    boat.Height = 80;
                    slad.Location = new Point(boat.Left , boat.Top + boat.Height);
                }


            }
            if (goDown == true && boat.Top + boat.Height < this.ClientSize.Height)
            {
                boat.Top += ruch;
                
                if (passenger == 0)
                {
                    boat.Width = 40;
                    boat.Height = 80;
                    boat.Image = Properties.Resources.sauled;
                    slad.Image = Properties.Resources.sladd;
                    
                    slad.Location = new Point(boat.Left , boat.Top - boat.Height/2);
                }
                else
                {
                    boat.Width = 40;
                    boat.Height = 80;
                    boat.Image = Properties.Resources.sauledn;
                    slad.Image = Properties.Resources.sladd;
                    
                    slad.Location = new Point(boat.Left , boat.Top - boat.Height / 2);
                }
            }

            if(paliwo <= 0)
            {
                ruch = 0;
            }


            if (boat.Bounds.IntersectsWith(stacja.Bounds))
            {
                if(paliwo < 1000 && money > 0)
                {
                    paliwo = paliwo + 20;
                    money = money - 1;
                }

            }
            
            if (boat.Bounds.IntersectsWith(odbiorludzi.Bounds))
            {
                passenger = 1;
            }
            if (boat.Bounds.IntersectsWith(odbiorludzi.Bounds) && passenger==1 && (gwiazdki >= 1))
            {
                passenger = 0;
                gwiazd1.Visible = true;
                gwiazd2.Visible = true;
                gwiazd3.Visible = true;
                if (gwiazdki == 3)
                {
                    money = money + 200;
                    gwiazdki = 0;
                }
                else if (gwiazdki == 2)
                {
                    money = money + 100;
                    gwiazdki = 0;
                }
                else if (gwiazdki == 1)
                {
                    money = money + 50;
                    gwiazdki = 0;
                }
                i1 = 0;
                i2 = 0;
                i3 = 0;
            }

    

            if (goLeft == true || goRight == true || goUp == true || goDown == true)
            {
                paliwo = paliwo - 1;
                slad.Visible = true;
            }
            else
            {
                slad.Visible = false;
            }

            fala1.Location = new Point(fala1.Left, fala1.Top += fala);          //fale
            if (fala1.Top == portgora.Top)
            {
                fala1.Location = new Point(fala1.Left, gwiazd2.Top);
            }
            fala2.Location = new Point(fala2.Left, fala2.Top += fala);
            if (fala2.Top == portgora.Top)
            {
                fala2.Location = new Point(fala2.Left, gwiazd2.Top);
            }
            fala3.Location = new Point(fala3.Left, fala3.Top += fala);
            if (fala3.Top == portgora.Top)
            {
                fala3.Location = new Point(fala3.Left, gwiazd2.Top);
            }
            fala4.Location = new Point(fala4.Left, fala4.Top += fala);
            if (fala4.Top == portgora.Top)
            {
                fala4.Location = new Point(fala4.Left, gwiazd2.Top);
            }
            fala5.Location = new Point(fala5.Left, fala5.Top += fala);
            if (fala5.Top == portgora.Top)
            {
                fala5.Location = new Point(fala5.Left, gwiazd2.Top);
            }
            if (boat.Bounds.IntersectsWith(gwiazd1.Bounds) && (i1 == 0))
            {
                gwiazdki++;
                gwiazd1.Visible = false;
                i1 = 1;
            }
            if (boat.Bounds.IntersectsWith(gwiazd2.Bounds) && (i2 == 0))
            {
                gwiazdki++;
                gwiazd2.Visible = false;
                i2 = 1;
            }
            if (boat.Bounds.IntersectsWith(gwiazd3.Bounds) && (i3 == 0))
            {
                gwiazdki++;
                gwiazd3.Visible = false;
                i3 = 1;
            }
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
        }

        private void czasspalanie_Tick(object sender, EventArgs e)
        {
            
        }


        private void pictureBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

      

        private void label14_Click(object sender, EventArgs e)              //sklep
        {
            if (money >= 500)
            {
                money = money - 500;
                ruch = 6;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (money >= 1500)
            {
                money = money - 1500;
                ruch = 9;
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (money >= 3000)
            {
                money = money - 3000;
                ruch = 12;
            }
        }

       
     

    }
}