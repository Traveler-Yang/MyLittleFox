using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    void Start()
    {
        //当前敌人的左右侧最大位置范围的偏移量
        leftLimit = transform.position.x + leftLimit;
        rightLimit = transform.position.x + rightLimit;
        StartCoroutine(FrogJump());
    }

    
    void Update()
    {
        SetAnimation();
    }

    //青蛙按规律跳跃移动
    IEnumerator FrogJump()
    {
        while (true)
        {
            //等待3秒跳跃
            yield return new WaitForSeconds(3f);
            //反转方向
            //如果超过活动范围就转向
            float posX = transform.position.x;
            if (posX <= leftLimit)
            {
                spriteRenderer.flipX = true;
                direction = 1;
            }
            else if (posX >= rightLimit)
            {
                spriteRenderer.flipX = false;
                direction = -1;
            }
            //转向的时间
            yield return new WaitForSeconds(0.1f);

            float moveDistance = speed * direction * Time.deltaTime;
            Vector3 newPostion = transform.position += new Vector3(moveDistance, 0, 0);
            newPostion.x = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
            Jump();
            //移动跳跃
            rigidbody2.AddForce(new Vector2(direction * rigidbody2.velocity.y * jumpForce, rigidbody2.velocity.y));
        }
    }
}
