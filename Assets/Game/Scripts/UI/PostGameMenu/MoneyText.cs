using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyText : MonoBehaviour
{
    internal TextMeshProUGUI moneyText;
    void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        moneyText.text = "" + PlayerPrefs.GetInt("money");
    }
}
