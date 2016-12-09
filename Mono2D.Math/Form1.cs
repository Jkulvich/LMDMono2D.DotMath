using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMDMono2D
{
    public partial class MForm : Form
    {
        #region struct Mouse
        struct Mouse
        {
            public int x;
            public int y;
            public bool down;
        }
        #endregion
        #region components
        Timer timer = new Timer();
        #endregion
        #region variables
        Mouse mouse = new Mouse();
        Graphics gr;
        Bitmap bit;
        #endregion

        #region MFrom()
        public MForm()
        {
            InitializeComponent();
            Screen.MouseDown += MouseDown;
            Screen.MouseUp += MouseUp;
            Screen.MouseMove += MouseMove;

            bit = new Bitmap(Screen.Width, Screen.Height);
            gr = Graphics.FromImage(bit);

            timer.Interval = 33;
            timer.Tick += timerTick;
            timer.Start();

            initLocalVariables();
        }
        #endregion

        #region private void MouseDown(object sender, MouseEventArgs e)
        private new void MouseDown(object sender, MouseEventArgs e)
        {
            mouse.down = true;
            mouse.x = e.X;
            mouse.y = e.Y;
        }
        #endregion
        #region private void MouseUp(object sender, MouseEventArgs e)
        private new void MouseUp(object sender, MouseEventArgs e)
        {
            mouse.down = false;
            mouse.x = e.X;
            mouse.y = e.Y;
        }
        #endregion
        #region private void MouseMove(object sender, MouseEventArgs e)
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            mouse.x = e.X;
            mouse.y = e.Y;
        }
        #endregion

        #region local variables
        LMDMono2D.Dot[] ds = new Dot[] { new Dot(40, 40), new Dot(80, 40), new Dot(80, 80), new Dot(50, 90) };
        #endregion
        #region private void initLocalVariables()
        private void initLocalVariables()
        {

        }
        #endregion
        #region private void timerTick(object sender, EventArgs e)
        private void timerTick(object sender, EventArgs e)
        {
            gr.Clear(Color.Black);

            if (LMDMono2D.DotMath.IsDotInPolygon(ds, new Dot(mouse.x, mouse.y)) == true)
            {
                gr.FillPolygon(new SolidBrush(Color.White), Dot.ToPoints(ds));
            }
            gr.DrawPolygon(new Pen(Color.White, 1), Dot.ToPoints(ds));

            Screen.Image = bit;
        }
        #endregion
    }
}
