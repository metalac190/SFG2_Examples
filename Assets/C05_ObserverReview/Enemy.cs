using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Observer
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] string _name = "...";
        [SerializeField] int _damage = 10;

        public string Name => _name;

        private void Awake()
        {
            Debug.Log("New " + _name + " has appeared!");
            Debug.Log(_name + " attacked for " + _damage + " damage.");
        }
    }
}

