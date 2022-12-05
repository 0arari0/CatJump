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
            //플레이어와 충돌 시 모자 오브젝트 비활성화
            this.gameObject.SetActive(false);
        }
    }
}
