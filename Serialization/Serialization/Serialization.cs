using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1
{
    class Food
    {
        static void main(string[] args)
        {
            Fruits fruits = new Fruits() { Name = " Manggo", Taste = "Sweet " };
            string filepath = "Save Data";
            DataSerializer dataSerializer = new DataSerializer();
            Fruits f = null;

            dataSerializer.BinarySerialize(fruits, filePath);

            f = dataSerializer.BinarySerialize(filePath) as Fruits;

            Console.WriteLine(f.Name);
                Console.WriteLine(f.Taste); 





            Console.ReadLine(); 
        }
    }

    [Serializable]
    public class Fruits
    {
        public string Name { get; set; }
        public string Taste { get; set; }
    }

    class DataSerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter bifor = new BinaryFormatter();
            if (File.Exists(filePath)) File.Delete(filePath);
            fileStream = File.Create(filePath);
            bifor.Serialize(fileStream, data);
            fileStream.Close(); 

        }
        public object BinaryDeserialize(string filePath)
        {
            object obj = null;

            FileStream fileStream;
            BinaryFormatter bifor = new BinaryFormatter();
            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = bifor.Deserialize(fileStream);
                fileStream.Close(); 

            }
            return obj;
        }
    }
}