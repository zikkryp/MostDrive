using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MostDrive
{
    class Location
    {
        public Location(Form form, PictureBox car)
        {
            this.form = form;
            this.car = car;

            random = new Random();
        }

        Random random;

        private PictureBox car;
        private Form form;

        public Point SetDefaultCarPosition()
        {
            int sector = form.ClientSize.Width / 4;
            int x = sector * 2 + sector / 5;

            return new Point(x, form.ClientSize.Height - car.Height - 20);
        }

        public Point GetNextPosition(Point location, bool right)
        {
            if (right)
            {
                if (location.X < (form.ClientSize.Width - form.ClientSize.Width / 4 + (form.ClientSize.Width / 4) / 5))
                {
                    location = new Point(location.X + form.ClientSize.Width / 4, location.Y);
                }
            }
            else
            {
                if (location.X > (form.ClientSize.Width / 4) / 5)
                {
                    location = new Point(location.X - form.ClientSize.Width / 4, location.Y);
                }
            }

            return location;
        }

        public Point GenerateObstaclePosition()
        {
            int sector = form.ClientSize.Width / 4;
            int x = sector * random.Next(0, 4) + sector / 5;

            return new Point(x, 0);
        }
    }
}
