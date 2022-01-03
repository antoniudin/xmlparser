using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace xmlparser
{
    class Menu 
    {
        internal static void ShowMenu() {
            //Load the document
            XmlDocument xmlDoc = new XmlDocument();
            string path = Directory.GetCurrentDirectory()+ @"/data.xml";
            xmlDoc.Load(path);
            XmlNodeList list = xmlDoc.GetElementsByTagName("food");
            //Create the list of menu items
            List<Position> menu = new List<Position>();
            //Read data from xml and populate the menu
            foreach(XmlNode node in list) {
            var position = new Position();
                foreach (XmlElement childNode in node.ChildNodes) {
                    if (childNode.Name=="name") position.Name=childNode.InnerText;
                    if (childNode.Name=="price") position.Price=childNode.InnerText; 
                }     
                menu.Add(position);
            }
            //Print the menu
            foreach (Position position in menu) {
                Console.WriteLine($"{position.Name} {position.Price}");
            }
        }
    }
}