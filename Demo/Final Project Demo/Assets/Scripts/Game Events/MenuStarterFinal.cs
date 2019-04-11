using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuStarterFinal : MonoBehaviour
{

    public void StartGame() {
        SceneManager.LoadScene("Game_Menu");
        Time.timeScale = 1f;

    }

}