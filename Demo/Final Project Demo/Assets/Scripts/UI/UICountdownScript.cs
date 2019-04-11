using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICountdownScript : MonoBehaviour
{
	public float totalTime;
	private Text counterText;

	private float timer;
	private bool canCount = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = totalTime;
        counterText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.0f) {
        	timer -= Time.deltaTime;
        } else if (timer <= 0.0f) {
        	timer = totalTime;
        }
        counterText.text = timer.ToString("F");
    }
}
