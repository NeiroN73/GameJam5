using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueSystem _dialogueSystem;
    [SerializeField] private ReactionEnemy _reactionEnemy;
    [SerializeField] private List<string> _dialogueText;

    private bool _checkTrigger;

    private void Start()
    {
        _dialogueSystem = FindObjectOfType<DialogueSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
            _checkTrigger = true;
            _reactionEnemy.Sight(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _checkTrigger = false;
            _reactionEnemy.Sight(false);
        }
    }

    private void Update()
    {
        if (_checkTrigger && _dialogueSystem._checkKeyEPress == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _dialogueSystem.StopAllCoroutines();
                _dialogueSystem.StartDialogue(_dialogueText);
            }
        }
    }
}
