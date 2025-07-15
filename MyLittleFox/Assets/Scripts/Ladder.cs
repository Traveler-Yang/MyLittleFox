using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;//垂直输入
    private float speed = 3f;//爬梯子的速度
    private bool isLadder;//是否在梯子上
    private bool isClimbing;//是否是在爬梯子状态

    public Animator anim;

    public Rigidbody2D rb;
    void Start()
    {
    }

    
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        //在梯子上，并且按上下键有值的时候（MathfAbs是得到此值的绝对值）
        if (isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            //让角色没有重力
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            //如果没有攀爬，则恢复重力
            rb.gravityScale = 4f;
        }
    }
    //触碰到梯子，则开始攀爬梯子
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            isClimbing = true;
            anim.SetBool("Climbing", true);
        }
    }
    //离开梯子时，退出爬梯子的状态
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
