using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusFishPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.relativeVelocity.y < 0f)
        {
            //충돌 시 점수 100점 추가
            collision.gameObject.GetComponent<PlayerController>().AddFishScore(100);
            this.gameObject.SetActive(false);
        }
    }
}
