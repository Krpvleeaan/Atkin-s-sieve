using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atkina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input;
            richTextBox2.Text = "";
            if (Int32.TryParse(richTextBox1.Text, out input) == false)
            {
                MessageBox.Show("Некорректное число");
                return;
            }
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("Введите число");
                return;
            }
            if (input < 2)
                return;
            if (input == 2)
            {
                richTextBox2.Text += "2";
                return;
            }
            if (input <= 4)
            {
                richTextBox2.Text += "2 3";
                return;
            }
            if (input > 2147483590)
            {
                MessageBox.Show("Вы ввели слишком большое число");
                return;
            }
            DateTime starttime = DateTime.Now;
            int BIGGEST = input; // граница сверху
            int sqr_big = 0; //корень из границы
            bool[] is_prime = new bool[BIGGEST + 1];
            int x2, y2;
            int i, j;
            int n;

            sqr_big = (int)Math.Sqrt((int)BIGGEST);
            for (i = 0; i <= BIGGEST; ++i)
                is_prime[i] = false;
            is_prime[2] = true; 
            is_prime[3] = true;
            // начинаем перебор с пятерки поэтому 2 3 присваиваем true так как они простые
            x2 = 0;
            for (i = 1; i <= sqr_big; ++i)
            {
                x2 += 2 * i - 1;
                y2 = 0;
                for (j = 1; j <= sqr_big; ++j)
                {
                    y2 += 2 * j - 1;
                    n = 4 * x2 + y2;
                    if ((n <= BIGGEST) && (n % 12 == 1 || n % 12 == 5))
                        is_prime[n] = !is_prime[n];
                    n -= x2;
                    if ((n <= BIGGEST) && (n % 12 == 7))
                        is_prime[n] = !is_prime[n];
                    n -= 2 * y2;
                    if ((i > j) && (n <= BIGGEST) && (n % 12 == 11))
                        is_prime[n] = !is_prime[n];
                }
            }
            for (i = 5; i <= sqr_big; ++i)
            {
                if (is_prime[i])
                {
                    n = i * i;
                    for (j = n; j <= BIGGEST; j += n)
                        is_prime[j] = false;
                }
            } // убираем кратные квадраты например 7 * 7 = 49
            richTextBox2.Text += "2 3 5 ";
            StreamWriter wr = new StreamWriter("temp.txt"); // вывод через файл так как быстрее
            for (long k = 7; k <= BIGGEST; k += 2)
            {
                if ((is_prime[k]))
                    wr.Write(k.ToString() + ' ');
            }
            wr.Close();
            StreamReader rd = new StreamReader("temp.txt");
            richTextBox2.Text += rd.ReadToEnd();
            rd.Close();
            MessageBox.Show("Выполнено");
            DateTime endtime = DateTime.Now;
            MessageBox.Show((endtime - starttime).ToString());
        }
    }
}