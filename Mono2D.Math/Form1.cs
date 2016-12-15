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
        Timer FPSCounter = new Timer();
        #endregion
        #region variables
        Mouse mouse = new Mouse();
        Graphics gr;
        Bitmap bit;
        int FPSnow = 0;
        int FPS = 0;
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

            timer.Interval = 10;
            timer.Tick += timerTick;
            timer.Start();

            FPSCounter.Interval = 1000;
            FPSCounter.Tick += FPSCounterTick;
            FPSCounter.Start();

            initLocalVariables();
        }
        #endregion

        #region private void FPSCounterTick(object sender, EventArgs e)
        private void FPSCounterTick(object sender, EventArgs e)
        {
            FPS = FPSnow;
            FPSnow = 0;
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
        LMDMono2D.Dot[] ds = new Dot[] { new Dot(40, 40), new Dot(120, 40), new Dot(80, 80), new Dot(70, 70), new Dot(50, 90), new Dot(30, 20), };
        #endregion
        #region private void initLocalVariables()
        private void initLocalVariables()
        {

        }
        #endregion
        #region private void timerTick(object sender, EventArgs e)
        private void timerTick(object sender, EventArgs e)
        {
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.FillRectangle(new SolidBrush(Color.FromArgb(20, 0, 0, 0)), new Rectangle(0, 0, Screen.Width, Screen.Height));
            Dot M = new Dot(mouse.x, mouse.y);

            #region old tests
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

            Pen p = new Pen(Color.White, 1);
            if (DotMath.IsLineIntersect(A, B, C, D) == true) { p.Color = Color.Green; }
            gr.DrawLine(p, A, B);
            gr.DrawLine(p, C, D);*/

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
            /*Dot A = new Dot(40, 40);
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
            gr.FillRectangle(new SolidBrush(Color.Red), inter.X - 2, inter.Y - 2, 4, 4);*/


            /*Dot A = new Dot(100f, 100f);
            Dot B = new Dot(100f, 150f);

            B -= A;
            B.P += (float)((System.Environment.TickCount / 1000f) % (System.Math.PI * 2f));
            B += A;

            Dot C = new Dot(B) + new Dot(10f, 0f);
            C -= B;
            C.P = (B - A).P + 1.57f;
            C.L = 10f;
            C += B;

            gr.DrawLine(new Pen(Color.White, 1), A, B);
            gr.DrawLine(new Pen(Color.White, 1), B, C);*/
            #endregion

            Dot[] ds2;
            ds2 = DotMath.RotateFrom(ds, DotMath.PolygonCenter(ds), (float)System.Environment.TickCount / 5000f);
            ds2 = DotMath.Translate(ds2, new Dot(100f, 80f));
            ds2 = DotMath.ScaleFrom(ds2, DotMath.PolygonCenter(ds2), 2f);
            if (DotMath.IsDotInPolygon(ds2, M))
            {
                gr.FillPolygon(new SolidBrush(Color.White), Dot.ToPoints(ds2));
            }
            gr.DrawPolygon(new Pen(Color.White, 1), Dot.ToPoints(ds2));

            Pen p = new Pen(Color.White, 1);
            Dot X = DotMath.DotClosestPolygon(ds2, M);

            Dot NV = X - M;
            NV = NV.GetUnitVector();
            NV.P += (float)System.Math.PI / 2f;
            NV.L *= 20f;

            Dot OX = new Dot(20f, 0f);

            gr.DrawLine(new Pen(Color.White, 1), X, M);
            gr.DrawLine(new Pen(Color.White, 1), M - NV, M + NV);
            gr.DrawLine(new Pen(Color.White, 1), M - OX, M + OX);
            float sangle = DotMath.StraightsAngle(new Dot(), NV, new Dot(), OX);
            gr.DrawArc(new Pen(Color.White, 1), new RectangleF(M.X - 20f, M.Y - 20f, 40f, 40f), 0f, (float)(System.Math.PI - (sangle * (360f / (System.Math.PI * 2f)))));
            if (X != null)
            {
                gr.FillEllipse(new SolidBrush(Color.Black), X.X - 3, X.Y - 3, 6, 6);
                gr.DrawEllipse(new Pen(Color.White, 1), X.X - 3, X.Y - 3, 6, 6);
            }
            gr.DrawString("Angle: " + (sangle * (360f / (System.Math.PI * 2f))).ToString(), new Font("Arial", 10), new SolidBrush(Color.White), new Point(0, 260));
            gr.DrawString("Distance: " + DotMath.Distance(X, M).ToString(), new Font("Arial", 10), new SolidBrush(Color.White), new Point(0, 280));

            gr.DrawString("LMDMono2D.DotMath V1.1 Release", new Font("Arial", 10), new SolidBrush(Color.White), new Point(180, 280));

            /*Pen pOrange = new Pen(Color.Orange, 2);
            Pen pAqua = new Pen(Color.Aqua, 2);
            Pen pWhite = new Pen(Color.White, 2);
            SolidBrush sbBlack = new SolidBrush(Color.Black);
            SolidBrush sbWhite = new SolidBrush(Color.White);
            SolidBrush sbOrange = new SolidBrush(Color.Orange);
            SolidBrush sbAqua = new SolidBrush(Color.Aqua);

            Dot X = DotMath.DotClosestPolygon(ds, M);

            gr.DrawLines(pOrange, Dot.ToPoints(ds));
            gr.DrawLine(pOrange, ds[ds.Length - 1], ds[0]);
            gr.DrawLine(pAqua, X, M);

            gr.FillEllipse(sbBlack, X.X - 4, X.Y - 4, 8, 8);
            gr.DrawEllipse(pAqua, X.X - 4, X.Y - 4, 8, 8);*/

            gr.DrawString(FPS.ToString(), new Font("Arial", 10), new SolidBrush(Color.White),new Point(380, 0));           
            Screen.Image = bit;
            FPSnow++;
        }
        #endregion
    }
}
