using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace xmlparser
{
    class Program
    {
        static void InvalidInput() {
            Console.WriteLine("Command was not found");
        }

        static void AddHandler (string name, string price) {
            XmlDocument xmlDoc = new XmlDocument();
            string path = Directory.GetCurrentDirectory()+ @"/data.xml";
            xmlDoc.Load(path);
            XmlNode root = xmlDoc.FirstChild;
            XmlElement foodElem = xmlDoc.CreateElement("food");
            XmlElement nameElem = xmlDoc.CreateElement("name");
            XmlElement priceElem = xmlDoc.CreateElement("price");
            XmlText nameText = xmlDoc.CreateTextNode(name);
            XmlText priceText = xmlDoc.CreateTextNode(price);

            //Add nodes
            nameElem.AppendChild(nameText);
            priceElem.AppendChild(priceText);
            foodElem.AppendChild(nameElem);
            foodElem.AppendChild(priceElem);
            root.AppendChild(foodElem);
            xmlDoc.Save(path);
            Console.WriteLine("New item successfully added");
        }

        static void AddPosition () {
            Console.WriteLine("Enter a name to create a new item:");
            string name = Console.ReadLine(); 
            Console.WriteLine("Enter a price for a new item:");
            string price = Console.ReadLine();
            AddHandler(name, price);
        }

        static void DeletePosition () {
            Console.WriteLine("Enter the item number to delete:");
            int num = Convert.ToInt32(Console.ReadLine());
            XmlDocument xmlDoc = new XmlDocument();
            string path = Directory.GetCurrentDirectory()+ @"/data.xml";
            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("food");
            XmlNode root = xmlDoc.FirstChild;
            XmlNode node = list[num-1];
            if (node!=null) {
            root.RemoveChild(node);
            xmlDoc.Save(path);
            Console.WriteLine("Item was successfully deleted");
            } 
            else {
            Console.WriteLine("Index was not found");
            }
        }

        static void Main(string[] args)
        {
            string command="";
            while (command!="exit") {
            Console.WriteLine("Input the command:");
            command = Console.ReadLine();
            switch (command) 
            {
                default : InvalidInput(); break;
                case "menu" : Menu.ShowMenu(); break;
                case "add" : AddPosition(); break;
                case "delete" : DeletePosition(); break;
                case "exit" : break;
            };
            };    
        }
    }
}
