using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsufficientCurrencyScript : MonoBehaviour
{
    private Text icText;
    // Start is called before the first frame update
    void Start()
    {
        icText = GetComponent<Text>() as Text;
        icText.text = "You don't have enough Moon Stones for this";
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrencyScript.noMoney) {
            icText.enabled = true;
        } else {
            icText.enabled = false;
        }
    }
}
