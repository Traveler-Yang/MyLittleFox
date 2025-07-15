using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    //场景切换动画
    public Animator animator;
    //等待的时间
    public float transitionTime;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 下一个关卡
    /// </summary>
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void MainPanelSelct()
    {
        StartCoroutine(MainPanel());
    }

    /// <summary>
    /// 选择关卡界面
    /// </summary>
    public void LevelPanelSelct()
    {
        StartCoroutine(LevelPanel());
    }
    /// <summary>
    /// 第一关
    /// </summary>
    public void Level1()
    {
        StartCoroutine(Levle_01());
    }
    /// <summary>
    /// 第二关
    /// </summary>
    public void Level2()
    {
        StartCoroutine(Levle_02());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //播放切换动画
        animator.SetTrigger("Start");
        //等待播放
        yield return new WaitForSeconds(transitionTime);
        //切换场景
        SceneManager.LoadScene(levelIndex);
    }

    /// <summary>
    /// 关卡选择界面
    /// </summary>
    /// <returns></returns>
    IEnumerator LevelPanel()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level");
    }

    IEnumerator MainPanel()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Main");
    }

    /// <summary>
    /// 第一关
    /// </summary>
    /// <returns></returns>
    IEnumerator Levle_01()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene("Level_01");
    }
    /// <summary>
    /// 第二关
    /// </summary>
    /// <returns></returns>
    IEnumerator Levle_02()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_02");
    }
}
