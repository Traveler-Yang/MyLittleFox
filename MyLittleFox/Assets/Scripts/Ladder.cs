using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;//��ֱ����
    private float speed = 3f;//�����ӵ��ٶ�
    private bool isLadder;//�Ƿ���������
    private bool isClimbing;//�Ƿ�����������״̬

    public Animator anim;

    public Rigidbody2D rb;
    void Start()
    {
    }

    
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        //�������ϣ����Ұ����¼���ֵ��ʱ��MathfAbs�ǵõ���ֵ�ľ���ֵ��
        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            //�ý�ɫû������
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            //���û����������ָ�����
            rb.gravityScale = 4f;
        }
    }
    //���������ӣ���ʼ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            isClimbing = true;
            anim.SetBool("Climbing", true);
        }
    }
    //�뿪����ʱ���˳������ӵ�״̬
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("Climbing", false);
        }
    }
}
