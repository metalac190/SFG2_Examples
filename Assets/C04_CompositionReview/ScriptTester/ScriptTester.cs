using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composition
{
    public class ScriptTester : MonoBehaviour
    {
        // note: in unity we can reference interfaces
        //    in the Inspector
        [SerializeField] Enemy _enemy;
        [SerializeField] DestructibleWall _wall;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                AttemptDamage(_enemy, 15);
            if (Input.GetKeyDown(KeyCode.W))
                AttemptDamage(_wall, 15);
        }

        void AttemptDamage(IDamageable damageableObject, 
            int damageAmount)
        {
            // if it's damageable, damage!
            damageableObject.TakeDamage(damageAmount);
        }
    }
}

