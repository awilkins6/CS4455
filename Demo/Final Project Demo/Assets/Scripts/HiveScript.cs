using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HiveScript : MonoBehaviour
{
    public GameObject alienPrefab;
    public GameObject alienSpawnParent;
    List<GameObject> alienSpawns;

    public int baseSpawn = 2;
    public int dailySpawn = 2;

    void Start() {
      alienSpawns = new List<GameObject>();
      foreach(Transform child in alienSpawnParent.transform) {
        alienSpawns.Add(child.gameObject);
      }
    }

    Vector3 spawnPos;
    public void spawnAliens (int day) {
      int alienCount = Mathf.Clamp(baseSpawn + dailySpawn*day, 0, alienSpawns.Count);
      Debug.Log("Spawning " + alienCount + " aliens on day " + day);

      List<GameObject> cloneList = new List<GameObject>();
      foreach (GameObject alienSpawn in alienSpawns) {
        cloneList.Add(alienSpawn);
      }

      for (int a = 0; a < alienCount; a++) {
        int i = Random.Range(0, cloneList.Count);
        spawnPos = cloneList[i].transform.position;
        cloneList.RemoveAt(i);
        Object.Instantiate(alienPrefab, spawnPos + 2f * Vector3.up, Quaternion.identity);
      }
    }
}
