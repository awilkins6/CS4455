﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript2 : MonoBehaviour
{
    public GameObject nightLight;
    enum GameState{
    	START,
    	GAME,
    	PAUSE,
    	WIN,
    	LOSE
    };
    	GameState gameState;
    	ShipHealth shipHealth;
    	GameObject ship;
    // Start is called before the first frame update
    string dayState;
    public GameObject alienHive;
    public GameObject playerStart;
    public GameObject player;
    bool spawnedAliensToday = true;

    public GameObject[] shipParts;
    public GameObject[] shipLabels;
    int foundParts = 0;

    public GameObject winScreen;
    public GameObject loseScreen;

    void Start()
    {
      player = GameObject.FindWithTag("Player");
      gameState = GameState.GAME;
      dayState = gameObject.GetComponent<DayAndNightControl>().dayState;
      shipHealth = GameObject.FindWithTag("Ship").GetComponent<ShipHealth>();
      nightLight.SetActive(false);
      UpdateParts();
    }

    public void UpdateParts() {
      foundParts = 0;
      for (int i = 0; i < shipParts.Length; i++) {
        if (shipParts[i].GetComponent<PartPickUpScript>().found) {
          Debug.Log("found!!");
          shipLabels[i].GetComponent<Text>().color = Color.green;
          foundParts++;
        } else {
          shipLabels[i].GetComponent<Text>().color = Color.red;
        }
        shipLabels[i].GetComponent<Text>().text = shipParts[i].name;
      }
      Debug.Log("Updated parts");

      if (foundParts == shipParts.Length) {
        gameState = GameState.WIN;
      }
    }

    // Update is called once per frame
    void Update() {
      dayState = gameObject.GetComponent<DayAndNightControl>().dayState;
      if (string.Equals(dayState, "Midnight") || string.Equals(dayState, "Night")) {
        // Debug.Log("LET THERE BE (NIGHT) LIGHT");
        nightLight.SetActive(true);
      } else {
        nightLight.SetActive(false);
      }

      switch(gameState) {
      case GameState.START:
      	break;
      case GameState.GAME:
      	if (shipHealth.shipHealth <= 0) {
      		gameState = GameState.LOSE;
      		//UnityEngine.SceneManagement.SceneManager.LoadScene("demoLoseScreen");
      	}
      	break;
      case GameState.PAUSE:
      	break;
      case GameState.WIN:
        Win();
      	break;
      case GameState.LOSE:
        Lose();
      	// UnityEngine.SceneManagement.SceneManager.LoadScene("demoLoseScreen");
      	break;
      }
    }

    void Win() {
      Time.timeScale = 0f;
      winScreen.SetActive(true);
    }

    void Lose() {
      Time.timeScale = 0f;
      loseScreen.SetActive(true);
    }

    public void startNight() {
      player.transform.position = playerStart.transform.position;
    }

    public void startMidnight() {
      alienHive.GetComponent<HiveScript>().spawnAliens(GetComponent<DayAndNightControl>().currentDay);
      spawnedAliensToday = true;
    }
}
