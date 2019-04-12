using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    private Text currencyText;

    public static int cost = 0;
    public static int currency = 0;
    public static bool noMoney = false;

    // Start is called before the first frame update
    void Start()
    {
        currency = 0;
        currencyText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyText != null)
        {
            currencyText.text = "Moon Stones: " + currency.ToString();
        }
    }

    public void setCost(int itemCost) {
        cost = itemCost;
    }

    public void buyItem() {
        if (currency > 0) {
            noMoney = false;
        }

        if ((currency - cost) >= 0) {
            currency -= cost;
        } else {
            noMoney = true;
        }
    }
}
