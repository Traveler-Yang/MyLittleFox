using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleY : Enemy
{
    void Start()
    {
        //��ǰ���˵����Ҳ����λ�÷�Χ��ƫ����
        leftLimit = transform.position.y + leftLimit;
        rightLimit = transform.position.y + rightLimit; 
    }

    
    void Update()
    {
        float moveDistance = speed * direction * Time.deltaTime;
        Vector3 newPostion = transform.position += new Vector3(0, moveDistance, 0);
        newPostion.y = Mathf.Clamp(transform.position.y, leftLimit, rightLimit);
        transform.position = newPostion;

        //����������Χ��ת��
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
