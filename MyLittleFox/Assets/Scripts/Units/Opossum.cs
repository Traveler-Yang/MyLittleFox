using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Enemy
{
    void Start()
    {
        //��ǰ���˵����Ҳ����λ�÷�Χ��ƫ����
        leftLimit = transform.position.x + leftLimit;
        rightLimit = transform.position.x + rightLimit;
    }

    // Update is called once per frame
    void Update()
    {
        float moveDistance = speed * direction * Time.deltaTime;
        Vector3 newPostion = transform.position += new Vector3(moveDistance, 0, 0);
        newPostion.x = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = newPostion;

        //����������Χ��ת��
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
