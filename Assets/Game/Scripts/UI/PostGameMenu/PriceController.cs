using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PriceController : MonoBehaviour
{
    private TextMeshProUGUI buttonText;
    // Start is called before the first frame update
    void Start()
    {
        buttonText = gameObject.GetComponent<TextMeshProUGUI>(); 
        buttonText.text = "" + ButtonController.MoneyToBuy(gameObject.name);
    }
}
