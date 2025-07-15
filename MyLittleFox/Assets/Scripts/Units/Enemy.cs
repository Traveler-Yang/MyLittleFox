using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("����")]
    //��λ���ͺ͵�������
    public Unit_Type unitType;
    public Enemy_type enemyType;
    [Header("�������")]
    //��ȡ��ɫ�ľ�����Ⱦ�����
    public SpriteRenderer spriteRenderer;
    //��ȡ��ɫ�Ķ������
    public Animator animator;
    //��ȡ��ɫ�ĸ������
    public Rigidbody2D rigidbody2;
    //��ȡ��ɫ����ײ�����
    public Collider2D collider2;
    [Header("��������")]
    //�ƶ��ٶ�
    public float speed;
    //��Ծ��
    public float jumpForce;
    //����״̬
    public bool isHurt = false;
    //�Ƿ��ڵ�����
    public bool isGround;

    [Header("")]
    //��ǰ����λ�õ��������
    public float leftLimit;
    //��ǰ����λ�õ��Ҳ�����
    public float rightLimit;
    //����
    public GameObject obj;
    //��������
    public GameObject death;
    //����
    public int direction = -1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void SetAnimation()
    {
        animator.SetFloat("Jump", rigidbody2.velocity.y);
        animator.SetBool("IsGround", isGround);
    }

    /// <summary>
    /// ��Ծ
    /// </summary>
    public void Jump()
    {
        if (isGround)
        {
            rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
            isGround = false;
        }
    }

    //���ɶ���
    public void GenerateAni()
    {
        //�������������ڵ�������
        Instantiate(death, obj.transform.position, Quaternion.identity, null);
    }

    public void Damaged()
    {
        AudioManager.instance.PlaySFX(4);
        Death();
        //�Ƴ��Լ��󲥷���������
        GenerateAni();
    }
    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("Enemy�ڵ���" + isGround);
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy���ڵ���" + isGround);
        isGround = false;
    }
}
