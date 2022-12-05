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
    public GameObject MovePlatformPrefab;
    public GameObject BreakPlatformPrefab;
    public GameObject PlusFishPlatformPrefab;

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

            spawnPosition.y += Random.Range(1f, 3f);
            spawnPosition.x = Random.Range(-2f, 2f);
            Instantiate(PlusFishPlatformPrefab, spawnPosition, Quaternion.identity);

            //int Percentage = Random.Range(0, 100);
            //if (Percentage < 60) //�⺻ ����
            //{
            //    spawnPosition.y += Random.Range(1f, 2f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            //}
            //else if (Percentage < 70) //�̵� ���� 5%
            //{
            //    spawnPosition.y += Random.Range(1f, 5f);
            //    spawnPosition.x = 0;
            //    Instantiate(MovePlatformPrefab, spawnPosition, Quaternion.identity);
            //}
            //else if (Percentage < 80) //�ٻ�� ���� 5%
            //{
            //    spawnPosition.y += Random.Range(1f, 5f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(BreakPlatformPrefab, spawnPosition, Quaternion.identity);
            //}
            //else if (Percentage < 90) //1������ ���� 5%
            //{
            //    spawnPosition.y += Random.Range(1f, 4f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(SpringPlatformPrefab, spawnPosition, Quaternion.identity);
            //}
            //else if (Percentage < 95) //2������ ���� 5%
            //{
            //    spawnPosition.y += Random.Range(1f, 5f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(TwoSpringPlatformPrefab, spawnPosition, Quaternion.identity);
            //}
            //else if (Percentage < 98) //����� ���� 3%
            //{
            //    spawnPosition.y += Random.Range(1f, 5f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(JumpPlatformPrefab, spawnPosition, Quaternion.identity);
            //}

            //else //���� 2%
            //{
            //    spawnPosition.y += Random.Range(1f, 5f);
            //    spawnPosition.x = Random.Range(-2f, 2f);
            //    Instantiate(CapPlatformPrefab, spawnPosition, Quaternion.identity);
            //}
        }
    }
    
}
