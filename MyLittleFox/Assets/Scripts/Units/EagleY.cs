using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleY : Enemy
{
    void Start()
    {
        //当前敌人的左右侧最大位置范围的偏移量
        leftLimit = transform.position.y + leftLimit;
        rightLimit = transform.position.y + rightLimit; 
    }

    
    void Update()
    {
        float moveDistance = speed * direction * Time.deltaTime;
        Vector3 newPostion = transform.position += new Vector3(0, moveDistance, 0);
        newPostion.y = Mathf.Clamp(transform.position.y, leftLimit, rightLimit);
        transform.position = newPostion;

        //如果超过活动范围就转向
        float posY = transform.position.y;
        if (posY <= leftLimit)
        {
            direction = 1;
        }
        else if (posY >= rightLimit)
        {
            direction = -1;
        }
    }
}
