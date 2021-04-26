using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Observer
{
    public class EnemySpawner : MonoBehaviour
    {
        public Action<Enemy> EnemySpawned;

        [SerializeField] Enemy _enemyPrefab;
        [SerializeField] Transform _spawnLocation;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                // note, we can also call this from other
                // classes if we wish
                SpawnEnemy(_enemyPrefab, _spawnLocation);
            }
        }

        // spawn a prefab with 'Enemy' component
        public void SpawnEnemy(Enemy enemyPrefab, Transform spawnLocation)
        {
            Enemy newEnemy = Instantiate(enemyPrefab,
                _spawnLocation.position, _spawnLocation.rotation);
            EnemySpawned?.Invoke(newEnemy);
        }
    }
}

