using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public bool isTouchLeft = false;
    public bool isTouchRight = false;
    float score = 0;
    float fishScore = 0;
    float finalScore = 0;
    public Text scoreTxt; //게임 중 점수
    public Text FinalScore; //게임 오버 전 마지막 점수
    public Text BestScore;
    private int SavedScore = 0;//저장점수 0으로 초기화
    private string KeyString = "최고점수";

    private Rigidbody2D rigid;
    private Animator anim;
    public GameObject GameOverPanel;
    public GameObject CapItem;
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SavedScore = PlayerPrefs.GetInt(KeyString,0);
        BestScore.text = "최고점수: " + SavedScore.ToString("0");
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        //float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && moveX > 0) || (isTouchLeft && moveX < 0))
            moveX = 0;

        Flip();
        

        //속도가 0보다 크고 y 포지션이 더 클 때 점수로 들어감
        // 일반 스코어
        if (rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        finalScore = score + fishScore; //올라가는 점수와 아이템 점수 합산해서 계산
        scoreTxt.text = Mathf.RoundToInt(finalScore).ToString();
        //RoundToInt = 반올림해서 int형으로 변환(Round = 반올림 / Ceil = 올림 / Floor = 내림
        //뒤에 ToInt 붙이면 int 형으로 나옴
    }

    void Flip()
    {
        Vector3 flipMove = Vector3.zero;

        if(Input.GetAxisRaw("Horizontal")<0)
        {
            flipMove = Vector3.left;
            spriteRenderer.flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal")>0)
        {
            flipMove = Vector3.right;
            spriteRenderer.flipX = false;
        }

        transform.position += flipMove * 5f * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision) //벽에 충돌 후 덜덜거림 막기 위한 로직
    {
        if (collision.gameObject.tag == "Wall")
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
        else if(collision.gameObject.tag == "Over") //게임오버 함수
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
        FinalScore.text = "점수: " + Mathf.RoundToInt(finalScore).ToString(); //현재 점수 게임오버 화면에 띄우기
        if (finalScore >= SavedScore) PlayerPrefs.GetInt(KeyString, (int)finalScore);
    }

    public void AddFishScore(int value)
    {
        fishScore += value;
        scoreTxt.text = (finalScore).ToString();
    }
}
