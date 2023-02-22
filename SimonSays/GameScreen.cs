using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create an int guess variable to track what part of the pattern the user is at
        public static int guess = 0;

        SoundPlayer mistake = new SoundPlayer(Properties.Resources.mistake);
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);

        int speed = 800;

        bool clickable;

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            GraphicsPath circlePath = new GraphicsPath();
            circlePath.AddEllipse(5, 5, 215, 215);
            Region buttonRegion = new Region(circlePath);

            greenButton.Region = buttonRegion;

            Matrix transformMatrix = new Matrix();
            transformMatrix.RotateAt(90, new PointF(60, 60));
            buttonRegion.Transform(transformMatrix);

            redButton.Region = buttonRegion;

            transformMatrix.RotateAt(90, new PointF(40, 40));
            buttonRegion.Transform(transformMatrix);

            yellowButton.Region = buttonRegion;

            transformMatrix.RotateAt(90, new PointF(35, 42));
            buttonRegion.Transform(transformMatrix);

            blueButton.Region = buttonRegion;

            //TODO: clear the pattern list from form1
            Form1.patterns.Clear();
            //TODO: refresh
            this.Refresh();
            //TODO: pause for a bit
            Thread.Sleep(2000);
            //TODO: run ComputerTurn()
            clickable = false;
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            clickable = false;
            Thread.Sleep(250);
            if (speed > 300)
            {
                speed -= 75;
            }
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list. Each number represents a button. For example, 0 may be green, 1 may be blue, etc.
            Random rnd = new Random();
            Form1.patterns.Add(rnd.Next(0, 4));
            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.patterns.Count; i++)
            {
                if (Form1.patterns[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    this.Refresh();
                    Thread.Sleep(speed);
                    greenButton.BackColor = Color.ForestGreen;
                    this.Refresh();
                    Thread.Sleep(100);
                }
                else if (Form1.patterns[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    this.Refresh();
                    Thread.Sleep(speed);
                    redButton.BackColor = Color.DarkRed;
                    this.Refresh();
                    Thread.Sleep(100);
                }
                else if (Form1.patterns[i] == 2)
                {
                    yellowButton.BackColor = Color.Gold;
                    this.Refresh();
                    Thread.Sleep(speed);
                    yellowButton.BackColor = Color.Goldenrod;
                    this.Refresh();
                    Thread.Sleep(100);
                }
                else if (Form1.patterns[i] == 3)
                {
                    blueButton.BackColor = Color.MediumSlateBlue;
                    this.Refresh();
                    Thread.Sleep(speed);
                    blueButton.BackColor = Color.DarkBlue;
                    this.Refresh();
                    Thread.Sleep(100);
                }
            }

            //TODO: set guess value back to 0
            guess = 0;
            clickable = true;
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            //TODO: is the value in the pattern list at index [guess] equal to a green?
            // change button color
            // play sound
            // refresh
            // pause
            // set button colour back to original
            // add one to the guess variable

            if (Form1.patterns[guess] == 0 && clickable == true)
            {
                greenButton.BackColor = Color.LimeGreen;
                greenSound.Play();
                this.Refresh();
                Thread.Sleep(150);
                greenButton.BackColor = Color.ForestGreen;
                this.Refresh();
                guess++;
            }
            else if (clickable == true)
            {
                GameOver();
            }

            //TODO:check to see if we are at the end of the pattern, (guess is the same as pattern list count).
            // call ComputerTurn() method
            // else call GameOver method

            if (guess == Form1.patterns.Count)
            {
                ComputerTurn();
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guess] == 1 && clickable == true)
            {
                redButton.BackColor = Color.Red;
                redSound.Play();
                this.Refresh();
                Thread.Sleep(150);
                redButton.BackColor = Color.DarkRed;
                this.Refresh();
                guess++;
            }
            else if (clickable == true)
            {
                GameOver();
            }

            if (guess == Form1.patterns.Count)
            {
                ComputerTurn();
            }
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guess] == 2 && clickable == true)
            {
                yellowButton.BackColor = Color.Gold;
                yellowSound.Play();
                this.Refresh();
                Thread.Sleep(150);
                yellowButton.BackColor = Color.Goldenrod;
                this.Refresh();
                guess++;
            }
            else if (clickable == true)
            {
                GameOver();
            }

            if (guess == Form1.patterns.Count)
            {
                ComputerTurn();
            }
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.patterns[guess] == 3 && clickable == true)
            {
                blueButton.BackColor = Color.MediumSlateBlue;
                blueSound.Play();
                this.Refresh();
                Thread.Sleep(150);
                blueButton.BackColor = Color.DarkBlue;
                this.Refresh();
                guess++;
            }
            else if (clickable == true)
            {
                GameOver();
            }

            if (guess == Form1.patterns.Count)
            {
                ComputerTurn();
            }
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            mistake.Play();
            //TODO: close this screen and open the GameOverScreen
            Form1.ChangeScreen(this, new GameOverScreen());
        }
    }
}
