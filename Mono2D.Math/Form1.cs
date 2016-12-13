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
        LMDMono2D.Dot[] ds = new Dot[] { new Dot(40, 40), new Dot(80, 40), new Dot(80, 80), new Dot(50, 90), new Dot(30, 20), };
        #endregion
        #region private void initLocalVariables()
        private void initLocalVariables()
        {
            //MessageBox.Show((DotMath.StraightAngle(new Dot(0f, 0f), new Dot(5f, 0f), new Dot(1f, 0f), new Dot(-1f, 0f)) * (180f / System.Math.PI)).ToString());
        }
        #endregion
        #region private void timerTick(object sender, EventArgs e)
        private void timerTick(object sender, EventArgs e)
        {
            //gr.Clear(Color.Black);
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), new Rectangle(0, 0, Screen.Width, Screen.Height));

            // ---------- POLYGON INTERSECT
            /*if (LMDMono2D.DotMath.IsDotInPolygon(ds, new Dot(mouse.x, mouse.y)) == true)
            {
                gr.FillPolygon(new SolidBrush(Color.White), Dot.ToPoints(ds));
            }
            gr.DrawPolygon(new Pen(Color.White, 1), Dot.ToPoints(ds));
            gr.FillRectangle(new SolidBrush(Color.Green), new RectangleF(mouse.x - 2, mouse.y - 2, 4, 4));*/

            // ---------- STRAIGHTS INTERSECT
            /*Dot A = new Dot(40, 40);
            Dot B = new Dot(80, 50);
            Dot C = new Dot(70, 120);
            Dot D = new Dot(mouse.x, mouse.y);

            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(A.X - 2, A.Y - 2, 4, 4));
            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(B.X - 2, B.Y - 2, 4, 4));

            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(C.X - 2, C.Y - 2, 4, 4));
            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(D.X - 2, D.Y - 2, 4, 4));

            Dot[] AB = LMDMono2D.DotMath.GetLineByPoints(A, B, 400f);
            Dot[] CD = LMDMono2D.DotMath.GetLineByPoints(C, D);

            gr.DrawLine(new Pen(Color.White, 1), AB[0], AB[1]);
            gr.DrawLine(new Pen(Color.White, 1), CD[0], CD[1]);

            Dot inter = DotMath.StraightLineIntersect(A, B, C, D);
            gr.DrawString(inter.ToString(), new Font("arial", 10), new SolidBrush(Color.White), new PointF(0, 0));
            gr.FillRectangle(new SolidBrush(Color.Aqua), inter.X - 2, inter.Y - 2, 4, 4);*/

            // ---------- POLYGON ROTATE / SCALING and MOVING
            /*Dot cent = DotMath.PolygonCenter(ds);
            ds = DotMath.Translate(ds, -cent.X, -cent.Y);
            ds = DotMath.Rotate(ds, 0.02f);
            ds = DotMath.Translate(ds, cent.X, cent.Y);

            float s = (float)System.Math.Abs(System.Math.Sin(System.Environment.TickCount / 1000f)) * 1f + 0.5f;

            cent = DotMath.PolygonCenter(ds);
            ds = DotMath.Translate(ds, -cent.X, -cent.Y);
            ds = DotMath.Scale(ds, s);
            ds = DotMath.Translate(ds, cent.X * s, cent.Y * s);

            if (DotMath.IsDotInPolygon(ds, new Dot(mouse.x, mouse.y)) == true)
            {
                gr.FillPolygon(new SolidBrush(Color.White), Dot.ToPoints(ds));
            }
            gr.DrawPolygon(new Pen(Color.White, 1), Dot.ToPoints(ds));

            ds = DotMath.Scale(ds, 1f / s);*/

            // ---------- DOT PROJECTION
            Dot A = new Dot(40, 40);
            Dot B = new Dot(80, 50);
            Dot D = new Dot(mouse.x, mouse.y);
            Dot C = DotMath.DotStraightProjection(A, B, D);

            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(A.X - 2, A.Y - 2, 4, 4));
            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(B.X - 2, B.Y - 2, 4, 4));

            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(C.X - 2, C.Y - 2, 4, 4));
            gr.FillRectangle(new SolidBrush(Color.White), new RectangleF(D.X - 2, D.Y - 2, 4, 4));

            Dot[] AB = LMDMono2D.DotMath.GetLineByPoints(A, B, 400f);
            Dot[] CD = LMDMono2D.DotMath.GetLineByPoints(C, D);

            gr.DrawLine(new Pen(Color.White, 1), AB[0], AB[1]);
            gr.DrawLine(new Pen(Color.White, 1), CD[0], CD[1]);

            Dot inter = C; // DotMath.StraightLineIntersect(A, B, C, D);
            gr.DrawString(inter.ToString(), new Font("arial", 10), new SolidBrush(Color.White), new PointF(0, 0));
            gr.DrawString("Distance " + DotMath.Distance(C, D), new Font("arial", 10), new SolidBrush(Color.White), new PointF(0, 18));
            gr.FillRectangle(new SolidBrush(Color.Red), inter.X - 2, inter.Y - 2, 4, 4);

            Screen.Image = bit;
        }
        #endregion
    }
}
