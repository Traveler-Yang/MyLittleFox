using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("类型")]
    //单位类型和敌人类型
    public Unit_Type unitType;
    public Enemy_type enemyType;
    [Header("基础组件")]
    //获取角色的精灵渲染器组件
    public SpriteRenderer spriteRenderer;
    //获取角色的动画组件
    public Animator animator;
    //获取角色的刚体组件
    public Rigidbody2D rigidbody2;
    //获取角色的碰撞体组件
    public Collider2D collider2;
    [Header("基础属性")]
    //移动速度
    public float speed;
    //跳跃力
    public float jumpForce;
    //受伤状态
    public bool isHurt = false;
    //是否在地面上
    public bool isGround;

    [Header("")]
    //当前敌人位置的左侧限制
    public float leftLimit;
    //当前敌人位置的右侧限制
    public float rightLimit;
    //自身
    public GameObject obj;
    //死亡动画
    public GameObject death;
    //方向
    public int direction = -1;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// 动画播放
    /// </summary>
    public void SetAnimation()
    {
        animator.SetFloat("Jump", rigidbody2.velocity.y);
        animator.SetBool("IsGround", isGround);
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    public void Jump()
    {
        if (isGround)
        {
            rigidbody2.velocity = new Vector2(rigidbody2.velocity.x, jumpForce);
            isGround = false;
        }
    }

    //生成动画
    public void GenerateAni()
    {
        //生成死亡动画在敌人身上
        Instantiate(death, obj.transform.position, Quaternion.identity, null);
    }

    public void Damaged()
    {
        AudioManager.instance.PlaySFX(4);
        Death();
        //移除自己后播放死亡动画
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
            Debug.Log("Enemy在地面" + isGround);
            isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enemy不在地面" + isGround);
        isGround = false;
    }
}
