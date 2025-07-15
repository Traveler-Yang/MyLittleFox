using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Enemy
{
    void Start()
    {
        //��ǰ���˵����Ҳ����λ�÷�Χ��ƫ����
        leftLimit = transform.position.x + leftLimit;
        rightLimit = transform.position.x + rightLimit;
        StartCoroutine(FrogJump());
    }

    
    void Update()
    {
        SetAnimation();
    }

    //���ܰ�������Ծ�ƶ�
    IEnumerator FrogJump()
    {
        while (true)
        {
            //�ȴ�3����Ծ
            yield return new WaitForSeconds(3f);
            //��ת����
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
            //ת���ʱ��
            yield return new WaitForSeconds(0.1f);

            float moveDistance = speed * direction * Time.deltaTime;
            Vector3 newPostion = transform.position += new Vector3(moveDistance, 0, 0);
            newPostion.x = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
            Jump();
            //�ƶ���Ծ
            rigidbody2.AddForce(new Vector2(direction * rigidbody2.velocity.y * jumpForce, rigidbody2.velocity.y));
        }
    }
}
