using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class OpenShop : MonoBehaviour
{
    public CanvasGroup shop;
    public bool playerNear = false;
    public GameObject player;
    private float maxDist = 20f;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && Vector3.Distance(player.transform.position, transform.position) < maxDist)
        {
            if (shop.interactable)
            {
                shop.interactable = false;
                shop.blocksRaycasts = false;
                shop.alpha = 0f;
                Time.timeScale = 1f;
            }
            else
            {
                shop.interactable = true;
                shop.blocksRaycasts = true;
                shop.alpha = 1f;
                Time.timeScale = 0f;
            }
        }

    }
}
