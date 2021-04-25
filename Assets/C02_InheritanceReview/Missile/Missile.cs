using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Missile : Projectile
    {
        [Header("Missile Settings")]
        [SerializeField] float _acceleration = .01f;
        [SerializeField] int _damage = 10;

        private void Start()
        {
            TravelSpeed = 0;
        }

        protected override void Move()
        {
            // increase speed
            TravelSpeed += _acceleration;

            base.Move();
            // or optionally we could not call base and just
            // completely change th emovement
        }

        protected override void Impact(Collision otherCollision)
        {
            Debug.Log("Missile deals " + _damage + " damage to " +
                otherCollision.gameObject.name + "!");
            gameObject.SetActive(false);
            // optionally search collision for component with GetComponent
            // other.gameObject.GetComponent<ComponentToSearch>()
        }
    }
}

