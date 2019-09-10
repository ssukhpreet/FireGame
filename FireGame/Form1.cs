using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireGame
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer("sniper.wav");
        System.Media.SoundPlayer emptyTrigger= new System.Media.SoundPlayer("Trigger.wav");
        int trigger = 0,fire_Trigger=0,no=0,count=0;
        // this mwthod is used to click the fire to generate the sound effect for shoot and shoot away button both bu using the concept of oops and user define method
        public int winner() {
            //generate a random no to pass the shoot and shootaway button
            Random rnd = new Random();
            return rnd.Next(1, 6);
        }

        public Form1()
        {
            InitializeComponent();
            // hide the button of the game
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            DialogResult dialogResult = MessageBox.Show("Wel come to the Game You want to play?", "Confirmation Message", MessageBoxButtons.YesNo);
            //confirm the game is started or not 
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                MessageBox.Show("Click on the Start Button to play the Game");
                //pass the no using calling the winner method of the game 
                no = winner();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this is the load button event that is used to load the image of the gun
            pictureBox1.ImageLocation = "sukh2.jpg";
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this code for play again task to ber performed  reset all the variable 
            button1.Visible = true;
            trigger = 0;
            fire_Trigger = 0;
            no =winner(); count = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //start the game of 
            pictureBox1.ImageLocation = "sukh1.jpg";
            button2.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this code for shoot this code id used to trigger six times only in this time u can win or loos the game the whole thing depend upon  the concept of random no 
            pictureBox1.ImageLocation = "sukh3.jpg";

            player.Play();
            trigger++;
            if (trigger==winner()) {
                MessageBox.Show("you are the Winner of the game ");
            }
            if (trigger == 6) {
                MessageBox.Show(" your chances are over now");
                button3.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                button5.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //shoot away code is used to triger only 2 times and when u click one fire then the first fire will generate the message this is ur last chance or u win the game or not 
            fire_Trigger++;
            if (fire_Trigger == no)
            {
                player.Play();
                
                count++;
                if (count == 1)
                {
                    MessageBox.Show("this is you last chance to Fire again");
                }
                else {
                    if (fire_Trigger == no)
                    {
                        MessageBox.Show("you are the winner ");
                        button4.Visible = false;
                        button1.Visible = false;
                        button2.Visible = false;
                        button5.Visible = true;
                    }
                    else {
                        MessageBox.Show("you lose the game ");
                        button4.Visible = false;
                        button1.Visible = false;
                        button2.Visible = false;
                        button5.Visible = true;
                    }
                }

                no = winner();
            }
            else {
                emptyTrigger.Play();   
            }
        }
    }
}
