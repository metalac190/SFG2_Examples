using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    public class LevelTester : MonoBehaviour
    {
        [SerializeField] DialogueView _dialogueView;
        [SerializeField] DialogueData _dialogue01;
        [SerializeField] DialogueData _dialogue02;
        [SerializeField] DialogueData _dialogue03;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _dialogueView.Display(_dialogue01);
            if (Input.GetKeyDown(KeyCode.W))
                _dialogueView.Display(_dialogue02);
            if (Input.GetKeyDown(KeyCode.E))
                _dialogueView.Display(_dialogue03);
        }
    }
}

