using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DataManagement
{
    public static class FileSaver
    {
        public static void Save(SaveData data, string filePath)
        {
            // convert data to string
            string json = JsonUtility.ToJson(data);
            // create file on disk
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            // write json to file
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }

        public static bool Load(SaveData data, string targetFilePath)
        {
            Debug.Log("Loading...");
            // if we find it, read from file
            if (File.Exists(targetFilePath))
            {
                using (StreamReader reader = new StreamReader(targetFilePath))
                {
                    string json = reader.ReadToEnd();
                    JsonUtility.FromJsonOverwrite(json, data);
                }
                return true;
            }
            // target file was not found
            else
            {
                return false;
            }
        }

        public static void Delete(string filePath)
        {
            File.Delete(filePath);
        }
    }

}
