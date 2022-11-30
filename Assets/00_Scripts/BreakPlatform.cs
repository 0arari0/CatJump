using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public float fallSec = 0.5f;
    public float destroySec = 2f;
    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Invoke("FallPlatform", fallSec); //fallPlatform�Լ� ���� fallsec��ŭ
            Destroy(gameObject, destroySec); //���ӿ�����Ʈ �ı�
        }
    }
    void FallPlatform()
    {
        rigid.isKinematic = false;
    }
}
