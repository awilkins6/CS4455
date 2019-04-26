//2016 Spyblood Games

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class DayColors
{
	public Color skyColor;
	public Color equatorColor;
	public Color horizonColor;
}

public class DayAndNightControl : MonoBehaviour {

	public bool StartDay; //start game as day time
	public DayColors dawnColors;
	public DayColors dayColors;
	public DayColors nightColors;
	public int currentDay = 0; //day 8287... still stuck in this grass prison... no esacape... no freedom...

	public Light dayLight; //the directional light in the scene we're going to work with
	public Light nightLight;

	public float SecondsInAFullDay;
	//in realtime, this is about two minutes by default. (every 1 minute/60 seconds is day in game)
	//[Range(0,1)]
	public float currentTime = 0; //at default when you press play, it will be nightTime. (0 = night, 1 = day)
	[HideInInspector]
	public float timeMultiplier = 1f; //how fast the day goes by regardless of the secondsInAFullDay var. lower values will make the days go by longer, while higher values make it go faster. This may be useful if you're siumulating seasons where daylight and night times are altered.
	public bool showUI;
	float lightIntensity; //static variable to see what the current light's insensity is in the inspector

  public Material nightSkybox;
  public Material daySkybox;

	public string dayState;
  public GameObject TOD_Text;

	// Use this for initialization
	void Start () {
		lightIntensity = dayLight.intensity; //what's the current intensity of the light
		if (StartDay) {
			currentTime = 0.3f; //start at morning
		}
	}

	// Update is called once per frame
	void Update () {
		TOD_Text.GetComponent<Text>().text = "Time: " + TimeOfDay() + "\n" + currentTime.ToString("F");
		UpdateLight();
		currentTime += (Time.deltaTime / SecondsInAFullDay) * timeMultiplier;
		if (currentTime >= 1) {
			currentTime = 0;//once we hit "midnight"; any time after that sunrise will begin.
			currentDay++; //make the day counter go up
		}
	}

  float intensityMultiplier = 1;

	void UpdateLight() {

    if (currentTime <= 0.2f) {
      if (!dayState.Equals("Midnight")) {
       Debug.Log(currentTime);
       GetComponent<GameManagerScript2>().startMidnight();
      }
      dayState = "Midnight";
      intensityMultiplier = 0f;
      RenderSettings.ambientSkyColor = nightColors.skyColor;
      RenderSettings.ambientEquatorColor = nightColors.equatorColor;
      RenderSettings.ambientGroundColor = nightColors.horizonColor;
    } else if (currentTime <= 0.3f) {
      dayState = "Morning";
  		intensityMultiplier = Mathf.Clamp01((currentTime - 0.23f) * (1 / 0.02f));
      RenderSettings.ambientSkyColor = dawnColors.skyColor;
      RenderSettings.ambientEquatorColor = dawnColors.equatorColor;
      RenderSettings.ambientGroundColor = dawnColors.horizonColor;
    } else if (currentTime <= 0.6f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
      dayState = "Mid Noon";
      RenderSettings.ambientSkyColor = dayColors.skyColor;
      RenderSettings.ambientEquatorColor = dayColors.equatorColor;
      RenderSettings.ambientGroundColor = dayColors.horizonColor;
    } else if (currentTime <= 0.8f) {
			intensityMultiplier = Mathf.Clamp01(1 - ((currentTime - 0.73f) * (1 / 0.02f)));
      dayState = "Evening";
      RenderSettings.ambientSkyColor = dayColors.skyColor;
      RenderSettings.ambientEquatorColor = dayColors.equatorColor;
      RenderSettings.ambientGroundColor = dayColors.horizonColor;
    } else if (currentTime <= 1f) {
      if (!dayState.Equals("Night")) {
       GetComponent<GameManagerScript2>().startNight();
      }
      dayState = "Night";
      RenderSettings.ambientSkyColor = nightColors.skyColor;
      RenderSettings.ambientEquatorColor = nightColors.equatorColor;
      RenderSettings.ambientGroundColor = nightColors.horizonColor;
    }

		if (currentTime >= 0.3f && currentTime <= 0.8f) {
      RenderSettings.skybox = daySkybox;
			dayLight.transform.localRotation = Quaternion.Euler ((currentTime * 360f) - 90, 170, 0);
      nightLight.gameObject.SetActive(false);
      dayLight.gameObject.SetActive(true);
		} else {
      RenderSettings.skybox = nightSkybox;
      nightLight.gameObject.SetActive(true);
      dayLight.gameObject.SetActive(false);
    }

		dayLight.intensity = lightIntensity * intensityMultiplier;
	}

	public string TimeOfDay () {
		return dayState;
	}
}
