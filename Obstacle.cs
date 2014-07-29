using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MostDrive
{
    public class ImpactEventArgs : EventArgs
    {
        public ImpactEventArgs()
        {

        }
    }

    class RoadObject
    {
        protected virtual void Create()
        {

        }
    }

    class Bonus : RoadObject, IDisposable
    {
        public Bonus(Form form,PictureBox car, int speed, int position)
        {
            this.form = form;
            this.speed = speed;
            this.position = position;
            this.car = car;

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1;

            pictureBox = new PictureBox();
            pictureBox.Image = MostDrive.Properties.Resources.coin;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Size = new Size(50, 50);
            pictureBox.Location = new Point(position, -pictureBox.Height);
            form.Controls.Add(pictureBox);
            timer.Start();
        }

        ~Bonus()
        {
            Dispose(false);
        }

        private Timer timer;
        private Form form;
        private PictureBox pictureBox;
        private PictureBox car;
        private int position;
        private int speed;

        public event Action<object, ImpactEventArgs> Gained;

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + speed);

            if (pictureBox.Location.Y >= car.Location.Y && pictureBox.Location.X == car.Location.X)
            {
                if (Gained != null)
                {
                    Gained(this, new ImpactEventArgs());
                }                
            }
            else if (pictureBox.Location.Y >= form.ClientSize.Height)
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                timer.Dispose();
                form.Controls.Remove(pictureBox);
            }

            disposed = true;
        }

        bool disposed = false;
    }

    class Obstacle : IDisposable
    {
        public event Action<object, ImpactEventArgs> Impact;

        public Obstacle(Form form,PictureBox car, int speed, int position)
        {
            this.form = form;
            this.speed = speed;
            this.position = position;
            this.car = car;

            timer = new Timer();
            timer.Tick += timer_Tick;
            timer.Interval = 1;

            pictureBox = new PictureBox();
            pictureBox.BackgroundImage = MostDrive.Properties.Resources.car_red;
            pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox.Size = new Size(70, 130);
            pictureBox.Location = new Point(position, -pictureBox.Height);
            form.Controls.Add(pictureBox);
            timer.Start();
        }

        ~Obstacle()
        {
            Dispose(false);
        }

        private Timer timer;
        private Form form;
        private PictureBox pictureBox;

        private PictureBox car;
        private int position;
        private int speed;

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + speed);

            if (pictureBox.Location.Y >= car.Location.Y && pictureBox.Location.X == car.Location.X)
            {
                if (Impact != null)
                {
                    Impact(this, new ImpactEventArgs());
                }                
            }
            else if (pictureBox.Location.Y >= form.ClientSize.Height)
            {
                this.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                timer.Dispose();
                form.Controls.Remove(pictureBox);
            }

            disposed = true;
        }

        bool disposed = false;
    }
}

