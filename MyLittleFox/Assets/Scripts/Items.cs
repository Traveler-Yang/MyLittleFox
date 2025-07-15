using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;

public class Items : MonoBehaviour
{
    public Item_Type type;
    //��ǰ����ݮ����ʯ
    public GameObject obj;
    //�������ĵ÷ֶ���
    public GameObject obj2;
    //��ݮ���Իض���Ѫ��
    public int revitalize = 25;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player p = collision.gameObject.GetComponent<Player>();
        
        //���������
        if (collision.gameObject.tag == "Player")
        {
            //�����������������Ѫ�����ڻ�������Ѫ��������������ݮ
            if (type == Item_Type.Cherry && p.hp >= p.maxHp)
            {
                return;
            }
            else
            {
                //�����������ʯ����ӷ�
                if (type == Item_Type.Gem)
                {

                    //���Ŵ�����Ч
                    AudioManager.instance.PlaySFX(2);
                    p.Score += 1;
                    p.gemsText.text = p.Score.ToString();
                }//������ݮ����Ѫ
                else if (type == Item_Type.Cherry)
                {
                    //���Ŵ�����Ч
                    AudioManager.instance.PlaySFX(3);
                    //����ص�Ѫ������������Ѫ������ֱ������ҵ����Ѫ����ֵ����ǰѪ��
                    if (p.hp + revitalize >= p.maxHp)
                    {
                        p.hp = p.maxHp;
                    }
                    else
                    {
                        p.hp += revitalize;
                    }
                }
                this.gameObject.GetComponent<Collider2D>().enabled = false;
                Destroy(gameObject);
                //���ֳ��÷ֶ���
                Instantiate(obj2, obj.transform.position, Quaternion.identity);
            }
        }
    }
}
