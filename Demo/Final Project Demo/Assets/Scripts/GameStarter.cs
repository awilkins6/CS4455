using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public void StartGame() {
    	UnityEngine.SceneManagement.SceneManager.LoadScene("demo");
    }
}
