using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    internal class Student : IComparable

    {
        string name;
        int rost;
        int ves;
        public Student(string name, int rost, int ves)
        {
            this.name = name;
            this.rost = rost;
            this.ves = ves;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Rost
        {
            get { return rost; }
            set { rost = value; }
        }
        public int Ves
        {
            get { return ves; }
            set { ves = value; }
        }
        public int CompareTo(object obj)//сравнение
        {
            // приводим переданный объект к типу Student
            Student student = obj as Student;
            // сравниваем текущий объект с переданным объектом по имени, используя метод CompareTo для строк
            return name.CompareTo(student.Name);

        }
    }
}
