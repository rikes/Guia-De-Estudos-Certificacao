using System;


namespace _2._4_IComparable
{
    class Person : IComparable
    {
        private int _age;
        public int Age
        {
            get { return _age; }
        }

        public Person(int age)
        {
            _age = age;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Person p = obj as Person;
            if(p == null)
            {
                throw new ArgumentException("Object is not a Person");
            }

            //Ordenação ocorre aqui
            //Caso queiramos o inverso(classificação da idade decremental) 
            //Inverteríamos:
            return p.Age.CompareTo(this._age);
            //return this._age.CompareTo(p._age);
        }
    }
}
