using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private Hero hero;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int newX = hero.GetX() + random.Next(-5, 6);
            int newY = hero.GetY() + random.Next(-5, 6);
            newX = Math.Max(Math.Min(newX, ClientSize.Width - pictureBox1.Width), 0);
            newY = Math.Max(Math.Min(newY, ClientSize.Height - pictureBox1.Height), 0);
            hero.Move(newX, newY);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hero = new Hero(pictureBox1);
            Enemy enemy1 = new Enemy(pictureBox2);
            Enemy enemy2 = new Enemy(pictureBox3);

            hero.Attach(enemy1);
            hero.Attach(enemy2);
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer1_Tick;
            timer.Start();


        }
    }
}
