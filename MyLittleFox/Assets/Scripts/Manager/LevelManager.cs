using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(0.5f);
        //将玩家移屏蔽掉后，等待一段时间后，再复活
        Player.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        Player.instance.gameObject.SetActive(true);
        //将死亡状态关闭
        Player.instance.isDead = false;
        //将上一个存档位置赋值给玩家
        Player.instance.transform.position = CheckPointContorller.instance.spawnPoint;
        //将血量初始化
        Player.instance.hp = Player.instance.maxHp;
    }
}
