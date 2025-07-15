using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //������Ⱦ�����
    public SpriteRenderer thisSR;
    //���ĵĿ����͹رվ���ͼƬ
    public Sprite spOn, spOff;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //�������еĴ浵��
            CheckPointContorller.instance.DeactivateCheckPoints();

            thisSR.sprite = spOn;
            //���浵���λ�ñ���
            CheckPointContorller.instance.SetSpawnPoint(transform.position);
        }
    }
    //�رռ���
    public void ResetCheckPoint()
    {
        thisSR.sprite = spOff;
    }
}
