using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5_Using_Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lendo se um objeto tem um determinado atributo
            Person person = new Person("Joao","Doria");

            if (Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)))
            {
                Console.WriteLine(person.FirstName +"\t"+ person.LastName);
            }
            else
            {
                Console.WriteLine("Objeto não atribuido a serialização");    
            }
            

            Console.ReadKey();
        }
    }
}



[Serializable]
class Person
{
    public Person(string FName, string LName)
    {
        this.FirstName = FName;
        this.LastName = LName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
}



