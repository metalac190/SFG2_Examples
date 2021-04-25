using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Observer
{
    public class HealthUI : MonoBehaviour
    {
        [SerializeField] Health _objectWithHealth;
        [SerializeField] Text _healthTextUI;

        string _label = "Health: ";

        private void Awake()
        {
            _healthTextUI.text = _label
                + _objectWithHealth.CurrentHealth.ToString();
        }

        private void OnEnable()
        {
            _objectWithHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _objectWithHealth.HealthChanged -= OnHealthChanged;
        }

        void OnHealthChanged(int newCurrentHealth)
        {
            _healthTextUI.text = _label + newCurrentHealth.ToString();
        }
    }
}

