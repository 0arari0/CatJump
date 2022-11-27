using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject SpringPlatformPrefab;
    public int platformCount = 200;

    private void OnEnable() //게임이 실행될 때 먼저 실행됨. Awake - OnEnable - Start
    {
        Time.timeScale= 1.0f;
    }

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for(int i=0; i<platformCount; i++)
        {
            spawnPosition.y += Random.Range(1f, 3f);
            spawnPosition.x = Random.Range(-2f, 2f);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }
        for(int i=0; i<platformCount; i++)
        {
            spawnPosition.y += Random.Range(1f, 5f);
            spawnPosition.x = Random.Range(-2f, 2f);
            Instantiate(SpringPlatformPrefab, spawnPosition, Quaternion.identity);
        }
    }


}
