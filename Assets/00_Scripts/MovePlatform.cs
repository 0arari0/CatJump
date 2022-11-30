using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    Vector3 pos; //현재 위치
    public float delta; //카메라 좌우 너비 절반값
    public float speed = 1f; //이동속도

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
