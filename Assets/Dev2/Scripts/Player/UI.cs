using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmproGO;
    [SerializeField] private PickingMoney pickingMoney;

    private int _amountCoins;

    public void Start()
    {
        pickingMoney.OnPickingCoin += UpdateCoinsUI;
    }

    private void UpdateCoinsUI()
    {
        _amountCoins++;
        _tmproGO.text = _amountCoins.ToString();
    }
}
