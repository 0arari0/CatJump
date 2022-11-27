using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isTouchLeft = false;
    public bool isTouchRight = false;
    private float score = 0;

    public Text scoreTxt; //게임 중 점수
    public Text FinalScore; //게임 오버 전 마지막 점수
    private Rigidbody2D rigid;
    private Animator anim;
    public GameObject GameOverPanel;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        //float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && moveX > 0) || (isTouchLeft && moveX < 0))
            moveX = 0;

        Flip();

        //속도가 0보다 크고 y 포지션이 더 클 때 점수로 들어감
        if (rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
        //RoundToInt = 반올림해서 int형으로 변환(Round = 반올림 / Ceil = 올림 / Floor = 내림
        //뒤에 ToInt 붙이면 int 형으로 나옴

        //MoveControl();

    }
    //private void FixedUpdate()
    //{
    //    Vector2 velocity = rigid.velocity;
    //    velocity.x = moveX;
    //    rigid.velocity = velocity;
    //}
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
    void OnTriggerEnter2D(Collider2D collision) //벽에 충돌 후 덜덜거림 막기 위한 로직
    {
        if(collision.gameObject.tag == "Wall")
        {
            switch(collision.gameObject.name) 
            {
                case "LeftWall":
                    isTouchLeft= true;
                    break;
                case "RightWall":
                    isTouchRight= true;
                    break;
            }
        }
        if(collision.gameObject.tag == "Over") //게임오버 함수
        {
            Time.timeScale = 0; //게임 화면 정지 후
            GameOverPanel.SetActive(true); //게임오버 판넬 띄우기
            GameOver();
        }
    }
    void OnTriggerExit2D(Collider2D collision) //벽에 충돌 후 덜덜거림 막기 위한 로직
    {
        if (collision.gameObject.tag == "Wall")
        {
            switch (collision.gameObject.name)
            {
                case "LeftWall":
                    isTouchLeft = false;
                    break;
                case "RightWall":
                    isTouchRight = false;
                    break;
            }
        }
    }
    void GameOver()
    {
        FinalScore.text = "점수: " + Mathf.RoundToInt(score).ToString(); //현재 점수 게임오버 화면에 띄우기
    }

    //화면 밖으로 나가지 않게 하는 함수
    //void MoveControl()
    //{
    //    float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    //    transform.Translate(moveX, 0, 0);

    //    //현재 플레이어의 월드좌표(transform.position)을 뷰포트 기준 좌표로 변환시키는 명령
    //    Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

    //    //Mathf.Clamp01(값) - 입력된 값이 0~1 사이를 벗어나지 못하게 강제로 조정해주는 함수
    //    viewPos.x = Mathf.Clamp01(viewPos.x);

    //    Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
    //    transform.position = worldPos;
    //}
}
