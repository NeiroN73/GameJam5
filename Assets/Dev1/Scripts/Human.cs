using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : Humanoid
{
    [SerializeField] private List<Sprite> _listEmoji;
    [SerializeField] private GameObject _emoji;

    [SerializeField] private float _emojiDuration;
    [SerializeField] private float _emojiDelay;

    [SerializeField] private float _afraidSpeed;

    [SerializeField] private Exit _exit;

    public void ApplyDamage()
    {
        print("i hited and i human");
        CycleSwitcher.Instance.AddCatchedHumans();
        Destroy(gameObject);
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
            Sprite randomEmoji = _listEmoji[Random.Range(0, _listEmoji.Count)];
            _emoji.GetComponent<Image>().sprite = randomEmoji;

            _emoji.SetActive(true);
            yield return new WaitForSeconds(_emojiDuration);
            _emoji.SetActive(false);
            yield return new WaitForSeconds(_emojiDelay);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            if(_emoji.activeSelf) 
            {
                _speed = _afraidSpeed;
                _currentPoint = _exit.gameObject.transform;
            }
        }
    }
}
