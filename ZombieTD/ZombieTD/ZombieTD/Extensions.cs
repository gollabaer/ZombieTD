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

        public static bool SaveToFilename(this string fileContents, string fileName)
        {
            bool IsOKay;

            try
            {
                System.IO.File.WriteAllText(fileContents, fileName);
                IsOKay = true;
            }
            catch (Exception ex)
            {
                IsOKay = false;
                Logger.Log(Logger.Log_Type.ERROR, "Error Saving File " + ex.Message);
            }

            return IsOKay;
        }

        public static string ToCharacterTextureFilename<T>(this T item)
        {

            return EngineConstants.CharacterImageLocation + item.ToString();
        }

        public static string ToSoundFileFilename<T>(this T item)
        {
            return EngineConstants.SoundFileLocation + item.ToString();
        }

        public static string ToStructureTextureFileFilename<T>(this T item)
        {
            return EngineConstants.StructureImageLocation + item.ToString();
        }

        public static string ToEffectTextureFileFilename<T>(this T item)
        {
            return EngineConstants.EffectImageLocation + item.ToString();
        }

        public static string ToMapTileTextureFileFilename<T>(this T item)
        {
            return EngineConstants.MapTilesImageLocation + item.ToString();
        }

        public static string ToMenuTextureFileFilename<T>(this T item)
        {
            return EngineConstants.MenuImageLocation + item.ToString();
        }

        public static string ToMusicFileFilename<T>(this T item)
        {
            return EngineConstants.MusicFileLocation + item.ToString();
        }

        public static void Shuffle<T>(this List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
