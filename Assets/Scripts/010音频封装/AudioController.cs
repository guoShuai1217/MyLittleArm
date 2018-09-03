/*
 *		Description : 音频控制
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.31
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{

    private AudioSource m_bgMusic; //背景音乐

    private AudioSource m_effectMusic; // 音效

    private void Awake()
    {
        m_bgMusic = gameObject.AddComponent<AudioSource>();
        m_effectMusic = gameObject.AddComponent<AudioSource>();

        m_bgMusic.loop = true;
        m_bgMusic.playOnAwake = true;

        m_effectMusic.loop = false;
        m_effectMusic.playOnAwake = false;
    }

    /// <summary>
    /// 背景声音
    /// </summary>
    public float BgVolume
    {
        get { return m_bgMusic.volume; }
        set { m_bgMusic.volume = value; }
    }

    /// <summary>
    /// 音效声音
    /// </summary>
    public float EffectVolume
    {
        get { return m_effectMusic.volume; }
        set { m_effectMusic.volume = value; }
    }

    /// <summary>
    /// 播放音乐
    /// </summary>
    /// <param name="enumName"></param>
    /// <param name="isRestart"></param>
    public void PlayMusicBase(object enumName ,bool isRestart)
    {
        if (m_bgMusic.clip != null && m_bgMusic.clip.name == enumName.ToString() && isRestart == false)
        {
            return;
        }
        //  AudioClip m_clip = Resources.Load<AudioClip>("Music/Main/" + bgName);
        //  这样写很麻烦 , 用封装的 ResourcesCtr 来获取路径
        AudioClip m_clip = ResourceController.Instance.LoadObject<AudioClip>(enumName);
        if (m_clip != null)
        {
            m_bgMusic.clip = m_clip;
            m_bgMusic.Play();
        }
        else
        {
            Debug.LogError("背景音乐不存在");
        }
    }

    /// <summary>
    /// 停止音乐
    /// </summary>
    public void StopMusic()
    {
        m_bgMusic.clip = null;
        m_bgMusic.Stop();
    }


    // 用来存储经常播放的音效
    public Dictionary<object, AudioClip> EffectBuffer = new Dictionary<object, AudioClip>();


    // effectEnum 是传进来的枚举 , IsEffectBuffer表示是否需要存到字典里
    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="effectEnum"></param>
    /// <param name="IsEffectBuffer"></param>
    /// <param name="volume"></param>
    public void PlayEffectMusic(object effectEnum, bool IsEffectBuffer = false, float volume = 1f)
    {
        AudioClip clip = null;
        // 字典里有就用字典里的 , 字典里没有就去Resources里加载
        if (EffectBuffer.ContainsKey(effectEnum))
        {
            clip = EffectBuffer[effectEnum];
        }
        else
        {
            clip = ResourceController.Instance.LoadObject<AudioClip>(effectEnum);
            EffectBuffer.Add(effectEnum,clip);
        }
      
        m_effectMusic.PlayOneShot(clip, volume);
    }



























    public void PlayMusic(MusicConfig.Music_Main main,bool isRestart = false)
    {
        PlayMusicBase(main, isRestart);
    }


    public void PlayMusic(MusicConfig.Music_Effect main,bool isRestart = false)
    {
        PlayMusicBase(main, isRestart);
    }

    public void PlayMusic(MusicConfig.Music_Dialog main, bool isRestart = false)
    {
        PlayMusicBase(main, isRestart);
    }









}
