using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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
	//GameObject[] aliens;
	List<GameObject> aliens = new List<GameObject>();
	GameObject ship;
    // Start is called before the first frame update
    string dayState;
    void Start()
    {
        dayState =  GameObject.Find("Terrain1").GetComponent<DayAndNightControl>().dayState;
        gameState = GameState.GAME;
        shipHealth = GameObject.Find("Ship1").transform.GetChild(0).GetComponent<ShipHealth>().shipHealth;
        Debug.Log("game manager started");
        //aliens = GameObject.Find("Aliens");
 		// foreach (Transform child in GameObject.Find("Aliens").transform) {
   // 			aliens.Add(child.gameObject);
 		// }
   //      ship = GameObject.Find("Ship1");
    }

    // Update is called once per frame
    void Update()
    {
    	//night lights, currently not in use/working
    	if (string.Equals(dayState, "Midnight") || string.Equals(dayState, "Night")) {
    		NightLight.SetActive(true);
    	} else {
    		NightLight.SetActive(false);
    	}

    	Debug.Log("game manager ship health" + shipHealth);
    	Debug.Log("I am THE GAME MANAGER! I AM ALIVE");

    	switch(gameState) {
    		case GameState.START:
    			break;
    		case GameState.GAME:
    			if (shipHealth <= 0) {
    				gameState = GameState.LOSE;
    				UnityEngine.SceneManagement.SceneManager.LoadScene("demoLoseScreen");
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
