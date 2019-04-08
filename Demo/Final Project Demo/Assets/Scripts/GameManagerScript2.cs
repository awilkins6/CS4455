using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript2 : MonoBehaviour
{
public GameObject NightLight;
	enum GameState{
		START,
		GAME,
		PAUSE,
		WIN,
		LOSE
	};
	GameState gameState;
	float shipHealth;
	GameObject ship;
    // Start is called before the first frame update
    string dayState;
    List<GameObject> aliens = new List<GameObject>();
    List<GameObject> nightLights = new List<GameObject>();
    void Start()
    {
        dayState =  GameObject.Find("Terrain1").GetComponent<DayAndNightControl>().dayState;
        gameState = GameState.GAME;
        shipHealth = GameObject.Find("Ship1").transform.GetChild(0).GetComponent<ShipHealth>().shipHealth;
        Debug.Log("game manager started");
        foreach (Transform child in GameObject.Find("Aliens").transform) {
   			aliens.Add(child.gameObject);
 		}
 		foreach (Transform child in GameObject.Find("NightLights").transform) {
   			nightLights.Add(child.gameObject);
 		}
 		foreach (GameObject l in nightLights) {
 			l.SetActive(false);
 		}
 		foreach (GameObject a in aliens) {
 			a.SetActive(false);
 		}
 		//GameObject.Find("NightLights").SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
    	if (nightLights != null) {
    		Debug.Log("the night lights array has a light" + nightLights.Count);
    	}
    	if (aliens != null) {
    		Debug.Log("the aliens array has an alien" + aliens.Count);
    	}
    	//night lights, currently not in use/working
    	//TODO set active for night light the issue, needs fix
    	dayState =  GameObject.Find("Terrain1").GetComponent<DayAndNightControl>().dayState;
    	if (string.Equals(dayState, "Midnight") || string.Equals(dayState, "Night")) {
    		Debug.Log("LET THERE BE (NIGHT) LIGHT");
    		foreach (GameObject l in nightLights) {
 				l.SetActive(true);
 			}
 			//GameObject.Find("NightLights").SetActive(true);
    		Debug.Log("Aliens ATTACK NOWWWW");
    		foreach (GameObject a in aliens) {
 				a.SetActive(true);
 			}

    	} else {
    		foreach (GameObject l in nightLights) {
 				l.SetActive(false);
 			}
 			//GameObject.Find("NightLights").SetActive(false);
 			foreach (GameObject a in aliens) {
 				a.SetActive(false);
 			}
    	}
    	shipHealth = GameObject.Find("Ship1").transform.GetChild(0).GetComponent<ShipHealth>().shipHealth;
    	Debug.Log("game manager ship health" + shipHealth);
    	Debug.Log("I am THE GAME MANAGER! I AM ALIVE");

    	switch(gameState) {
    		case GameState.START:
    			break;
    		case GameState.GAME:
    			if (shipHealth <= 0) {
    				gameState = GameState.LOSE;
    				//UnityEngine.SceneManagement.SceneManager.LoadScene("demoLoseScreen");
    			}
    			break;
    		case GameState.PAUSE:
    			break;
    		case GameState.WIN:
    			break;
    		case GameState.LOSE:
    			UnityEngine.SceneManagement.SceneManager.LoadScene("demoLoseScreen");
    			break;
    	}
    }
}
