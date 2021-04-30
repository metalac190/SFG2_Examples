using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class Blue : ICommand
    {
        Light _light;
        float _duration;
        MonoBehaviour _coroutineOwner;  // use this to house coroutines

        Coroutine _displayRoutine;

        public Blue(Light light, float duration,
            MonoBehaviour coroutineOwner)
        {
            _light = light;
            _duration = duration;
            _coroutineOwner = coroutineOwner;
            // set default color
            _light.enabled = false;
            _light.color = Color.blue;
        }

        public void Execute()
        {
            Debug.Log("Blue");
            if (_displayRoutine != null)
                _coroutineOwner.StopCoroutine(_displayRoutine);
            _displayRoutine = _coroutineOwner
                .StartCoroutine(DisplayRoutine(_duration));
        }

        IEnumerator DisplayRoutine(float duration)
        {
            _light.enabled = true;
            yield return new WaitForSeconds(duration);
            _light.enabled = false;
        }
    }
}

