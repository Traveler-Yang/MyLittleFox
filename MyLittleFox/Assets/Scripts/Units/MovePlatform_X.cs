using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform_X : MonoBehaviour
{
    //左侧限制坐标
    public float leftLimit;
    //右侧限制坐标
    public float rightLimit;
    //移动速度
    public float speed;
    //方向
    public float direction = 1;
    void Start()
    {
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
            direction = 1;
        }
        else if (posX >= rightLimit)
        {
            direction = -1;
        }
    }
}
