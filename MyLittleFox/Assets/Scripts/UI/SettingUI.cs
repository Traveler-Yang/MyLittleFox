using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    //��ȡ���������
    public Slider sliderAudio;
    //��ȡ�������
    public AudioSource audioSource;
    void Start()
    {
        //�����������ֵ��ֵ������
        if (AudioManager.instance == null)
        {
            audioSource.volume = sliderAudio.maxValue;
            audioSource.volume = PlayerPrefs.GetFloat("Audio"); ;
            sliderAudio.value = PlayerPrefs.GetFloat("Audio"); ;
            return;
        }
        AudioManager.instance.bgm.volume = sliderAudio.maxValue;
        //float ad = PlayerPrefs.GetFloat("Audio");
        AudioManager.instance.bgm.volume = PlayerPrefs.GetFloat("Audio"); ;
        sliderAudio.value = PlayerPrefs.GetFloat("Audio"); ;
    }

    
    void Update()
    {
        //��������ֵÿ֡��ֵ������
        if (AudioManager.instance == null)
        {
            audioSource.volume = sliderAudio.value;
            PlayerPrefs.SetFloat("Audio", audioSource.volume);
            return;
        }
        AudioManager.instance.bgm.volume = sliderAudio.value;
        PlayerPrefs.SetFloat("Audio", AudioManager.instance.bgm.volume);
    }
}
