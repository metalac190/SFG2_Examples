using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composition
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        int _health = 100;

        public void TakeDamage(int amount)
        {
            _health -= amount;
            Debug.Log("Enemy remaining health: " + _health);
            // test if Kill()'ed
            if (_health <= 0)
            {
                _health = 0;
                Kill();
            }
        }

        public void Kill()
        {
            Debug.Log("Enemy has been killed!");
            gameObject.SetActive(false);
        }
    }
}

