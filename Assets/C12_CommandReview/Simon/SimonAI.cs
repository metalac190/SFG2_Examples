using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class SimonAI : MonoBehaviour
    {
        [SerializeField] Light _greenLight;
        [SerializeField] Light _blueLight;
        [SerializeField] Light _yellowLight;
        [SerializeField] Light _redLight;

        [SerializeField] float _lightDuration = 1;

        List<ICommand> _commands = new List<ICommand>();
        Coroutine _lightSequenceRoutine;

        void Start()
        {
            CreateLightSequence();
            ExecuteCommands();
        }

        private void CreateLightSequence()
        {
            _commands.Add(new DisplayLight(_greenLight, Color.green,
                        _lightDuration, this));
            _commands.Add(new DisplayLight(_blueLight, Color.blue,
                _lightDuration, this));
            _commands.Add(new DisplayLight(_yellowLight, Color.yellow,
                _lightDuration, this));
            _commands.Add(new DisplayLight(_redLight, Color.red,
                _lightDuration, this));
        }

        private void ExecuteCommands()
        {
            if (_lightSequenceRoutine != null)
                StopCoroutine(_lightSequenceRoutine);
            _lightSequenceRoutine = StartCoroutine
                (LightSequenceRoutine(_lightDuration));
        }

        IEnumerator LightSequenceRoutine(float duration)
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                _commands[i].Execute();
                yield return new WaitForSeconds(duration);
            }
        }
    }
}

