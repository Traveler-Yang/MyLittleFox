using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    //获取拉条的组件
    public Slider sliderAudio;
    //获取音量组件
    public AudioSource audioSource;
    void Start()
    {
        //将拉条的最大值赋值给音量
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
        //让拉条的值每帧赋值给音量
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
