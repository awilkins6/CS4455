using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuStarterFinal : MonoBehaviour
{

    public void StartGame() {
        SceneManager.LoadScene("MAIN menu");
        Time.timeScale = 1f;

    }

}
