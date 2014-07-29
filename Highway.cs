using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace MostDrive
{
    class Highway : IDisposable
    {
        public Highway(Form form)
        {
            this.form = form;

            timerSpeed = new Timer();
            timerSpeed.Tick += timerSpeed_Tick;
            timerSpeed.Interval = 1;
            timerSpeed.Start();
        }

        private Timer timerSpeed;

        private int y1 = 0;
        private int y2 = 150;
        private int y3 = 300;
        private int y4 = 450;
        private int y5 = 600;

        private int _speed = 1;

        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private void timerSpeed_Tick(object sender, EventArgs e)
        {
            y1 += _speed;
            y2 += _speed;
            y3 += _speed;
            y4 += _speed;
            y5 += _speed;

            if (y1 > form.ClientSize.Height)
            {
                y1 = -100;
            }
            else if (y2 > form.ClientSize.Height)
            {
                y2 = -100;
            }
            else if (y3 > form.ClientSize.Height)
            {
                y3 = -100;
            }
            else if (y4 > form.ClientSize.Height)
            {
                y4 = -100;
            }

            form.Invalidate();
        }

        private Form form;

        public void SetSpeed(int speed)
        {
            this._speed = speed;
        }

        public void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 2 + 7, 0, 7, form.ClientSize.Height);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 2 - 7, 0, 7, form.ClientSize.Height);

            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 4 - 5, y1, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 4 - 5, y2, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 4 - 5, y3, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width / 4 - 5, y4, 5, 100);

            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width - form.ClientSize.Width / 4 - 5, y1, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width - form.ClientSize.Width / 4 - 5, y2, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width - form.ClientSize.Width / 4 - 5, y3, 5, 100);
            e.Graphics.FillRectangle(Brushes.White, form.ClientSize.Width - form.ClientSize.Width / 4 - 5, y4, 5, 100);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private bool disposed = false;
        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                timerSpeed.Dispose();
            }
        }
    }
}
