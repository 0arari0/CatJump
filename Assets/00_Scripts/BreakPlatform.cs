using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakPlatform : MonoBehaviour
{
    public float fallSec = 0.5f;
    public float destroySec = 2f;
    Rigidbody2D rigid;
    public Sprite breakImg; //�ٲ� �̹���
    SpriteRenderer NowImg; //���� �̹���

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        NowImg= GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   // �浹�� ��ü�� �÷��̾��̰�, �ε��� ���� �÷��̾��� ���ӵ��� 0���� �۴ٸ�(������ �Ʒ��� �������� �ִ� ���̶��)
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y < 0f)
        {
            NowImg.sprite = breakImg;
            Invoke("FallPlatform", fallSec); //fallPlatform�Լ� ���� fallsec��ŭ
            Destroy(gameObject, destroySec); //���ӿ�����Ʈ �ı�
        }
    }
    void FallPlatform()
    {
        rigid.isKinematic = false;
    }
   
}
