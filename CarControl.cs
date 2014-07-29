using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MostDrive
{
    class CarControl
    {
        public CarControl(PictureBox car)
        {
            this.car = car;

            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += timer_Tick;
        }

        private Timer timer;
        private System.Drawing.Point point;
        private PictureBox car;

        private bool isLocked;
        
        void timer_Tick(object sender, EventArgs e)
        {
            if (car.Location.X > point.X)
            {
                car.Location = new System.Drawing.Point(car.Location.X - 10, car.Location.Y);
            }
            else if (car.Location.X < point.X)
            {
                car.Location = new System.Drawing.Point(car.Location.X + 10, car.Location.Y);
            }
            else
            {
                timer.Stop();

                isLocked = false;
            }
        }

        public void Moove(System.Drawing.Point point)
        {
            if (!isLocked)
            {
                isLocked = true;
                this.point = point;
                timer.Start();
            }
        }
    }
}
