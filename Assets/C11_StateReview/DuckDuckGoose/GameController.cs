using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{
    public class GameController : MonoBehaviour
    {
        GameState _gameState = GameState.Intro;

        [SerializeField] float _chaseDuration = .5f;
        Coroutine _gooseChaseRoutine = null;

        private void Awake()
        {
            _gameState = GameState.Intro;
            Debug.Log("Let the goosing begin");
        }

        private void Start()
        {
            ResetGame();
        }

        void ResetGame()
        {
            _gameState = GameState.Tapping;
            Debug.Log("NEW GAME - Q taps, Space catches goose");
        }

        private void Update()
        {
            // if in tapping state, Q determines Goose
            if (_gameState == GameState.Tapping
                && Input.GetKeyDown(KeyCode.Q))
            {
                DetermineGoose();
            }
            // if in tapping state, Space LOSE
            else if (_gameState == GameState.Tapping
                && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("There's no goose to catch!");
                Lose();
            }
            // if in Goose state, Q LOSE
            else if (_gameState == GameState.GooseChase
                && Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("No time for more tapping!");
                Lose();
            }
            // if in Goose State, Space win
            else if (_gameState == GameState.GooseChase
                && Input.GetKeyDown(KeyCode.Space))
            {
                CatchGoose();
            }
        }

        void DetermineGoose()
        {
            int gooseDecider = UnityEngine.Random.Range(1, 5);
            if (gooseDecider == 1)
            {
                Debug.Log("GOOSE");
                if (_gooseChaseRoutine != null)
                    StopCoroutine(_gooseChaseRoutine);
                _gooseChaseRoutine = StartCoroutine
                    (GooseChaseRoutine(_chaseDuration));
            }
            else
            {
                Debug.Log("Duck.");
            }
        }

        void CatchGoose()
        {
            Debug.Log("You caught the goose!");
            if (_gooseChaseRoutine != null)
                StopCoroutine(_gooseChaseRoutine);
            Win();
        }

        void Lose()
        {
            Debug.Log("Lost to a goose");
            ResetGame();
        }

        void Win()
        {
            Debug.Log("Winner, winner, goose dinner");
            ResetGame();
        }

        IEnumerator GooseChaseRoutine(float duration)
        {
            _gameState = GameState.GooseChase;
            yield return new WaitForSeconds(duration);
            Lose();
        }
    }
}

