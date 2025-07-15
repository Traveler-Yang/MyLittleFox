using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    //��λ����
    public Unit_Type unitType;
    [Header("�������")]
    //��ȡĦ�������
    public PhysicsMaterial2D noFriction;//û��Ħ���� ��Ծʹ��
    public PhysicsMaterial2D haveFriction;//��Ħ����
    //��ȡ��ɫ�ľ�����Ⱦ�����
    public SpriteRenderer spriteRenderer;
    //��ȡ��ɫ�Ķ������
    public Animator animator;
    //��ȡ��ɫ�ĸ������
    public Rigidbody2D rigidbody2;
    //��ȡ��ɫ����ײ�����
    public Collider2D collider2;
    //��ȡ��ɫſ��ʱ����ײ�����
    public Collider2D crouchCollider2;
    //��ȡ����ʯ�ĸ������ı����
    public Text gemsText;
    //���Ѫ����Ѫ���ı����
    public Text hpText;
    public Text maxHpText;
    //Ѫ�����
    public Slider hpSlider;
    [Header("�ж��Ƿ��ڵ�������")]
    //�������
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    [Header("��������")]
    //Ѫ��
    public float hp = 100f;
    //���Ѫ��
    public float maxHp = 100f;
    //�ƶ��ٶ�
    public float speed;
    //�÷�
    public int Score = 0;
    //��Ծ��
    public float jumpForce;
    //����״̬
    public bool isHurt = false;
    //����״̬
    public bool isDead = false;
    //�Ƿ��ڵ�����
    public bool isGround;
    //�Ƿ���Զ�����
    public bool isDoubleJump = false;
    //�Ƿ���һ����
    private bool isJump = true;
    //�Ƿ�ſ��
    public bool isCrouch = false;
    //���˵���
    private float hurtForce = 5f;
    //�޵�ʱ��
    public float invincibleLength;
    //�޵е���ʱ
    private float invincbleCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
            Init();
    }


    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        //���޵�ʱ��û�н���ʱ���Լ�
        if (invincbleCounter > 0)
        {
            invincbleCounter -= Time.deltaTime;
            //���޵н���ʱ����ɫ�ı��ȥ
            if(invincbleCounter <= 0)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }
        }
        hpText.text = hp.ToString();
        hpSlider.value = Mathf.Lerp(hpSlider.value, hp, 0.01f);
        if (hp <= 0)
        {
            Dead();
        }
        if (!isHurt && !isDead)
        {
            Move();
        }
        Crouch();
        Jump();
        SetAnimation();
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    public void Init()
    {
        isDead = false;
        enabled = true;
        isCrouch = false;
        //Ĭ�Ϲر�ſ��ʱ����ײ��
        crouchCollider2.enabled = false;

        #region ��ʼ��Ѫ��
        //����ҵ����Ѫ����ֵ��Ѫ���������ֵ
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
        //����ҵ����Ѫ����ֵ�����Ѫ����ʾ���ı�
        maxHpText.text = maxHp.ToString();
        //��Ѫ����ֵ��Ѫ������ʾ�ı�
        hpText.text = hp.ToString();
        #endregion

        #region ��ʼ���÷�
        Score = 0;
        gemsText.text = Score.ToString();
        #endregion
    }

    /// <summary>
    /// ��������
    /// </summary>
    public void SetAnimation()
    {
        animator.SetFloat("Run", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("Jump", rigidbody2.velocity.y);
        animator.SetBool("IsGround", isGround);
        animator.SetBool("Hurt", isHurt);
        animator.SetBool("Crouch", isCrouch);
    }
    /// <summary>
    /// �ƶ�
    /// </summary>
    public void Move()
    {
        rigidbody2.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2.velocity.y);
        //������ת����
        if (Input.GetAxis("Horizontal") < 0)
            spriteRenderer.flipX = true;
        if (Input.GetAxis("Horizontal") > 0)
            spriteRenderer.flipX = false;
    }
    /// <summary>
    /// ��Ծ
    /// </summary>
    public void Jump()
    {
        //��Ծʱ��û��Ħ�����Ĳ��ʸ�ֵ�����
        collider2.sharedMaterial = noFriction;
        //���¿ո���Ծ���������ڵ�����
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                //�ڵ����Ͻ���Ħ�����Ĳ��ʸ�ֵ�����
                collider2.sharedMaterial = haveFriction;
                //������Ծ��Ч
                AudioManager.instance.PlaySFX(0);
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
                //���ڵ�����
                isGround = false;
                //��������һ����
                isJump = true;
            }
            else if (isDoubleJump && !isGround && isJump)
            {
                //������Ծ��Ч
                AudioManager.instance.PlaySFX(0);
                //�ٴν�����Ծ
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
                //���岻��һ����
                isJump = false;
            }
        }
    }
    /// <summary>
    /// �¶�
    /// </summary>
    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isCrouch = true;
            crouchCollider2.enabled = true;
            collider2.enabled = false;
            speed /= 2;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            isCrouch = false;
            crouchCollider2.enabled = false;
            collider2.enabled = true;
            speed *= 2;
        }
    }
    public void HurtEnd()
    {
        isHurt = false;
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="gameObject"></param>
    public void Hurt(GameObject gameObject)
    {
        //����޵�ʱ�䵽�ˣ��ſ����յ��˺�
        if (invincbleCounter <= 0)
        {
            //����������Ч
            AudioManager.instance.PlaySFX(1);
            isHurt = true;
            hp -= 10f;
            //����ʱʹ��Ҽ��ٶ�Ϊ0
            rigidbody2.velocity = Vector2.zero;
            //�����ת�����ѡ��û�й��ϣ�˵���������ߣ���Ҫ��������Ҫ��һ���෴����
            if (!spriteRenderer.flipX)
            {
                rigidbody2.velocity = new Vector2(-hurtForce, rigidbody2.velocity.y);
            }
            else
            {
                rigidbody2.velocity = new Vector2(hurtForce, rigidbody2.velocity.y);
            }
                //�����õ��޵�ʱ�丳ֵ������ʱ
                invincbleCounter = invincibleLength;
            //���˸ı��޵���ɫ
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .7f);
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    public void Dead()
    {
        isDead = true;
        Hurt(gameObject);
        LevelManager.instance.RespawnPlayer();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.CompareTag("Spikes"))
        {
            Hurt(collision.gameObject);
        }
        //�����߽�����
        if (collision.CompareTag("MapEdge"))
        {
            Dead();
        }
        //��������ͨ��
        if (collision.CompareTag("Flag"))
        {
            enabled = false;
            //����ʤ������
            AudioManager.instance.PlayLevelVictory();
            //�л����ؿ�ѡ�����
            LevelLoader.instance.LevelPanelSelct();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cherry") || collision.CompareTag("Gem"))
        {
            rigidbody2.velocity = new Vector2(0, rigidbody2.velocity.y);
        }
        animator.SetFloat("Jump", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //��������ʱ�����ɫλ�ø��ڵ��ˣ����ٶ����£�����Ϊ�ȵ�����
            GameObject enemyObj = collision.gameObject;
            if (transform.position.y > enemyObj.transform.position.y
                && rigidbody2.velocity.y < 0)
            {
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);//�����ɫһ��С��
                enemyObj.GetComponent<Enemy>().Damaged();//���õ��˵����˷���
            }
            else
            {
                Hurt(collision.gameObject);
                
            }
        }
    }
}
