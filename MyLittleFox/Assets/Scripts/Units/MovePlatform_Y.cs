using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform_Y : MonoBehaviour
{
    //上侧限制坐标
    public float downLimit;
    //下侧限制坐标
    public float upLimit;
    //移动速度
    public float speed;
    //方向
    public float direction = 1;
    void Start()
    {
        upLimit = transform.position.y + upLimit;
        downLimit = transform.position.y + downLimit;
    }

    
    void Update()
    {
        float moveDistance = speed * direction * Time.deltaTime;
        Vector3 newPostion = transform.position += new Vector3(0, moveDistance, 0);
        newPostion.y = Mathf.Clamp(transform.position.y, upLimit, downLimit);
        transform.position = newPostion;

        //如果超过活动范围就转向
        float posY = transform.position.y;
        if (posY <= upLimit)
        {
            direction = 1;
        }
        else if (posY >= downLimit)
        {
            direction = -1;
        }
    }
}
