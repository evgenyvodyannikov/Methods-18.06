using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib1
{
    public class Class1
    {
        public static bool Proverka(Point A, Point B, Point C, Point D, out bool result) // D - точка для проверки
        {
            result = false;
            if ((A.Y - B.Y) * D.X + (B.X - A.X) * D.Y + (A.X * B.Y - B.X * A.Y) <= 0) // проверка лежит ли точка D за отрезком AB
            {
                if ((B.Y - C.Y) * D.X + (C.X - B.X) * D.Y + (B.X * C.Y - C.X * B.Y) <= 0)  // проверка лежит ли точка D за отрезком BC
                {
                    if ((C.Y - A.Y) * D.X + (A.X - C.X) * D.Y + (C.X * A.Y - A.X * C.Y) <= 0) // проверка лежит ли точка D за отрезком AC
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
