using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Observer
{
    public class SpawnUI : MonoBehaviour
    {
        [SerializeField] EnemySpawner _spawner;
        [SerializeField] Text _spawnTextUI;

        private void OnEnable()
        {
            _spawner.EnemySpawned += OnEnemySpawned;
        }

        private void OnDisable()
        {
            _spawner.EnemySpawned -= OnEnemySpawned;
        }

        void OnEnemySpawned(Enemy newEnemy)
        {
            _spawnTextUI.text = "Spawned: " + newEnemy.Name;
        }
    }
}

