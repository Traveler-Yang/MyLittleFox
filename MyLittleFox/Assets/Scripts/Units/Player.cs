using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    //单位类型
    public Unit_Type unitType;
    [Header("基础组件")]
    //获取摩擦力组件
    public PhysicsMaterial2D noFriction;//没有摩擦力 跳跃使用
    public PhysicsMaterial2D haveFriction;//有摩擦力
    //获取角色的精灵渲染器组件
    public SpriteRenderer spriteRenderer;
    //获取角色的动画组件
    public Animator animator;
    //获取角色的刚体组件
    public Rigidbody2D rigidbody2;
    //获取角色的碰撞体组件
    public Collider2D collider2;
    //获取角色趴下时的碰撞体组件
    public Collider2D crouchCollider2;
    //获取的钻石的个数的文本组件
    public Text gemsText;
    //最大血量和血量文本组件
    public Text hpText;
    public Text maxHpText;
    //血条组件
    public Slider hpSlider;
    [Header("判断是否在地面的组件")]
    //地面检查点
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    [Header("基础属性")]
    //血量
    public float hp = 100f;
    //最大血量
    public float maxHp = 100f;
    //移动速度
    public float speed;
    //得分
    public int Score = 0;
    //跳跃力
    public float jumpForce;
    //受伤状态
    public bool isHurt = false;
    //死亡状态
    public bool isDead = false;
    //是否在地面上
    public bool isGround;
    //是否可以二段跳
    public bool isDoubleJump = false;
    //是否在一段跳
    private bool isJump = true;
    //是否趴下
    public bool isCrouch = false;
    //受伤的力
    private float hurtForce = 5f;
    //无敌时间
    public float invincibleLength;
    //无敌倒计时
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
        //在无敌时间没有结束时，自减
        if (invincbleCounter > 0)
        {
            invincbleCounter -= Time.deltaTime;
            //在无敌结束时将颜色改变回去
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
    /// 初始化
    /// </summary>
    public void Init()
    {
        isDead = false;
        enabled = true;
        isCrouch = false;
        //默认关闭趴下时的碰撞体
        crouchCollider2.enabled = false;

        #region 初始化血量
        //将玩家的最大血量赋值给血量条的最大值
        hpSlider.maxValue = maxHp;
        hpSlider.value = hp;
        //将玩家的最大血量赋值给最大血量显示的文本
        maxHpText.text = maxHp.ToString();
        //将血量赋值给血量的显示文本
        hpText.text = hp.ToString();
        #endregion

        #region 初始化得分
        Score = 0;
        gemsText.text = Score.ToString();
        #endregion
    }

    /// <summary>
    /// 动画播放
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
    /// 移动
    /// </summary>
    public void Move()
    {
        rigidbody2.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2.velocity.y);
        //左右旋转方向
        if (Input.GetAxis("Horizontal") < 0)
            spriteRenderer.flipX = true;
        if (Input.GetAxis("Horizontal") > 0)
            spriteRenderer.flipX = false;
    }
    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump()
    {
        //跳跃时将没有摩擦力的材质赋值给玩家
        collider2.sharedMaterial = noFriction;
        //按下空格跳跃，并且是在地面上
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                //在地面上将有摩擦力的材质赋值给玩家
                collider2.sharedMaterial = haveFriction;
                //播放跳跃音效
                AudioManager.instance.PlaySFX(0);
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
                //不在地面上
                isGround = false;
                //物体正在一段跳
                isJump = true;
            }
            else if (isDoubleJump && !isGround && isJump)
            {
                //播放跳跃音效
                AudioManager.instance.PlaySFX(0);
                //再次进行跳跃
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
                //物体不再一段跳
                isJump = false;
            }
        }
    }
    /// <summary>
    /// 下蹲
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
    /// 受伤
    /// </summary>
    /// <param name="gameObject"></param>
    public void Hurt(GameObject gameObject)
    {
        //如果无敌时间到了，才可以收到伤害
        if (invincbleCounter <= 0)
        {
            //播放受伤音效
            AudioManager.instance.PlaySFX(1);
            isHurt = true;
            hp -= 10f;
            //受伤时使玩家加速度为0
            rigidbody2.velocity = Vector2.zero;
            //如果反转方向的选项没有勾上，说明玩家在左边，需要给受伤需要给一个相反的力
            if (!spriteRenderer.flipX)
            {
                rigidbody2.velocity = new Vector2(-hurtForce, rigidbody2.velocity.y);
            }
            else
            {
                rigidbody2.velocity = new Vector2(hurtForce, rigidbody2.velocity.y);
            }
                //将设置的无敌时间赋值给倒计时
                invincbleCounter = invincibleLength;
            //受伤改变无敌颜色
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, .7f);
        }
    }

    /// <summary>
    /// 死亡
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
        //碰到边界死亡
        if (collision.CompareTag("MapEdge"))
        {
            Dead();
        }
        //碰到旗子通关
        if (collision.CompareTag("Flag"))
        {
            enabled = false;
            //播放胜利音乐
            AudioManager.instance.PlayLevelVictory();
            //切换到关卡选择界面
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
            //碰到敌人时如果角色位置高于敌人，且速度向下，则视为踩到敌人
            GameObject enemyObj = collision.gameObject;
            if (transform.position.y > enemyObj.transform.position.y
                && rigidbody2.velocity.y < 0)
            {
                rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);//给予角色一个小跳
                enemyObj.GetComponent<Enemy>().Damaged();//调用敌人的受伤方法
            }
            else
            {
                Hurt(collision.gameObject);
                
            }
        }
    }
}
