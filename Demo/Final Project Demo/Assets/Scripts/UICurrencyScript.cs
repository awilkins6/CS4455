using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICurrencyScript : MonoBehaviour
{
    private Text currencyText;

    public int currency;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = currency.ToString();
    }

    void IncrementCurrency() {
        currency++;
    }
}
