using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;
using System.IO;
using System.Reflection;
using System.Windows.Media;

//Cherry: +10; Grapes: +10; Apple: +10; Seven: +30
//Wszystkie ikonki inne (lub dwa nie obok siebie): -45
//Dwie ikonki te same obok siebie: -30
//Wszystkie ikonki te same: -0

namespace GamblingMachine
{
    public partial class Form1 : Form
    {
        static Image seven = new Bitmap(GamblingMachine.Properties.Resources.seven);

        static Image apple = new Bitmap(GamblingMachine.Properties.Resources.apple);
        static Image cherries = new Bitmap(GamblingMachine.Properties.Resources.cherries);
        static Image grapes = new Bitmap(GamblingMachine.Properties.Resources.grapes);

        static Image[] normal = new Image[] { apple, cherries, grapes };

        static Image empty = new Bitmap(GamblingMachine.Properties.Resources.empty_box);

        static Image machine_down = new Bitmap(GamblingMachine.Properties.Resources.gambling_down_bg);
        static Image machine_normal = new Bitmap(GamblingMachine.Properties.Resources.gambling_bg);
        static Image machine_motion = new Bitmap(GamblingMachine.Properties.Resources.gambling_motion_bg);

        Boolean wait = false;
        Boolean permanentBlock = false;

        string[] minusPoints = new string[] { "Następnym razem będzie lepiej!", "Nie poddawaj się!", "Trening czyni mistrza!" };
        string[] level1 = new string[] { "Nieźle!", "Świetnie!", "Nabierasz wprawy!" }; // > 0
        string[] level2 = new string[] { "Właśnie tak!", "Tak trzymaj!", "Wielka fortuna jest tuż za rogiem!" }; // > 15
        string[] level3 = new string[] { "MASTER!", "Mistrz!", "Niebywały szcześciarz!" }; //> 30
        string[] level4 = new string[] { "TRIPLE SEVEN", "LEGENDA!!!!" }; // > 80

        int currPoints = 100;

        MediaPlayer sound = new MediaPlayer();

        public Form1()
        {
            InitializeComponent();
            current_points.Text = currPoints.ToString();
            added_points.Visible = false;
            message.Visible = false;
            current_points.BackColor = System.Drawing.Color.FromArgb(91, 68, 53);
            added_points.BackColor = System.Drawing.Color.FromArgb(91, 68, 53);
            message.BackColor = System.Drawing.Color.FromArgb(108, 87, 76);
            Stream resource = Assembly.GetExecutingAssembly().GetManifestResourceStream("GamblingMachine.Resources.Machine_working.wav");
            Stream output = File.Create(Path.GetTempPath() + "Machine_working.wav");
            try
            {
                resource.CopyTo(output);
            } catch (Exception e)
            {
                MessageBox.Show("Brak dostępu do folderu z plikami tymczasowymi!");
            }
            
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            resource.Close();
            output.Close();
        }

        void OnProcessExit(object sender, EventArgs e)
        {
            try
            {
                File.Delete(Path.Combine(Path.GetTempPath(), "Machine_working.wav"));
            } catch (Exception ex)
            {
                MessageBox.Show("Nie można usunąć plików tymczasowych!");
            }
        }

        private void drawBox(PictureBox box)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 101);
            Debug.WriteLine(num);

            if (num > 0 && num <= 10) //10%
            {
                box.Image = seven;
            } else if (num > 10 && num <= 40) //30%
            {
                box.Image = apple;
            } else if (num > 40 && num <= 70) //30%
            {
                box.Image = cherries;
            } else if (num > 70 && num <= 100) //30%
            {
                box.Image = grapes;
            }
            Stream str = Properties.Resources.Fruit_placed;
            SoundPlayer simpleSound = new SoundPlayer(str);
            simpleSound.Play();
        }

        private void resetBoxes()
        {
            box1.Image = empty;
            box2.Image = empty;
            box3.Image = empty;
        }

        private int calculatePoints(PictureBox[] boxes)
        {
            int points = 0;
            foreach (PictureBox box in boxes)
            {
                if (normal.Contains(box.Image))
                {
                    points += 10;
                } else if (box.Image == seven)
                {
                    points += 30;
                }
            }

            if (boxes[0].Image == boxes[1].Image && boxes[1].Image == boxes[2].Image)
            {
                //Skip
            } else if (boxes[0].Image == boxes[1].Image || boxes[1].Image == boxes[2].Image) //Tylko dwa obok siebie
            {
                points -= 30;
            } else
            {
                points -= 45;
            }

            return points;
        }

        private void displayMessage(int receivedPoints)
        {
            Random rnd = new Random();
            if (receivedPoints <= 0)
            {
                int i = rnd.Next(0, minusPoints.Length);
                message.Text = minusPoints[i];
            } else if (receivedPoints > 0 && receivedPoints <= 15)
            {
                int i = rnd.Next(0, level1.Length);
                message.Text = level1[i];
            } else if (receivedPoints > 15 && receivedPoints <= 30)
            {
                int i = rnd.Next(0, level2.Length);
                message.Text = level2[i];
            } else if (receivedPoints > 30 && receivedPoints <= 80)
            {
                int i = rnd.Next(0, level3.Length);
                message.Text = level3[i];
            } else
            {
                int i = rnd.Next(0, level4.Length);
                message.Text = level4[i];
            }
        }

        private async void pointsAnimation(int basePoints, int endPoints)
        {
            Boolean add = true;
            if (endPoints - basePoints == 0)
            {
                return;
            }
            if (endPoints < basePoints)
            {
                add = false;
            }

            int difference = Math.Abs(Math.Abs(endPoints) - Math.Abs(basePoints));
            int tempPoints = basePoints;
            int step = 1;
            for (int i = 1; i <= difference; i++)
            {
                if (add)
                {
                    tempPoints += step;
                } else
                {
                    tempPoints -= step;
                }

                current_points.Text = tempPoints.ToString();
                await Task.Delay(50);
            }
            current_points.Text = endPoints.ToString();
        }

        private async void entryFee()
        {

            added_points.Visible = true;
            added_points.Text = "-2";
            added_points.ForeColor = System.Drawing.Color.Red;
            pointsAnimation(currPoints, currPoints - 2);
            currPoints -= 2;
            await Task.Delay(1000);
            added_points.Visible = false;
        }

        private async void machine_Click(object sender, MouseEventArgs e)
        {
            if (!wait && e.Button == MouseButtons.Left && !permanentBlock)
            {
                wait = true;
                this.Cursor = Cursors.WaitCursor;
                entryFee();
                resetBoxes();

                Stream str = Properties.Resources.Lever_down;
                SoundPlayer simpleSound = new SoundPlayer(str);
                simpleSound.Play();

                machine.Image = machine_down;
                await Task.Delay(500);
                machine.Image = machine_motion;
                await Task.Delay(400);

                sound.Open(new Uri(Path.Combine(Path.GetTempPath(), "Machine_working.wav")));
                sound.Position = TimeSpan.Zero;
                sound.Play();

                await Task.Delay(1500);
                drawBox(box1);
                await Task.Delay(1500);
                drawBox(box2);
                await Task.Delay(1500);
                drawBox(box3);
                machine.Image = machine_normal;

                PictureBox[] boxes = new PictureBox[] { box1, box2, box3 };
                int receivedPoints = calculatePoints(boxes);
                if (receivedPoints < 0)
                {
                    added_points.ForeColor = System.Drawing.Color.Red;
                    added_points.Text = "";
                } else
                {
                    added_points.ForeColor = System.Drawing.Color.LightGreen;
                    added_points.Text = "+";
                }

                added_points.Text += receivedPoints.ToString();
                added_points.Visible = true;
                pointsAnimation(currPoints, currPoints + receivedPoints);
                currPoints += receivedPoints;

                displayMessage(receivedPoints);
                message.Visible = true;
                
                this.Cursor = Cursors.Default;
                if (currPoints < 0)
                {
                    MessageBox.Show("Niestety zbankrutowałeś.");
                    permanentBlock = true;
                }
                await Task.Delay(2000);
                
                message.Visible = false;
                wait = false;
            }
            
        }

        private void oGrzeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("© 2021 Filip Dawidowski @ VLO Gdańsk");
        }
    }
}
