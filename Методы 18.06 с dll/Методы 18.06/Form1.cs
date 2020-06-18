using System;
using System.Drawing;
using System.Windows.Forms;
using static Lib1.Class1;

namespace Методы_18._06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Point A, B, C, D, E, F;
        public Bitmap bmp;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                if (tb.Text.Length == 2 && tb.Text.Length <= 2)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Два треугольника заданы координатами своих вершин. Выяснить, лежит ли какой-либо треугольник целиком внутри другого.(Определить процедуру позволяющую определить лежат ли две точки в одной полуплоскости относительно заданной прямой)", "Задание:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public Graphics g;
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            // 1 треугольнитк
            g.DrawLine(Pens.Black, A, B);
            g.DrawLine(Pens.Black, B, C);
            g.DrawLine(Pens.Black, A, C);

            // 2 треугольнитк
            g.DrawLine(Pens.Red, D, E);
            g.DrawLine(Pens.Red, E, F);
            g.DrawLine(Pens.Red, F, D);

            pictureBox1.Invalidate();


            bool resultTochka1 = false;
            bool resultTochka2 = false;
            bool resultTochka3 = false;
            Proverka(A, B, C, D, out resultTochka1);
            Proverka(A, B, C, D, out resultTochka2);
            Proverka(A, B, C, D, out resultTochka3);
            if(resultTochka1 && resultTochka2 && resultTochka3) { MessageBox.Show("Верно! Треугольник №2 лежит в треуголнике №1", "Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else { MessageBox.Show("Неверно! Треугольник №2 не лежит в треуголнике №1", "Ответ:", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (groupBox1.Text == "Координаты 1-го треугольника")
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
                    button2.Enabled = true;
                }
            }
            catch { MessageBox.Show("Неверный ввод координат!\nПопробуйте снова", "Ошибка:", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
