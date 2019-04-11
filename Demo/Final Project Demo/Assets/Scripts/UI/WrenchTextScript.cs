using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrenchTextScript : MonoBehaviour
{
	private Text shipPartsText;

    public static bool found = false;

    // Start is called before the first frame update
    void Start()
    {
        shipPartsText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (found) {
            shipPartsText.color = Color.green;
        } else {
            shipPartsText.color = Color.red;
        }
        shipPartsText.text = "Wrench";
    }

    public static void setToFound() {
        found = true;
    }

    public static bool getFoundStatus() {
        return found;
    }

}
