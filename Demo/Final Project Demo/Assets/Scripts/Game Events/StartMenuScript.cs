using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class StartMenuScript : MonoBehaviour
{

	private CanvasGroup canvasGroup;

    void Awake() {
    	canvasGroup = GetComponent<CanvasGroup>();

    	if (canvasGroup == null)
            Debug.Log("Canvas Group could not be found");
    }

    void Update() {
    	if (Input.GetKeyUp (KeyCode.Escape)) {
				canvasGroup.interactable = true;
				canvasGroup.blocksRaycasts = true;
				canvasGroup.alpha = 1f;
				Time.timeScale = 0f;
		}		 
    }

}
