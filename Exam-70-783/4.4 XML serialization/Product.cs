using System.Xml.Serialization;

namespace _4._4_XML_serialization
{
    public class Product // Class must be public for xml serialization
    {
        //Somente atributos de acesso publicos são serializados
        private int? _id;
        public string name;
        public decimal price;

        [XmlIgnore]
        public string desc
        {
            private get;
            set;
        }

        [XmlIgnore] // id will not be serialized
        public int? id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
