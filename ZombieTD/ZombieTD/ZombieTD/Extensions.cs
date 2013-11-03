using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ZombieTD
{
    public static class Extensions
    {
        public static string ToXML<T>(this T value)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(stringwriter, value);
            return stringwriter.ToString();
        }

        public static Map LoadFromXMLString(this string xmlText)
        {
            var stringReader = new System.IO.StringReader(xmlText);
            var serializer = new XmlSerializer(typeof(Map));
            return serializer.Deserialize(stringReader) as Map;
        }

        public static string LoadFromFilename(this string fileName)
        {
            string output = null;
            try
            {
                output = System.IO.File.ReadAllText(@"Map.txt");
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Log_Type.ERROR, "Error Opening File " + ex.Message);
            }
      
            return output;           
        }

        public static bool SaveToFilename(this string fileName)
        {
            bool IsOKay;

            try
            {
                System.IO.File.WriteAllText(@"Map.txt", fileName);
                IsOKay = true;
            }
            catch (Exception ex)
            {
                IsOKay = false;
                Logger.Log(Logger.Log_Type.ERROR, "Error Saving File " + ex.Message);
            }

            return IsOKay;
        }

        public static string ToWaveFilename<T>(this T item)
        {

            return "SoundFX/" + item.ToString();//+(".wav");
        }
    }
}
