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
    /// 游戏暂停
    /// </summary>
    public void TimeScale_0()
    {
        Time.timeScale = 0;
    }

    /// <summary>
    /// 游戏开始
    /// </summary>
    public void TimeScale_1()
    {
        Time.timeScale = 1;
    }
    /// <summary>
    /// 退出游戏
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
