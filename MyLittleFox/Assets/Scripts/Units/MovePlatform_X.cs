using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform_X : MonoBehaviour
{
    //�����������
    public float leftLimit;
    //�Ҳ���������
    public float rightLimit;
    //�ƶ��ٶ�
    public float speed;
    //����
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

        //����������Χ��ת��
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
