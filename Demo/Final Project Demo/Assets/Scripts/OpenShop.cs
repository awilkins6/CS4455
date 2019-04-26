using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class OpenShop : MonoBehaviour
{
    public CanvasGroup shop;
    public bool playerNear = false;
    public GameObject player;
    private float maxDist = 10f;
    private CameraController camcon;
    // Start is called before the first frame update
    void Start() {
      player = GameObject.FindWithTag("Player");
      camcon = GameObject.Find("Cameraman").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Shop") && Vector3.Distance(player.transform.position, transform.position) < maxDist) {
            if (shop.interactable) {
                shop.interactable = false;
                shop.blocksRaycasts = false;
                shop.alpha = 0f;
                Time.timeScale = 1f;
                camcon.shopOpen = false;
            } else {
                shop.interactable = true;
                shop.blocksRaycasts = true;
                shop.alpha = 1f;
                Time.timeScale = 0f;
                camcon.shopOpen = true;
                CurrencyScript.noMoney = 0;
            }
        }

    }
}
