// WELCOME !!!
// this is DotMath (LMDMono2D project)
// Created by Jkulvich (@Jkulvich)

// https://vk.com/jkulvich
// https://twitter.com/jkulvich

/*
It's my MATH library fro my future games and other programs :)
... I'm thinking what write else... )))
*/

#define SystemDrawing_Compatibility // allow implicit converting to Point (with round) and PointF and back

using System;

#region compatibility with libraries and data types
#if (SystemDrawing_Compatibility) 
using System.Drawing;
#endif
#endregion

namespace LMDMono2D
{
    #region public class Dot
    /// <summary>
    /// The Dot class, maybe Vector or Point. Have coordinates.
    /// </summary>
    public class Dot
    {
        private bool PolarSyncWithDecart = true;
        private bool DecartSyncWithPolar = true;
        #region get/set float X
        private float x = 0f;
        /// <summary>
        /// The X coorinates from decart
        /// </summary>
        public float X
        {
            get
            {
                if (PolarSyncWithDecart == false)
                {
                    PolarSyncWithDecart = true;
                    SyncWithPolar();
                }
                return x;
            }
            set
            {
                x = value;
                DecartSyncWithPolar = false;
            }
        }
        #endregion
        #region get/set float Y
        private float y = 0f;
        /// <summary>
        /// The coordinate Y from decart
        /// </summary>
        public float Y
        {
            get
            {
                if (PolarSyncWithDecart == false)
                {
                    PolarSyncWithDecart = true;
                    SyncWithPolar();
                }
                return y;
            }
            set
            {
                y = value;
                DecartSyncWithPolar = false;
            }
        }
        #endregion
        #region get/set float L
        private float l = 0f;
        /// <summary>
        /// The L (length\distance) coordinate from polar
        /// </summary>
        public float L
        {
            get
            {
                if (DecartSyncWithPolar == false)
                {
                    DecartSyncWithPolar = true;
                    SyncWithDecart();
                }
                return l;
            }
            set
            {
                l = value;
                PolarSyncWithDecart = false;
            }
        }
        #endregion
        #region get/set float P
        private float p = 0f;
        /// <summary>
        /// The P (angle) coordinate from polar
        /// </summary>
        public float P
        {
            get
            {
                if (DecartSyncWithPolar == false)
                {
                    DecartSyncWithPolar = true;
                    SyncWithDecart();
                }
                return p;
            }
            set
            {
                p = value;
                PolarSyncWithDecart = false;
            }
        }
        #endregion

        #region constructor
        #region Dot(float x = 0, float y = 0, bool IsPolar = false)
        /// <summary>
        /// Initialize new dot and set coordinates from it (optional)
        /// </summary>
        /// <param name="x">X coordinate in decart or L in polar</param>
        /// <param name="y">Y coordinate in decart or P in polar</param>
        /// <param name="IsPolar">Set coordinate how polar?</param>
        public Dot(float x = 0, float y = 0, bool IsPolar = false)
        {
            if (IsPolar == true)
            {
                this.L = x;
                this.P = y;
                return;
                PolarSyncWithDecart = false;
            }
            this.X = x;
            this.Y = y;
            DecartSyncWithPolar = false;
        }
        #endregion
        #region Dot(Dot d)
        public Dot(Dot d)
        {
            this.X = d.X;
            this.Y = d.Y;
        }
        #endregion
        #endregion

        #region overloading functions
        #region public override string ToString()
        public override string ToString()
        {
            return "Dot(" + X.ToString() + ", " + Y.ToString() + ")";
        }
        #endregion
        #region public override string ToString(bool polar)
        public string ToString(bool polar)
        {
            if (polar == true)
            {
                return "Dot(" + L.ToString() + ", " + P.ToString() + ")";
            }
            return "Dot(" + X.ToString() + ", " + Y.ToString() + ")";
        }
        #endregion
        #endregion
        #region overloading operators
        #region +
        #region Dot = Dot + Dot
        public static Dot operator +(Dot d1, Dot d2)
        {
            return new Dot(d1.X + d2.X, d1.Y + d2.Y);
        }
        #endregion
        #region Dot = Dot + float
        public static Dot operator +(Dot d1, float f)
        {
            return new Dot(d1.X + f, d1.Y + f);
        }
        #endregion
        #region Dot = float + Dot
        public static Dot operator +(float f, Dot d1)
        {
            return new Dot(d1.X + f, d1.Y + f);
        }
        #endregion
        #endregion
        #region -
        #region Dot = Dot + Dot
        public static Dot operator -(Dot d1, Dot d2)
        {
            return new Dot(d1.X - d2.X, d1.Y - d2.Y);
        }
        #endregion
        #region Dot = Dot - float
        public static Dot operator -(Dot d1, float f)
        {
            return new Dot(d1.X - f, d1.Y - f);
        }
        #endregion
        #region Dot = float - Dot
        public static Dot operator -(float f, Dot d1)
        {
            return new Dot(f - d1.X, f - d1.Y);
        }
        #endregion
        #endregion
        #region *
        #region Dot = Dot * Dot
        public static Dot operator *(Dot d1, Dot d2)
        {
            return new Dot(d1.X * d2.X, d1.Y * d2.Y);
        }
        #endregion
        #region Dot = Dot * float
        public static Dot operator *(Dot d1, float f)
        {
            return new Dot(d1.X * f, d1.Y * f);
        }
        #endregion
        #region Dot = float * Dot
        public static Dot operator *(float f, Dot d1)
        {
            return new Dot(d1.X * f, d1.Y * f);
        }
        #endregion
        #endregion
        #region /
        #region Dot = Dot / Dot
        public static Dot operator /(Dot d1, Dot d2)
        {
            return new Dot(d1.X / d2.X, d1.Y / d2.Y);
        }
        #endregion
        #region Dot = Dot / float
        public static Dot operator /(Dot d1, float f)
        {
            return new Dot(d1.X / f, d1.Y / f);
        }
        #endregion
        #region Dot = float / Dot
        public static Dot operator /(float f, Dot d1)
        {
            return new Dot(f / d1.X, f / d1.Y);
        }
        #endregion
        #endregion
        #endregion
        #region Types converter (compatibility)
        #region SystemDrawing_Compatibility
#if (SystemDrawing_Compatibility)
        #region implicit from Dot to PointF
        public static implicit operator PointF(Dot d)
        {
            return new PointF(d.X, d.Y);
        }
        #endregion
        #region implicit from Dot to Point
        public static implicit operator Point(Dot d)
        {
            return new Point((int)System.Math.Round(d.X), (int)System.Math.Round(d.Y));
        }
        #endregion
        #region implicit from PointF to Dot
        public static implicit operator Dot(PointF p)
        {
            return new Dot(p.X, p.Y);
        }
        #endregion
        #region implicit from Point to Dot
        public static implicit operator Dot(Point p)
        {
            return new Dot(p.X, p.Y);
        }
        #endregion
        #region no overloading ! Dot array to Point array
        public static Point[] ToPoints(Dot[] ds)
        {
            Point[] ps = new Point[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                ps[i] = ds[i];
            }
            return ps;
        }
        #endregion
        #region no overloading ! Dot array to PointF array
        public static PointF[] ToPointFs(Dot[] ds)
        {
            PointF[] ps = new PointF[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                ps[i] = ds[i];
            }
            return ps;
        }
        #endregion
        #region no overloading ! Point array to Dot array
        public static Dot[] ToDots(Point[] ps)
        {
            Dot[] ds = new Dot[ps.Length];
            for (int i = 0; i < ps.Length; i++)
            {
                ds[i] = ps[i];
            }
            return ds;
        }
        #endregion
        #region no overloading ! PointF array to Dot array
        public static Dot[] ToDots(PointF[] ps)
        {
            Dot[] ds = new Dot[ps.Length];
            for (int i = 0; i < ps.Length; i++)
            {
                ds[i] = ps[i];
            }
            return ds;
        }
        #endregion
#endif
        #endregion
        #endregion

        #region public Dot GetUnitVector()
        /// <summary>
        /// Returns normalize or unit vector of this.
        /// </summary>
        /// <returns></returns>
        public Dot GetUnitVector()
        {
            float l = DotMath.Distance(this, new Dot(0, 0));
            return new Dot(this.X / l, this.Y / l);
        }
        #endregion
        #region public static Dot GetUnitVector(Dot d)
        /// <summary>
        /// Returns normalize or unit vector by "d"
        /// </summary>
        /// <param name="d">Dot vector</param>
        /// <returns></returns>
        public static Dot GetUnitVector(Dot d)
        {
            float l = DotMath.Distance(d, new Dot(0, 0));
            return new Dot(d.X / l, d.Y / l);
        }
        #endregion

        #region public static float[] GetPolarByDecart(float x, float y)
        /// <summary>
        /// Retrun linear array from L (length) and P (angle) by x and y
        /// </summary>
        /// <param name="x">X coordinate in decart</param>
        /// <param name="y">Y coordinate in decart</param>
        /// <returns></returns>
        public static float[] GetPolarByDecart(float x, float y)
        {
            float l = (float)System.Math.Sqrt(x * x + y * y);
            float p = 0f;
            if (l != 0)
            {
                p = (float)System.Math.Acos(x / l) * (y < 0 ? -1f : 1f); ;
            }
            else
            {
                p = 0f;
            }
            return new float[] { l, p };
        }
        #endregion
        #region public static float[] GetDecartByPolar(float l, float p)
        /// <summary>
        /// Returns linear array from X and Y by polar
        /// </summary>
        /// <param name="l">length</param>
        /// <param name="p">angle</param>
        /// <returns></returns>
        public static float[] GetDecartByPolar(float l, float p)
        {
            float x = (float)System.Math.Cos(p) * l;
            float y = (float)System.Math.Sin(p) * l;
            return new float[] { x, y };
        }
        #endregion

        #region private void SyncWithDecart()
        /// <summary>
        /// Convert decart coordinates to polar from this point
        /// </summary>
        private void SyncWithDecart()
        {
            l = (float)System.Math.Sqrt(x * x + y * y);
            if (l == 0) { p = 0f; return; }
            p = (float)System.Math.Acos(x / l) * (y < 0 ? -1f : 1f);
        }
        #endregion
        #region private void SyncWithPolar()
        /// <summary>
        /// Convert polar coordinates to decart from this point
        /// </summary>
        private void SyncWithPolar()
        {
            x = (float)System.Math.Cos(p) * l;
            y = (float)System.Math.Sin(p) * l;
        }
        #endregion
    }
    #endregion
    #region public class DotMath
    public static class DotMath
    {
        #region public static float Distance(Dot d1, Dot d2)
        /// <summary>
        /// Returns the distance between two points
        /// </summary>
        /// <param name="d1">First point</param>
        /// <param name="d2">Second point</param>
        /// <returns></returns>
        public static float Distance(Dot d1, Dot d2)
        {
            // for speed
            float xcord = (d1.X - d2.X);
            float ycord = (d1.Y - d2.Y);
            return (float)System.Math.Sqrt(xcord * xcord + ycord * ycord);
        }
        #endregion
        #region public static float TriangleArea(Dot d1, Dot d2, Dot d3)
        /// <summary>
        /// Returns area for triangle
        /// </summary>
        /// <param name="d1">First point</param>
        /// <param name="d2">Second point</param>
        /// <param name="d3">Third point</param>
        /// <returns></returns>
        public static float TriangleArea(Dot d1, Dot d2, Dot d3)
        {
            float a = Distance(d1, d2);
            float b = Distance(d2, d3);
            float c = Distance(d3, d1);
            float p = (a + b + c) / 2f;
            return (float)System.Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        #endregion
        #region public static float PolygonArea(Dot[] ds)
        /// <summary>
        /// Returns area of polygon (for correct use CONVEX POLYGONS only)
        /// </summary>
        /// <param name="ds">Array of dots</param>
        /// <returns></returns>
        public static float PolygonArea(Dot[] ds)
        {
            if (ds.Length > 2)
            {
                float TASum = 0f;
                for (int i = 1; i < ds.Length - 1; i++)
                {
                    TASum += TriangleArea(ds[0], ds[i], ds[i + 1]);
                }
                return TASum;
            }
            return 0f;
        }
        #endregion
        #region public static bool IsDotInTriangle(Dot d1, Dot d2, Dot d3, Dot p)
        /// <summary>
        /// Returns true if positive and false in another case (for correct use only CONVEX POLYGONS)
        /// </summary>
        /// <param name="d1">Fisrt point</param>
        /// <param name="d2">Second point</param>
        /// <param name="d3">Third point</param>
        /// <param name="p">Dot point</param>
        /// <returns></returns>
        public static bool IsDotInTriangle(Dot d1, Dot d2, Dot d3, Dot p)
        {
            // Full Triangle Area
            float fta = TriangleArea(d1, d2, d3);
            // Triangle N Area
            float t1a = TriangleArea(d1, d2, p);
            float t2a = TriangleArea(d2, d3, p);
            float t3a = TriangleArea(d3, d1, p);
            if (fta + 1f >= t1a + t2a + t3a) // костыль, т.к. иногда сумма площадей может слегка превысить общую площадь
            {
                return true;
            }
            return false;
        }
        #endregion
        #region public static bool IsDotInPolygon(Dot[] ps, Dot p)
        /// <summary>
        /// Returns true if point contains in polygons and false in another case (only for CONVEX POLYGONS)
        /// </summary>
        /// <param name="ps">Array of points</param>
        /// <param name="p">Point</param>
        /// <returns></returns>
        public static bool IsDotInPolygon(Dot[] ps, Dot p)
        {
            if (ps.Length > 2)
            {
                for (int i = 1; i < ps.Length - 1; i++)
                {
                    if (IsDotInTriangle(ps[0], ps[i], ps[i + 1], p) == true)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        #endregion
        #region public static Dot StraightsIntersect(Dot p11, Dot p12, Dot p21, Dot p22)
        /// <summary>
        /// Returns point which is intersect point of 2 straight
        /// </summary>
        /// <param name="A">First point of the first line</param>
        /// <param name="B">Second point of the first line</param>
        /// <param name="C">First point of the second line</param>
        /// <param name="D">Second point of the second line</param>
        /// <returns></returns>
        public static Dot StraightsIntersect(Dot A, Dot B, Dot C, Dot D)
        {
            float a = A.Y - B.Y;
            float b = B.X - A.X;
            float c = A.X * B.Y - B.X * A.Y;

            float d = C.Y - D.Y;
            float e = D.X - C.X;
            float f = C.X * D.Y - D.X * C.Y;

            if (a != 0 && a * e - d * b != 0)
            {
                float y = (d * c - f * a) / (a * e - d * b);
                float x = (-c - b * y) / a;

                return new Dot(x, y);
            }
            return new Dot(0f, 0f);
        }
        #endregion

        #region public static Dot[] Translate(Dot[] ds, float x, float y)
        /// <summary>
        /// Move all dots
        /// </summary>
        /// <param name="ds">Array of dots</param>
        /// <param name="x">Translate by X</param>
        /// <param name="y">Translate by Y</param>
        /// <returns></returns>
        public static Dot[] Translate(Dot[] ds, float x, float y)
        {
            Dot[] nds = new Dot[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                nds[i] = new Dot();
                nds[i].X = ds[i].X + x;
                nds[i].Y = ds[i].Y + y;
            }
            return nds;
        }
        #endregion
        #region public static Dot[] Rotate(Dot[] ds, float p)
        /// <summary>
        /// Rotate all dots in array (center 0, 0)
        /// </summary>
        /// <param name="ds">Array of dots</param>
        /// <param name="p">Rotate angle</param>
        /// <returns></returns>
        public static Dot[] Rotate(Dot[] ds, float p)
        {
            Dot[] nds = new Dot[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                nds[i] = new Dot();
                nds[i].L = ds[i].L;
                nds[i].P = ds[i].P + p;
            }
            return nds;
        }
        #endregion
        #region public static Dot PolygonCenter(Dot[] ds)
        /// <summary>
        /// Returns dot - its a center of polygon
        /// </summary>
        /// <param name="ds">Array of polygons</param>
        /// <returns></returns>
        public static Dot PolygonCenter(Dot[] ds)
        {
            Dot center = new Dot();
            for (int i = 0; i < ds.Length; i++)
            {
                center.X += ds[i].X;
                center.Y += ds[i].Y;
            }
            center.X /= (float)ds.Length;
            center.Y /= (float)ds.Length;
            return center;
        }
        #endregion
        #region public static Dot[] Scale(Dot[] ds, float s)
        public static Dot[] Scale(Dot[] ds, float s)
        {
            Dot[] nds = new Dot[ds.Length];
            for (int i = 0; i < ds.Length; i++)
            {
                nds[i] = new Dot(ds[i].L * s, ds[i].P, true);
            }
            return nds;
        }
        #endregion

        #region public static float StraightAngle(Dot a, Dot b, Dot c, Dot d)
        /// <summary>
        /// Returns straight angle
        /// </summary>
        /// <param name="a">First point of the first line</param>
        /// <param name="b">Second point of the first line</param>
        /// <param name="c">First point of the second line</param>
        /// <param name="d">Second point of the second line</param>
        /// <returns></returns>
        public static float StraightAngle(Dot a, Dot b, Dot c, Dot d)
        {
            float bottom = (float)(System.Math.Sqrt((a.Y - b.Y) * (a.Y - b.Y) + (b.X - a.X) * (b.X - a.X)) * System.Math.Sqrt((c.Y - d.Y) * (c.Y - d.Y) + (d.X - c.X) * (d.X - c.X)));
            if (bottom == 0) { return 0f; }
            return (float)System.Math.Acos(((a.Y - b.Y)*(c.Y - d.Y) + (b.X - a.X)*(d.X - c.X)) / bottom);
        }
        #endregion
        #region public static Dot DotStraightProjection(Dot A, Dot B, Dot C)
        /// <summary>
        /// Returns projection C dot to straight AB
        /// </summary>
        /// <param name="A">First point of straight</param>
        /// <param name="B">Second point of straight</param>
        /// <param name="C">Other dot</param>
        /// <returns></returns>
        public static Dot DotStraightProjection(Dot A, Dot B, Dot C)
        {
            Dot Z = Dot.GetUnitVector(B - A);
            Z.P += (float)System.Math.PI / 2f;
            Z = Z + C;
            return StraightsIntersect(A, B, C, Z);
        }
        #endregion

        #region public static bool IsLineIntersect(Dot A, Dot B, Dot C, Dot D)
        /// <summary>
        /// Returns true if lines is intersected
        /// </summary>
        /// <param name="A">First point of first line</param>
        /// <param name="B">Second point of first line</param>
        /// <param name="C">First point of second line</param>
        /// <param name="D">Second point of second line</param>
        /// <returns></returns>
        public static bool IsLineIntersect(Dot A, Dot B, Dot C, Dot D)
        {
            float v1 = (D.X - C.X) * (A.Y - C.Y) - (D.Y - C.Y) * (A.X - C.X);
            float v2 = (D.X - C.X) * (B.Y - C.Y) - (D.Y - C.Y) * (B.X - C.X);
            float v3 = (B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X);
            float v4 = (B.X - A.X) * (D.Y - A.Y) - (B.Y - A.Y) * (D.X - A.X);
            return (v1 * v2 <= 0) && (v3 * v4 <= 0);
        }
        #endregion

        // I delete it later... don't use, please.
        #region public static Dot[] GetLineByPoints(Dot A, Dot B, float mult = float.MaxValue)
        /// <summary>
        /// Returns 2 dots which is max line point.
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static Dot[] GetLineByPoints(Dot A, Dot B, float mult = 1E+6f)
        {
            Dot C = A - Dot.GetUnitVector(B - A) * mult;
            Dot D = B + Dot.GetUnitVector(B - A) * mult;
            return new Dot[] { C, D };
        }
        #endregion
    }
    #endregion
}
