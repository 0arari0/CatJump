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

        //�ӵ��� 0���� ũ�� y �������� �� Ŭ �� ������ ��
        if(rigid.velocity.y>0 && transform.position.y > score)
        {
            score = transform.position.y;
        }
        scoreTxt.text = Mathf.RoundToInt(score).ToString();
        //RoundToInt = �ݿø��ؼ� int������ ��ȯ(Round = �ݿø� / Ceil = �ø� / Floor = ����
        //�ڿ� ToInt ���̸� int ������ ����

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

    //ȭ�� ������ ������ �ʰ� �ϴ� �Լ�
    void MoveControl()
    {
        float moveX = moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(moveX, 0, 0);

        //���� �÷��̾��� ������ǥ(transform.position)�� ����Ʈ ���� ��ǥ�� ��ȯ��Ű�� ���
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        //Mathf.Clamp01(��) - �Էµ� ���� 0~1 ���̸� ����� ���ϰ� ������ �������ִ� �Լ�
        viewPos.x = Mathf.Clamp01(viewPos.x);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
}
