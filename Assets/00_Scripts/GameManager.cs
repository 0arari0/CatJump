using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject SpringPlatformPrefab;
    public GameObject TwoSpringPlatformPrefab;
    public GameObject JumpPlatformPrefab;
    public GameObject CapPlatformPrefab;
    public int platformCount = 200;


    private void OnEnable() //������ ����� �� ���� �����. Awake - OnEnable - Start
    {
        Time.timeScale= 1.0f;
    }

    void Start()
    {
        Vector3 spawnPosition = new Vector3();
        for (int i = 0; i < platformCount; i++)
        {
            int Percentage = Random.Range(0, 100);
            if(Percentage<85) //�⺻ ����
            {
                spawnPosition.y += Random.Range(1f, 2f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            }
            else if(Percentage<90) //1������ ����
            {
                spawnPosition.y += Random.Range(1f, 4f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(SpringPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else if(Percentage<93) //2������ ����
            {
                spawnPosition.y += Random.Range(1f, 5f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(TwoSpringPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else if(Percentage<97) //����� ����
            {
                spawnPosition.y += Random.Range(1f, 5f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(JumpPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else //����
            {
                spawnPosition.y += Random.Range(1f, 5f);
                spawnPosition.x = Random.Range(-2f, 2f);
                Instantiate(CapPlatformPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
