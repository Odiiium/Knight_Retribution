using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopCountController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyCount;
    [SerializeField] TextMeshProUGUI adsCount;

    private void Start()
    {
        moneyCount.text = PlayerPrefs.GetInt("money") + "";
        adsCount.text = "" + PlayerPrefs.GetInt("adsWatched");
    }
}
