using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaschetRiska
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Кража";
            comboBox1.Text = "1";
            comboBox2.Text = "2";
            comboBox3.Text = "4";
            comboBox4.Text = "5";
            comboBox5.Text = "3";
            comboBox6.Text = "3";
            comboBox7.Text = "3";

            //Требования РФ
            comboBox8.Text = "1";
            comboBox9.Text = "1";
            comboBox10.Text = "0";
            comboBox11.Text = "1";
            comboBox12.Text = "1";
            comboBox13.Text = "1";
            comboBox14.Text = "1";
            comboBox15.Text = "1";
            comboBox16.Text = "1";
            comboBox17.Text = "1";
            comboBox18.Text = "1";
            comboBox19.Text = "1";
            
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //Добавить в таблицу
            double sum = Convert.ToDouble(comboBox1.Text) + Convert.ToDouble(comboBox2.Text) +
                Convert.ToDouble(comboBox3.Text) + Convert.ToDouble(comboBox4.Text) +
                Convert.ToDouble(comboBox5.Text) + Convert.ToDouble(comboBox6.Text) +
                Convert.ToDouble(comboBox7.Text);

            dataGridView1.Rows.Add(textBox1.Text, comboBox1.Text,
                comboBox2.Text, comboBox3.Text, comboBox4.Text, comboBox5.Text,
                comboBox6.Text, comboBox7.Text, sum);
            //Отчистить поля
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            listBox1.Items.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            double max = Convert.ToDouble(dataGridView1.Rows[0].Cells[8].Value.ToString());
            int count = 0;
            for (int i = 0; i < dataGridView1.Rows.Count - 2; ++i)
            {
                if (max < Convert.ToDouble(dataGridView1.Rows[i + 1].Cells[8].Value.ToString()))
                {
                    max = Convert.ToDouble(dataGridView1.Rows[i+1].Cells[8].Value.ToString());
                    count = i+1;
                }
            }
            listBox1.Items.Add(dataGridView1.Rows[count].Cells[0].Value.ToString() 
                + ". Суммарный критерий равен: "
                + dataGridView1.Rows[count].Cells[8].Value.ToString());
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            double riskRF = 0.5;
            double sumOrgTr = Convert.ToDouble(comboBox8.Text)+Convert.ToDouble(comboBox9.Text) 
                + Convert.ToDouble(comboBox10.Text) + Convert.ToDouble(comboBox11.Text) 
                + Convert.ToDouble(comboBox12.Text) + Convert.ToDouble(comboBox13.Text) 
                + Convert.ToDouble(comboBox14.Text) + Convert.ToDouble(comboBox15.Text)
                + Convert.ToDouble(comboBox16.Text) + Convert.ToDouble(comboBox17.Text)
                + Convert.ToDouble(comboBox18.Text) + Convert.ToDouble(comboBox19.Text);
            if (sumOrgTr >= 10 & sumOrgTr <= 15)
                riskRF = 0.5;
            else riskRF = 0.25;
            label22.Text = label22.Text + riskRF;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Угрозы и вероятности
            dataGridView2.Rows.Add(textBox2.Text, comboBox20.Text);

            //Добавить угрозы
            dataGridView4.Rows.Add(textBox2.Text);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //Актив и стоимость
            dataGridView3.Rows.Add(textBox3.Text, comboBox21.Text);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //Рассчет Актив и стоимость
            double summ = 0, cennost=0;
            for (int i = 0; i < dataGridView3.Rows.Count - 1; ++i)
            {
                summ = summ + Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value.ToString());
            }
            for (int i = 0; i < dataGridView3.Rows.Count - 1; ++i)
            {
                cennost = summ/Convert.ToDouble(dataGridView3.Rows[i].Cells[1].Value.ToString());
                dataGridView3.Rows[i].Cells[2].Value = Convert.ToString(cennost);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            //Организационные меры
            if (Convert.ToDouble(textBox4.Text) >= 10 & Convert.ToDouble(textBox4.Text) <= 15)
                label30.Text = label30.Text + "0,5";
            else 
                label30.Text = label30.Text + "0,25";
        }
        private void button8_Click(object sender, EventArgs e)
        {
            //Технические меры
            if (Convert.ToDouble(textBox5.Text) >= 10 & Convert.ToDouble(textBox5.Text) <= 15)
                label33.Text = label33.Text + "0,5";
            else
                label33.Text = label33.Text + "0,9";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //Рассчитать риск
            double KK = ((0.5 + 0.9) / 2) * 100;
            double С = 1.1;

            for (int i = 0; i < dataGridView4.Rows.Count - 1; ++i)
            {
                double Risk = Convert.ToDouble(dataGridView2.Rows[i].Cells[1].Value.ToString())*
                    С * 0.5 * KK;
                dataGridView4.Rows[i].Cells[1].Value = Convert.ToString(Risk);
            }

            

        }
        private void button10_Click(object sender, EventArgs e)
        {
            double max = Convert.ToDouble(dataGridView4.Rows[0].Cells[1].Value.ToString());
            int count = 0;
            for (int i = 0; i < dataGridView4.Rows.Count - 1; ++i)
            {
                if (max < Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value.ToString()))
                {
                    max = Convert.ToDouble(dataGridView4.Rows[i].Cells[1].Value.ToString());
                    count = i;
                }
            }
            label36.Text = label36.Text + dataGridView4.Rows[count].Cells[0].Value.ToString()
                + " (" + max + ")";
        }
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void comboBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

       
    }
}
