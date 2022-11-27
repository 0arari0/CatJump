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

    public Text scoreTxt; //���� �� ����
    public Text FinalScore; //���� ���� �� ������ ����
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

        //�ӵ��� 0���� ũ�� y �������� �� Ŭ �� ������ ��
        if (rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
        //RoundToInt = �ݿø��ؼ� int������ ��ȯ(Round = �ݿø� / Ceil = �ø� / Floor = ����
        //�ڿ� ToInt ���̸� int ������ ����

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
    void OnTriggerEnter2D(Collider2D collision) //���� �浹 �� �����Ÿ� ���� ���� ����
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
        if(collision.gameObject.tag == "Over") //���ӿ��� �Լ�
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
        FinalScore.text = "����: " + Mathf.RoundToInt(score).ToString(); //���� ���� ���ӿ��� ȭ�鿡 ����
    }

    //ȭ�� ������ ������ �ʰ� �ϴ� �Լ�
    //void MoveControl()
    //{
    //    float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
    //    transform.Translate(moveX, 0, 0);

    //    //���� �÷��̾��� ������ǥ(transform.position)�� ����Ʈ ���� ��ǥ�� ��ȯ��Ű�� ���
    //    Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

    //    //Mathf.Clamp01(��) - �Էµ� ���� 0~1 ���̸� ����� ���ϰ� ������ �������ִ� �Լ�
    //    viewPos.x = Mathf.Clamp01(viewPos.x);

    //    Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
    //    transform.position = worldPos;
    //}
}
