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
        //����������ε��󣬵ȴ�һ��ʱ����ٸ���
        Player.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        Player.instance.gameObject.SetActive(true);
        //������״̬�ر�
        Player.instance.isDead = false;
        //����һ���浵λ�ø�ֵ�����
        Player.instance.transform.position = CheckPointContorller.instance.spawnPoint;
        //��Ѫ����ʼ��
        Player.instance.hp = Player.instance.maxHp;
    }
}
