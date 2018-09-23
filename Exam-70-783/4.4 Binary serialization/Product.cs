using System;


namespace _4._4_Binary_serialization
{
    [Serializable]
    class Product
    {
        [NonSerialized] // Prevent _id field from being serialized
        private int? _id;
        public string name;
        public decimal price;

        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
