using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointContorller : MonoBehaviour
{

    public static CheckPointContorller instance;
    //�洢���������д浵�������
    private CheckPoint[] checkPoints;
    //�浵λ��
    public Vector3 spawnPoint;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //�ڳ����в������д浵��Ķ���
        checkPoints = FindObjectsOfType<CheckPoint>();

        spawnPoint = Player.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //���ô浵��
    public void DeactivateCheckPoints()
    {
        //�������д浵�㣬������
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].ResetCheckPoint();
        }
    }

    //����浵��
    public void SetSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
