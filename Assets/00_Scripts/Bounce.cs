using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float jumpForce = 10f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y<=0f)
        {
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rigid!=null)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("Platform");
                Vector2 velocity = rigid.velocity;
                velocity.y = jumpForce;
                rigid.velocity = velocity;
            }
        }
    }
}
