using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class WinMenuToggle : MonoBehaviour
{

	private GameObject UI;
	private GameObject UI2;
	private CanvasGroup canvasGroup;

    void Awake() {
    	canvasGroup = GetComponent<CanvasGroup>();

    	if (canvasGroup == null)
            Debug.Log("Canvas Group could not be found");
    }

    void Update() {
    	if (CockpitTextScript.getFoundStatus() && SatelliteTextScript.getFoundStatus() && WrenchTextScript.getFoundStatus()) {

    			// When win state occurs, disable other UI Components
    			UI = GameObject.Find("DayTime System");
    			UI2 = GameObject.Find("Terrain (1)");
    			UI2.GetComponent<DayAndNightControl>().enabled = false;
    			UI.SetActive(false);

    			// Create a main menu option for the player
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f;
		}		 
    }
}
