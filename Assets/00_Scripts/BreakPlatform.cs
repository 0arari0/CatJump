using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakPlatform : MonoBehaviour
{
    public float fallSec = 0.5f;
    public float destroySec = 2f;
    Rigidbody2D rigid;
    public Sprite breakImg; //바꿀 이미지
    SpriteRenderer NowImg; //현재 이미지

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        NowImg= GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   // 충돌한 객체가 플레이어이고, 부딪힌 순간 플레이어의 상대속도가 0보다 작다면(위에서 아래로 내려오고 있는 중이라면)
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y < 0f)
        {
            NowImg.sprite = breakImg;
            Invoke("FallPlatform", fallSec); //fallPlatform함수 실행 fallsec만큼
            Destroy(gameObject, destroySec); //게임오브젝트 파괴
        }
    }
    void FallPlatform()
    {
        rigid.isKinematic = false;
    }
   
}
