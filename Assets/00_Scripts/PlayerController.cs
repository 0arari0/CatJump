using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rigid;
    public Animator anim;

    private float moveX;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        Flip();
    }
    private void FixedUpdate()
    {
        Vector2 velocity = rigid.velocity;
        velocity.x = moveX;
        rigid.velocity = velocity;
    }
    void Flip()
    {
        Vector3 flipMove = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0)
        {
            flipMove = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetAxisRaw("Horizontal")>0)
        {
            flipMove = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position += flipMove * 5f * Time.deltaTime;
    }
}
