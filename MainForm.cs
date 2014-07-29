using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MostDrive
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height * 10/11;

            this.DoubleBuffered = true;

            location = new Location(this, car);
            carControl = new CarControl(car);
            highway = new Highway(this);

            timerScore = new Timer();
            timerScore.Tick += timerScore_Tick;
            timerScore.Interval = 200;
            timerScore.Start();
        }

        private Timer timerScore;
        private Highway highway;
        private Location location;
        private CarControl carControl;

        private int counter = 0;

        private void timerScore_Tick(object sender, EventArgs e)
        {
            if (highway.Speed < 10)
            {
                highway.Speed++;
            }

            counter++;

            if (counter == 2)
            {                
                Obstacle obstacle = new Obstacle(this, car, highway.Speed * 2, location.GenerateObstaclePosition().X);
                obstacle.Impact += obstacle_Impact;

                Bonus bonus = new Bonus(this,car, 10, location.GenerateObstaclePosition().X);
                bonus.Gained += bonus_Gained;
                counter = 0;
            }
        }

        private int score = 0;
        private void bonus_Gained(object sender, ImpactEventArgs e)
        {
            score += 100;
            labelScore.Text = string.Format("Score: {0}",score);
            ((Bonus)sender).Dispose();
        }

        private int impacts = 0;
        private void obstacle_Impact(object sender, ImpactEventArgs e)
        {
            ((Obstacle)sender).Dispose();

            impacts++;

            labelImpacts.Text = string.Format("Impacts: {0}", impacts);

            if (impacts == 5)
            {
                MessageBox.Show("Your score: " + score,
                "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Dispose();
                this.Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            highway.OnPaint(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            car.Location = location.SetDefaultCarPosition();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                carControl.Moove(location.GetNextPosition(car.Location, false));
            }
            else if (e.KeyCode == Keys.Right)
            {
                carControl.Moove(location.GetNextPosition(car.Location, true));
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timerScore.Dispose();
        }
    }
}
