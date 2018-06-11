using System;
using System.Collections.Generic;

namespace CsvHundle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var ReadData = new Data();
        }
    }

    class Data : Person
    {

        public Data()
        {
            ReadCsv();
        }

        public static List<Person> p = new List<Person>();

        public static void ReadCsv()
        {
            using (var sr = new System.IO.StreamReader(@"data.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var temp = new Person();
                    var line = sr.ReadLine();
                    var values = line.Split(',');

                    temp.Num = values[0];
                    temp.Name = values[1];
                    temp.Sex = values[2];
                    temp.Age = values[3];
                    p.Add(temp);
                }
            }
            Console.WriteLine("{0}", p[0].Name);
            Console.WriteLine("{0}", p[1].Name);
            Console.WriteLine("{0}", p[2].Name);
        }

    }

    class Person
    {
        public string Num { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }

    }
}
