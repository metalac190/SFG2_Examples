using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class MusicPlayer : MonoBehaviour
    {
        AudioSource _source;

        private static MusicPlayer _instance;
        public static MusicPlayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<MusicPlayer>();
                    if (_instance == null)
                    {
                        GameObject newGameObject = new GameObject
                            ("MusicPlayer (singleton)");
                        _instance = newGameObject.
                            AddComponent<MusicPlayer>();

                        DontDestroyOnLoad(newGameObject);
                    }
                }
                return _instance;
            }
        }

        private void Awake()
        {
            _source = gameObject.AddComponent<AudioSource>();
            _source.spatialBlend = 0;
            _source.playOnAwake = false;
            _source.loop = true;
        }

        public void Play(AudioClip clip)
        {
            _source.clip = clip;
            _source.volume = 1;
            _source.Play();
        }

        public void Stop(float fadeDuration)
        {
            //
            if (_fadeRoutine != null)
                StopCoroutine(_fadeRoutine);
            _fadeRoutine = StartCoroutine(FadeRoutine(fadeDuration));
        }

        Coroutine _fadeRoutine;
        IEnumerator FadeRoutine(float duration)
        {
            float startVolume = _source.volume;
            // for loop continues over specified duration
            for (float elapsedTime = 0; elapsedTime <= duration;
                elapsedTime += Time.deltaTime)
            {
                // new volume is the ratio between elapsed time and distance
                // between start/target
                float newVolume = Mathf.Lerp(startVolume, 0, elapsedTime / duration);
                _source.volume = newVolume;
                // wait for next update frame, so it will animate over time
                yield return null;
            }
            // make sure we hit exact target
            _source.volume = 0;
        }
    }
}

