using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace DataManagement
{
    // note this does not have to be MB,
    // just doing it for easier example
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;

        #region SaveData Accessors
        public string PlayerName
        {
            get => _saveData.PlayerName;
            set
            {
                // optionally validate data
                _saveData.PlayerName = value;
            }
        }
        public int PlayerLevel
        {
            get => _saveData.PlayerLevel;
            set
            {
                value = Mathf.Clamp(value, 1, 99);
                _saveData.PlayerLevel = value;
            }
        }
        #endregion

        private static readonly string _localSaveDirectory = "/saves/";
        private static readonly string _extension = ".sav";

        public static string GetSaveDirectory()
        {
            string saveDirectory = Application.persistentDataPath
                + _localSaveDirectory;

            return saveDirectory;
        }

        public static string GetSaveFilePath(string fileName)
        {
            string saveFilePath = Application.persistentDataPath
                + _localSaveDirectory + fileName + _extension;
            Debug.Log("SaveFile Path: " + saveFilePath);

            return saveFilePath;
        }

        private void Awake()
        {
            // initialize new save data
            _saveData = new SaveData();
            Debug.Log("Save File Path: "
                + Application.persistentDataPath);
            // create /saves/ directory, if it does not already exist
            if (!Directory.Exists(GetSaveDirectory()))
            {
                Directory.CreateDirectory(GetSaveDirectory());
            }
        }

        public void Save(string fileName)
        {
            FileSaver.Save(_saveData, GetSaveFilePath(fileName));
            Debug.Log("Data saved");
        }

        public void Load(string fileName)
        {
            FileSaver.Load(_saveData, GetSaveFilePath(fileName));
        }
    }
}

