using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
	private Text currencyText;

	public static int currency = 0;

    // Start is called before the first frame update
    void Start()
    {
   		currency = 0;
        currencyText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "Moon Stones: " + currency.ToString();
    }
}
