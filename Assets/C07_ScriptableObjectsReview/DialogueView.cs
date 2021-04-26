using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects
{
    public class DialogueView : MonoBehaviour
    {
        [SerializeField] Text _dialogueTextUI;
        [SerializeField] Text _characterNameTextUI;
        [SerializeField] Image _characterPortraitUI;

        public void Display(DialogueData data)
        {
            _dialogueTextUI.text = data.Dialogue;
            _characterNameTextUI.text = data.CharacterName;
            _characterPortraitUI.sprite = data.Portrait;
        }
    }
}

