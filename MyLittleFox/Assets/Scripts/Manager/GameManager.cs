using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// ��Ϸ��ͣ
    /// </summary>
    public void TimeScale_0()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// ��Ϸ��ʼ
    /// </summary>
    public void TimeScale_1()
    {
        Time.timeScale = 1;
    }
    /// <summary>
    /// �˳���Ϸ
    /// </summary>
    public void GameExit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}
