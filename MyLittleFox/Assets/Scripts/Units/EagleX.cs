using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleX : Enemy
{
    void Start()
    {
        //当前敌人的左右侧最大位置范围的偏移量
        leftLimit = transform.position.x + leftLimit;
        rightLimit = transform.position.x + rightLimit; 
    }

    
    void Update()
    {
        float moveDistance = speed * direction * Time.deltaTime;
        Vector3 newPostion = transform.position += new Vector3(moveDistance, 0, 0);
        newPostion.x = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = newPostion;

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
    }
}
