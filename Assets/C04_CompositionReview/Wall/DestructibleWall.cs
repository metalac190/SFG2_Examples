using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Composition
{
    public class DestructibleWall : MonoBehaviour, IDamageable
    {
        public void Kill()
        {
            Debug.Log("Destroyed this wall!");
        }

        public void TakeDamage(int amount)
        {
            Debug.Log("Load damaged wall mesh");
        }
    }
}

