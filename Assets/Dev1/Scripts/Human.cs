using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Humanoid
{
    [SerializeField] private GameObject _emoji;

    [SerializeField] private float _emojiDuration;
    [SerializeField] private float _emojiDelay;

    [SerializeField] private float _afraidSpeed;

    [SerializeField] private Exit _exit;

    public void ApplyDamage()
    {
        print("i hited and i human");
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(EmojiDelay());
    }

    private IEnumerator EmojiDelay()
    {
        while(true)
        {
            _emoji.SetActive(true);
            yield return new WaitForSeconds(_emojiDuration);
            _emoji.SetActive(false);
            yield return new WaitForSeconds(_emojiDelay);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            _speed = _afraidSpeed;
            _currentPoint = _exit.gameObject.transform;
        }
    }
}
