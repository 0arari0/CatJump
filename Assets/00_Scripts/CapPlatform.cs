using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapPlatform : MonoBehaviour
{
    PlayerController playerController;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && collision.relativeVelocity.y < 0f)
        {
            //�÷��̾�� �浹 �� ���� ������Ʈ ��Ȱ��ȭ
            this.gameObject.SetActive(false);
        }
    }
}
