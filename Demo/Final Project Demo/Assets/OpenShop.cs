using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]

public class OpenShop : MonoBehaviour
{
    public CanvasGroup shop;

    private void OnTriggerStay(Collider c)
    {
        PlayerController pc = c.attachedRigidbody.gameObject.GetComponent<PlayerController>();
        if (c.attachedRigidbody != null)
        {
            pc.closeToShop();
        }
    }

    private void OnTriggerExit(Collider c)
    {
        PlayerController pc = c.attachedRigidbody.gameObject.GetComponent<PlayerController>();
        if (c.attachedRigidbody != null)
        {
            pc.notCloseToShop();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyUp(KeyCode.E))
        //{
        //    if (shop.interactable)
        //    {
        //        shop.interactable = false;
        //        shop.blocksRaycasts = false;
        //        shop.alpha = 0f;
        //        Time.timeScale = 1f;
        //    }
        //    else
        //    {
        //        shop.interactable = true;
        //        shop.blocksRaycasts = true;
        //        shop.alpha = 1f;
        //        Time.timeScale = 0f;
        //    }
        //}
      
    }
}
