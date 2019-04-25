using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    private Text currencyText;

    public static int cost = 0;
    public static int currency = 3;
    public static bool noMoney = false;
    public static string selectedItem = "";

    GameObject ship;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currencyText = GetComponent<Text>() as Text;
        ship = GameObject.FindWithTag("Ship");
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyText) {
            currencyText.text = ": " + currency.ToString();
        }
    }

    public void setCost(int itemCost) {
        cost = itemCost;
    }

    public void setItem(string item) {
        selectedItem = item;
    }

    public void buyItem() {
        if (currency > 0) {
            noMoney = false;
        }

        if ((currency - cost) >= 0) {
            GameManagerScript2.toggleBuy();
            currency -= cost;
            if (currency == 0) {
              noMoney = true;
            }
            Debug.Log("Item Bought: " + selectedItem);

            switch (selectedItem) {
              case "Health":
                Debug.Log("replenish ship health");
                ship.GetComponent<ShipHealth>().doDamage(-30);
                break;
              case "Speed":
                player.GetComponent<PlayerController>().maxSpeed = player.GetComponent<PlayerController>().maxSpeed * 1.5f;
                break;
              default:
                Debug.Log("nothing purchased");
                break;
            }
            

        } else {
            noMoney = true;
        }
    }

    private static int turretPrice = 1;

    public static bool buyTurret() {
      if (currency - turretPrice >= 0) {
        currency -= turretPrice;
        return true;
      }
      return false;
    }
}
