using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyScript : MonoBehaviour
{
    private Text currencyText;
    private Text moneyAlert;

    public static int cost = 0;
    public static int currency = 3;
    public static int noMoney = 0;
    public static string selectedItem = "";

    GameObject ship;
    GameObject player;
    GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        currencyText = GetComponent<Text>() as Text;
        moneyAlert = GameObject.Find("ic_Text").GetComponent<Text>(); 
        ship = GameObject.FindWithTag("Ship");
        player = GameObject.FindWithTag("Player");
        turret = GameObject.FindWithTag("Turret(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyText) {
            currencyText.text = "Moon Stones: " + currency.ToString();
        }
        needMoney();
    }

    public void setCost(int itemCost) {
        cost = itemCost;
    }

    public void setItem(string item) {
        selectedItem = item;
    }

    public void needMoney() {
        if (noMoney == 1)
        {
            moneyAlert.text = "You don't have enough Moon Stones for this.";
        } else if (noMoney == 2) {
            moneyAlert.text = "Upgraded!";
        } else {
            moneyAlert.text = "";
        }
    }

    public void buyItem() {
        if (currency > 0) {
            noMoney = 0;
        }

        if ((currency - cost) >= 0) {
            currency -= cost;
            //if (currency == 0) {
            //  noMoney = true;
            //}
            Debug.Log("Item Bought: " + selectedItem);

            switch (selectedItem) {
              case "Health":
                    noMoney = 2;
                Debug.Log("replenish ship health");
                ship.GetComponent<ShipHealth>().doDamage(-30);
                break;
              case "Speed":
                    noMoney = 2;
                player.GetComponent<PlayerController>().maxSpeed = player.GetComponent<PlayerController>().maxSpeed * 1.5f;
                break;
              case "Jump":
                    noMoney = 2;
                player.GetComponent<PlayerController>().jumpPower += 200f;
                break;
                case "Damage":
                    noMoney = 2;
                    Debug.Log("increased turret damage by 2");
                    turret.GetComponent<TurretScript>().alienDamage += 2f;
                    break;
              default:
                Debug.Log("nothing purchased");
                break;
            }

        } else {
            noMoney = 1;
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
