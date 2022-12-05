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
    public Text scoreTxt; //���� �� ����
    public Text FinalScore; //���� ���� �� ������ ����
    public Text BestScore;
    private int SavedScore = 0;//�������� 0���� �ʱ�ȭ
    private string KeyString = "�ְ�����";

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
        BestScore.text = "�ְ�����: " + SavedScore.ToString("0");
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        //float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && moveX > 0) || (isTouchLeft && moveX < 0))
            moveX = 0;

        Flip();
        

        //�ӵ��� 0���� ũ�� y �������� �� Ŭ �� ������ ��
        // �Ϲ� ���ھ�
        if (rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        finalScore = score + fishScore; //�ö󰡴� ������ ������ ���� �ջ��ؼ� ���
        scoreTxt.text = Mathf.RoundToInt(finalScore).ToString();
        //RoundToInt = �ݿø��ؼ� int������ ��ȯ(Round = �ݿø� / Ceil = �ø� / Floor = ����
        //�ڿ� ToInt ���̸� int ������ ����
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

    void OnTriggerEnter2D(Collider2D collision) //���� �浹 �� �����Ÿ� ���� ���� ����
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
        else if(collision.gameObject.tag == "Over") //���ӿ��� �Լ�
        {
            Time.timeScale = 0; //���� ȭ�� ���� ��
            GameOverPanel.SetActive(true); //���ӿ��� �ǳ� ����
            GameOver();
        }
    }
    void OnTriggerExit2D(Collider2D collision) //���� �浹 �� �����Ÿ� ���� ���� ����
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
        FinalScore.text = "����: " + Mathf.RoundToInt(finalScore).ToString(); //���� ���� ���ӿ��� ȭ�鿡 ����
        if (finalScore >= SavedScore) PlayerPrefs.GetInt(KeyString, (int)finalScore);
    }

    public void AddFishScore(int value)
    {
        fishScore += value;
        scoreTxt.text = (finalScore).ToString();
    }
}
