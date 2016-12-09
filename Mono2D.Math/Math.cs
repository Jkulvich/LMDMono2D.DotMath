// WELCOME !!!
// this is DotMath (LMDMono2D project)
// Created by Jkulvich (@Jkulvich)

// https://vk.com/jkulvich
// https://twitter.com/jkulvich

/*
It's my MATH library fro my future games and other programs :)
... I'm thinking what write else... )))
*/

#define SystemDrawing_PointConverter // allow implicit converting to Point (with round) and PointF and back

using System;

#region compatibility with libraries and data types
#if (SystemDrawing_PointConverter) 
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
        public float x = 0f;
        public float y = 0f;

        #region constructor
        public Dot(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return "Dot(" + x.ToString() + ", " + y.ToString() + ")";
        }
        #endregion

        #region overloading operators
        #region +
        #region Dot = Dot + Dot
        public static Dot operator +(Dot d1, Dot d2)
        {
            return new Dot(d1.x + d2.x, d1.y + d2.y);
        }
        #endregion
        #region Dot = Dot + float
        public static Dot operator +(Dot d1, float f)
        {
            return new Dot(d1.x + f, d1.y + f);
        }
        #endregion
        #region Dot = float + Dot
        public static Dot operator +(float f, Dot d1)
        {
            return new Dot(d1.x + f, d1.y + f);
        }
        #endregion
        #endregion
        #region -
        #region Dot = Dot + Dot
        public static Dot operator -(Dot d1, Dot d2)
        {
            return new Dot(d1.x - d2.x, d1.y - d2.y);
        }
        #endregion
        #region Dot = Dot - float
        public static Dot operator -(Dot d1, float f)
        {
            return new Dot(d1.x - f, d1.y - f);
        }
        #endregion
        #region Dot = float - Dot
        public static Dot operator -(float f, Dot d1)
        {
            return new Dot(f - d1.x, f - d1.y);
        }
        #endregion
        #endregion
        #region *
        #region Dot = Dot * Dot
        public static Dot operator *(Dot d1, Dot d2)
        {
            return new Dot(d1.x * d2.x, d1.y * d2.y);
        }
        #endregion
        #region Dot = Dot * float
        public static Dot operator *(Dot d1, float f)
        {
            return new Dot(d1.x * f, d1.y * f);
        }
        #endregion
        #region Dot = float * Dot
        public static Dot operator *(float f, Dot d1)
        {
            return new Dot(d1.x * f, d1.y * f);
        }
        #endregion
        #endregion
        #region /
        #region Dot = Dot / Dot
        public static Dot operator /(Dot d1, Dot d2)
        {
            return new Dot(d1.x / d2.x, d1.y / d2.y);
        }
        #endregion
        #region Dot = Dot / float
        public static Dot operator /(Dot d1, float f)
        {
            return new Dot(d1.x / f, d1.y / f);
        }
        #endregion
        #region Dot = float / Dot
        public static Dot operator /(float f, Dot d1)
        {
            return new Dot(f / d1.x, f / d1.y);
        }
        #endregion
        #endregion
        #region Types converter 
        #region SystemDrawing_PointConverter
#if (SystemDrawing_PointConverter)
        #region implicit from Dot to PointF
        public static implicit operator PointF(Dot d)
        {
            return new PointF(d.x, d.y);
        }
        #endregion
        #region implicit from Dot to Point
        public static implicit operator Point(Dot d)
        {
            return new Point((int)System.Math.Round(d.x), (int)System.Math.Round(d.y));
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
            float xcord = (d1.x - d2.x);
            float ycord = (d1.y - d2.y);
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
            if (fta + 1 >= t1a + t2a + t3a) // костыль, хз почему +1
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
        #region public static Dot StraightLineIntersect(Dot p11, Dot p12, Dot p21, Dot p22)
        public static Dot StraightLineIntersect(Dot A, Dot B, Dot C, Dot D)
        {
            float a = A.x - B.y;
            float b = B.x - A.x;
            float c = A.x * B.y - B.x * A.y;

            float d = C.x - D.y;
            float e = D.x - C.x;
            float f = C.x * D.y - D.x * C.y;

            if (a != 0 && a * e - d * b != 0)
            {
                float y = (d * c - f * a) / (a * e - d * b);
                float x = (-c - b * y) / a;

                return new Dot(x, y);
            }
            return new Dot(0f, 0f);
        }
        #endregion
    }
    #endregion
}
