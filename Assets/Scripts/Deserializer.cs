using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class Deserializer<T>
{
    /// <summary>
    /// Task to make a deserializer to load in all cards
    /// I think Matthew wanted all the cards have monobehavior with them.
    /// All cards have Reward, CardType, Info, Name, Description, Power
    /// 
    /// So I want to open the file that contains all xml files
    /// After I open it, I must load/save them to a list
    /// </summary>
   
    public T Deserialization(string cardName) // Load Data
    {
        string path = @"Assets\Resources\" + cardName + ".xml";

        FileStream fs;

        if (!File.Exists(path)) // if the path doesn't exist
            File.Create(path).Close(); // created the path, and closes it.

        fs = File.OpenRead(path); // opens file for reading

        XmlSerializer deserializer = new XmlSerializer(typeof(T));
        T t = (T)deserializer.Deserialize(fs);
        fs.Close();

        return t;
    }
}
