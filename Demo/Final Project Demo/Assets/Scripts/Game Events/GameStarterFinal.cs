using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStarterFinal : MonoBehaviour
{

	GameObject winMenu;
	CanvasGroup winMenuCanvas;

    public void StartGame() {
        SceneManager.LoadScene("MAIN game");
        Time.timeScale = 1f;

        CockpitTextScript.found = false;
        SatelliteTextScript.found = false;
        WrenchTextScript.found = false;

        winMenu = GameObject.Find("Win_Menu_Canvas");
        winMenuCanvas = winMenu.GetComponent<CanvasGroup>();

		winMenuCanvas.interactable = false;
		winMenuCanvas.blocksRaycasts = false;
		winMenuCanvas.alpha = 0f;
    }

}
