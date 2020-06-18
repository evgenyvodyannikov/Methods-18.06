using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Методы_18._06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Point A, B, C, D, E, F;


        static bool Proverka(Point A, Point B, Point C, Point D, out bool result) // D - точка для проверки
        {
            result = false;
            if ((A.Y - B.Y) * D.X + (B.X - A.X) * D.Y + (A.X * B.Y - B.X * A.Y) < 0) // проверка лежит ли точка D за отрезком AB
            {
                if ((C.Y - B.Y) * D.X + (B.X - C.X) * D.Y + (C.X * B.Y - B.X * C.Y) < 0)  // проверка лежит ли точка D за отрезком BC
                {
                    if ((C.Y - A.Y) * D.X + (A.X - C.X) * D.Y + (C.X * A.Y - A.X * C.Y) < 0) // проверка лежит ли точка D за отрезком AC
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool resultTochka1 = false;
            bool resultTochka2 = false;
            bool resultTochka3 = false;
            Proverka(A, B, C, D, out resultTochka1);
            Proverka(A, B, C, D, out resultTochka2);
            Proverka(A, B, C, D, out resultTochka3);
            if(resultTochka1 && resultTochka2 && resultTochka3) { MessageBox.Show("ДА!!!"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(groupBox1.Text == "Координаты 1-го треугольника")
            {
                A.X = Int32.Parse(textBox1.Text);
                A.Y = Int32.Parse(textBox2.Text);
                B.X = Int32.Parse(textBox3.Text);
                B.Y = Int32.Parse(textBox4.Text);
                C.X = Int32.Parse(textBox5.Text);
                C.Y = Int32.Parse(textBox6.Text);
                groupBox1.Text = "Координаты 2-го треугольника";
                label1.Text = "D"; label2.Text = "E"; label3.Text = "F";
            }
            else
            {
                D.X = Int32.Parse(textBox1.Text);
                D.Y = Int32.Parse(textBox2.Text);
                E.X = Int32.Parse(textBox3.Text);
                E.Y = Int32.Parse(textBox4.Text);
                F.X = Int32.Parse(textBox5.Text);
                F.Y = Int32.Parse(textBox6.Text);
                button1.Enabled = false;
            }
        }
    }
}
