using System.Xml.Serialization;

namespace serialization
{

    [XmlRoot("Data.Root")]
    public class DataRoot
    {
        [XmlArray("Data.Root.Names")]
        [XmlArrayItem("Name")]
        public string[] Names;

        [XmlElement("Data.Entry")]
        public DataEntry Entry;

        [XmlElement("Data#ExtendedEntry")]
        public DataX Ext;
    }



    [XmlType("Data.Entry")]
    public class DataEntry
    {
        [XmlAttribute]
        public string LinkedEntry;
        [XmlElement("Data.Name")]
        public string Name;
    }

    [XmlType("Data#ExtendedEntry")]
    public class DataX : DataEntry
    {
        /*[XmlAttribute]
        public string LinkedEntry;
        [XmlElement("Data.Name")]
        public string Name;*/
        [XmlElement("Data.x0023_Extended")]
        public string DataExt;
    }




    internal class Program
    {
        static void Main(string[] args)
        {
            var dataRoot = new DataRoot();

            dataRoot.Names = new string[] 
            {
                "Name1", 
                "Name2", 
                "Name3"
            };

            dataRoot.Entry = new DataEntry();
            dataRoot.Entry.LinkedEntry = "Name1";
            dataRoot.Entry.Name = "Name2";

            dataRoot.Ext = new DataX();
            dataRoot.Ext.LinkedEntry = "Name2";
            dataRoot.Ext.Name = "Name1";
            dataRoot.Ext.DataExt = "NameOne";

            var serializer = new XmlSerializer(typeof(DataRoot));
            serializer.Serialize(Console.Out, dataRoot);
        }
    }
}