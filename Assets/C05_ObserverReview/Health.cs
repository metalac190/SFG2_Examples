using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Observer
{
    public class Health : MonoBehaviour
    {
        public event Action<int> Damaged;
        public event Action<int> HealthChanged;
        public event Action Killed;

        int _currentHealth = 100;
        public int CurrentHealth => _currentHealth;

        public void TakeDamage(int amount)
        {
            _currentHealth -= amount;
            Damaged?.Invoke(amount);
            HealthChanged?.Invoke(_currentHealth);
            Debug.Log(gameObject.name
                + " took " + amount + " damage...");
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            Killed?.Invoke();
            Debug.Log(gameObject.name + " has died!");
            gameObject.SetActive(false);
        }

        // input in here JUST for testing - extract later
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TakeDamage(15);
            }
        }
    }
}

