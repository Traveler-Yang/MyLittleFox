using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform_Y : MonoBehaviour
{
    //�ϲ���������
    public float downLimit;
    //�²���������
    public float upLimit;
    //�ƶ��ٶ�
    public float speed;
    //����
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

        //����������Χ��ת��
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
