using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointContorller : MonoBehaviour
{

    public static CheckPointContorller instance;
    //存储场景内所有存档点的数组
    private CheckPoint[] checkPoints;
    //存档位置
    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //在场景中查找所有存档点的对象
        checkPoints = FindObjectsOfType<CheckPoint>();

        spawnPoint = Player.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //禁用存档点
    public void DeactivateCheckPoints()
    {
        //遍历所有存档点，并禁用
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }

    //保存存档点
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
