using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class DisplayLight : ICommand
    {
        Light _light;
        Color _color;
        float _duration;
        MonoBehaviour _coroutineOwner;  // use this to house coroutines

        Coroutine _displayRoutine;

        public DisplayLight(Light light, Color color, float duration,
            MonoBehaviour coroutineOwner)
        {
            _light = light;
            _color = color;
            _duration = duration;
            _coroutineOwner = coroutineOwner;
            // set default color
            _light.enabled = false;
            _light.color = color;
        }

        public void Execute()
        {
            Debug.Log(_color.ToString());

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

