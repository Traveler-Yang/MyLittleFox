using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //精灵渲染器组件
    public SpriteRenderer thisSR;
    //检查的的开启和关闭精灵图片
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
            //禁用所有的存档点
            CheckPointContorller.instance.DeactivateCheckPoints();

            thisSR.sprite = spOn;
            //将存档点的位置保存
            CheckPointContorller.instance.SetSpawnPoint(transform.position);
        }
    }
    //关闭检查点
    public void ResetCheckPoint()
    {
        thisSR.sprite = spOff;
    }
}
