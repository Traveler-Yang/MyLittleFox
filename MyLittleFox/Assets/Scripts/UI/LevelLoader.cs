using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.TimeZoneInfo;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;
    //�����л�����
    public Animator animator;
    //�ȴ���ʱ��
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
    /// ��һ���ؿ�
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
    /// ѡ��ؿ�����
    /// </summary>
    public void LevelPanelSelct()
    {
        StartCoroutine(LevelPanel());
    }
    /// <summary>
    /// ��һ��
    /// </summary>
    public void Level1()
    {
        StartCoroutine(Levle_01());
    }
    /// <summary>
    /// �ڶ���
    /// </summary>
    public void Level2()
    {
        StartCoroutine(Levle_02());
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //�����л�����
        animator.SetTrigger("Start");
        //�ȴ�����
        yield return new WaitForSeconds(transitionTime);
        //�л�����
        SceneManager.LoadScene(levelIndex);
    }

    /// <summary>
    /// �ؿ�ѡ�����
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
    /// ��һ��
    /// </summary>
    /// <returns></returns>
    IEnumerator Levle_01()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    SceneManager.LoadScene("Level_01");
    }
    /// <summary>
    /// �ڶ���
    /// </summary>
    /// <returns></returns>
    IEnumerator Levle_02()
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level_02");
    }
}
