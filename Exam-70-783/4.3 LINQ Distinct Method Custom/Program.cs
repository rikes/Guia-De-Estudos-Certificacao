using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._3_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();

            var students = s.listaEstudante;

            var studentQuery2 = from studentb in s.listaEstudante group studentb by studentb.Last[0];

            IEnumerable<string> studentQuery7 = from student in students
                                                where student.Last == "Garcia"
                                                select student.First;

            Console.WriteLine("The Garcias in the class are:");
            foreach (string st in studentQuery7)
            {
                Console.WriteLine(st);
            }

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                                 student.Scores[2] + student.Scores[3]
                select totalScore;

            double averageScore = studentQuery6.Average();
            Console.WriteLine("Class average score = {0}", averageScore);


            var studentQuery8 = from student in students
                                let x = student.Scores[0] + student.Scores[1] +
                                        student.Scores[2] + student.Scores[3]
                                where x > averageScore
                                select new { id = student.ID, score = x };

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score);
            }


            Console.ReadKey();
        }
    }
}
