using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataManagement
{
    public class LevelTester : MonoBehaviour
    {
        [SerializeField] DataManager _dataManager;
        // could get this from UI input field
        [SerializeField] string _fileName = "Adam";

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _dataManager.Save(_fileName);

            if (Input.GetKeyDown(KeyCode.W))
                _dataManager.Load(_fileName);

            if (Input.GetKeyDown(KeyCode.Z))
                _dataManager.PlayerLevel = 10;

            if (Input.GetKeyDown(KeyCode.X))
                _dataManager.PlayerName = "JimTheDestroyer";

            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Name: " + _dataManager.PlayerName
                    + ", Level: " + _dataManager.PlayerLevel);
        }
    }
}

