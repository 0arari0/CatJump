using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    Vector3 pos; //���� ��ġ
    public float delta; //ī�޶� �¿� �ʺ� ���ݰ�
    public float speed = 1f; //�̵��ӵ�

    private void Start()
    {
        pos = transform.position;
        speed = Random.Range(0.5f, 1.5f);
        delta = Camera.main.orthographicSize * Camera.main.aspect-0.8f;
    }
    private void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
