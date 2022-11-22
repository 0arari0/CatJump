using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Rigidbody2D rigid;
    public Animator anim;

    private float moveX;
    private float score = 0;
    public Text scoreTxt;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * moveSpeed;
        Flip();

        //속도가 0보다 크고 y 포지션이 더 클 때 점수로 들어감
        if(rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
        //RoundToInt = 반올림해서 int형으로 변환(Round = 반올림 / Ceil = 올림 / Floor = 내림
        //뒤에 ToInt 붙이면 int 형으로 나옴

        MoveControl();
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

    //화면 밖으로 나가지 않게 하는 함수
    void MoveControl()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(moveX, 0, 0);

        //현재 플레이어의 월드좌표(transform.position)을 뷰포트 기준 좌표로 변환시키는 명령
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        //Mathf.Clamp01(값) - 입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조정해주는 함수
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
}
