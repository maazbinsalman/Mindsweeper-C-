using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleMinefield
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();      //for allocating bombs at random places in the specified interval
            int bomb1 = rnd.Next(1, 8);
            int bomb2 = rnd.Next(8,16);
            int bomb3 = rnd.Next(16,24);
            int bomb4 = rnd.Next(24, 32);
            int bomb5 = rnd.Next(32, 40);
            int bomb6 = rnd.Next(40, 48);
            int bomb7 = rnd.Next(48, 56);
            int bomb8 = rnd.Next(56, 64);

            for (int i = 1; i <= 64; i++)
            {
                Button btnTemp = new Button();

                btnTemp.Size = new System.Drawing.Size(30, 30);     //makes a matrix that fits in flow layout panel

                if (bomb1 == i || bomb2 == i || bomb3 == i || bomb4 == i || bomb5 == i || bomb6 == i || bomb7 == i || bomb8 == i)     //if any bomb is clicked the game ends. OR functionality
                    btnTemp.Tag = true;
                else
                    btnTemp.Tag = false;        //the game continues on if bomb is not clicked

                btnTemp.Click += BtnTemp_Click;     //indicates a click has occured
                flowLayoutPanel1.Controls.Add(btnTemp);
            }
        }

        private void BtnTemp_Click(object sender, EventArgs e)      //for matrix buttons
        {
            Button btnTemp = (Button)sender;        //assign a button to object
            bool tag = (bool)btnTemp.Tag;           //assigns a tag to store the value and check above condition

            if (tag)
            {
                btnTemp.BackColor = Color.Red;      //red for bomb
                int score = int.Parse(lblBomb.Text);        //converting string to int to display bomb when it bursts
                score++;    
                lblBomb.Text = score.ToString();        //Bomb gets one

                if (score == 1)        //whenever bomb is pressed it asksyou for restart
                {
                    DialogResult result = MessageBox.Show("You are lost\nRestart ?", "Game Result", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (result == DialogResult.Yes)
                        Application.Restart();
                    else
                        Close();
                }
            }
            else
            {
                btnTemp.BackColor = Color.Green;        //green for a non-bomb box
                int score = int.Parse(lblScore.Text);       
                score++;        //the score gets incremented until bomb is pressed
                lblScore.Text = score.ToString();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }

        private void lblBoom_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
