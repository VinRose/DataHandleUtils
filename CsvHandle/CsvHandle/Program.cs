using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; // Regexクラスを使用する
using System.Text;

namespace CsvHundle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ReadData = new Data();

            string path = @"data.csv";

            IEnumerable<string> data = System.IO.File.ReadLines(path);

            string pattern = @"#(\w*,\s\w*)+#";
            var rep = new Regex(pattern);

            var dataShaped = data.Where(line => line.Contains('"'))
                            .Select(line => line.Replace('"', '#'))
                            .Select(line => rep.Replace(line, evaluator))
                            .Select(line => line.Split(","));
                                    
            string evaluator(Match strMatched){
                
                var strDeleteComma = strMatched.Value.Replace(",", "&");
                var strDeleteSharp = strDeleteComma.Replace("#", "");
                var strTrimSpace = strDeleteSharp.Replace(" ", "");

                return strTrimSpace;
            }


            foreach(var strArray in dataShaped){
                foreach (var str in strArray)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }

    class Data
    {

        //public Data()
        //{
        //    ReadCsv();
        //}

        public static List<Person> p = new List<Person>();
        //public static void ReadCsv()
        //{
        //    using (var sr = new System.IO.StreamReader(@"data.csv"))
        //    {
        //        sr.ReadLine();
        //        while (!sr.EndOfStream)
        //        {
        //            var temp = new Person();
        //            var line = sr.ReadLine();
        //            var values = line.Split(',');

        //            temp.Num = values[0];
        //            temp.Name = values[1];
        //            temp.Sex = values[2];
        //            temp.Age = values[3];
        //            p.Add(temp);
        //        }
        //    }
        //    Console.WriteLine("{0}", p[0].Name);
        //    Console.WriteLine("{0}", p[1].Name);
        //    Console.WriteLine("{0}", p[2].Name);
        //}

    }

    class Person
    {
        public string Num { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }

    }
}
