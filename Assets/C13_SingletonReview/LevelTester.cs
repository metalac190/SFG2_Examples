using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class LevelTester : MonoBehaviour
    {
        [SerializeField] AudioClip _musicA;
        [SerializeField] AudioClip _musicB;
        [SerializeField] float _fadeDuration = 2.5f;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                MusicPlayer.Instance.Play(_musicA);

            if (Input.GetKeyDown(KeyCode.W))
                MusicPlayer.Instance.Play(_musicB);

            if (Input.GetKeyDown(KeyCode.Space))
                MusicPlayer.Instance.Stop(_fadeDuration);
        }
    }
}

