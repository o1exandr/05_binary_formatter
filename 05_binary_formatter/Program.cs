/*
 5.    Зберегти і завантажити масив(або List<>)  студентів(працівників чи ін) за допомогою BinaryFormatter'а.
  
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _05_binary_formatter
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name:\t{Name}\tAge:\t{Age}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student("John", 17));
            list.Add(new Student("Ted", 40));
            list.Add(new Student("Will", 25));

            string filename = "student.dat";

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                
                formatter.Serialize(fs, list);
                Console.WriteLine($"\n\tSave to {filename}");
                foreach (var l in list)
                    Console.WriteLine(l);
            }

            using (FileStream fs = new FileStream("student.dat", FileMode.OpenOrCreate))
            {
                Console.WriteLine($"\n\tLoad from {filename}");
                List<Student> deserilizeStudent = (List<Student>)formatter.Deserialize(fs);
                foreach (Student d in deserilizeStudent)
                {
                    Console.WriteLine(d);
                }
            }

            Console.ReadKey();
        }
    }
}
