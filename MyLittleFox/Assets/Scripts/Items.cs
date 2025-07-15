using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SocialPlatforms.Impl;

public class Items : MonoBehaviour
{
    public Item_Type type;
    //当前的树莓或钻石
    public GameObject obj;
    //触碰到的得分动画
    public GameObject obj2;
    //树莓可以回多少血量
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
        
        //触碰到玩家
        if (collision.gameObject.tag == "Player")
        {
            //如果碰到浆果，并且血量大于或等于最大血量，则碰不到树莓
            if (type == Item_Type.Cherry && p.hp >= p.maxHp)
            {
                return;
            }
            else
            {
                //如果是碰到钻石，则加分
                if (type == Item_Type.Gem)
                {

                    //播放触碰音效
                    AudioManager.instance.PlaySFX(2);
                    p.Score += 1;
                    p.gemsText.text = p.Score.ToString();
                }//碰到树莓，加血
                else if (type == Item_Type.Cherry)
                {
                    //播放触碰音效
                    AudioManager.instance.PlaySFX(3);
                    //如果回的血量超过了最大的血量，则直接让玩家的最大血量赋值给当前血量
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
                //显现出得分动画
                Instantiate(obj2, obj.transform.position, Quaternion.identity);
            }
        }
    }
}
