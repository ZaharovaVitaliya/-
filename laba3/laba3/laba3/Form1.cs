using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace laba3
{
    public partial class Form1 : Form
    {


        ArrayList StudentList, res;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            StudentList = new ArrayList();
            res = new ArrayList();
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int num = dataGridView1.SelectedRows[0].Index;
                StudentList.RemoveAt(num);
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            }
            catch
            {
                MessageBox.Show("Выберите строку!!!!!!!!!!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int Rost = (int)numericUpDown1.Value;
            int Ves = (int)numericUpDown2.Value;
            //Student p = new Student(name, Rost, Ves);
            Student student = new Student(name, Rost, Ves);
            StudentList.Add(student);
            dataGridView1.Rows.Add(name, Rost, Ves);
        }

        private void button3_Click(object sender, EventArgs e)//сортировка
        {
            // создаем новый список для хранения уникальных студентов
            ArrayList uniqueStudents = new ArrayList();
            // перебираем все элементы стека данных
            foreach (Student student in StudentList)
            {
                // проверяем, является ли рост и вес студента уникальными в списке
                if (IsUnique(StudentList, student.Rost, student.Ves))
                {
                    // если да, то добавляем студента в новый список
                    uniqueStudents.Add(student);
                }
            }
            // сортируем
            uniqueStudents.Sort();
            // очищаем dataGridView2 от старых данных
            dataGridView2.Rows.Clear();
            // выводим новый список в dataGridView2
            foreach (Student student in uniqueStudents)
            {
                dataGridView2.Rows.Add(student.Name, student.Rost, student.Ves);
            }
        }

        private bool IsUnique(ArrayList list, int rost, int ves)
        {
            
                // счетчик количества совпадений
                int count = 0;
                // перебираем все элементы списка
                foreach (Student student in list)
                {
                    // если рост и вес совпадают с заданными, то увеличиваем счетчик
                    if (student.Rost == rost && student.Ves == ves)
                    {
                        count++;
                    }
                }
                // если счетчик равен 1, то рост и вес уникальны, иначе нет
                return count == 1;
            

        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
