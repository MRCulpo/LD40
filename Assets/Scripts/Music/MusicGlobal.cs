using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGlobal : Singleton<MusicGlobal>
{ 

    public AudioClip[] m_Sounds;

    public AudioSource m_AudioSource;

    void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void FXPlayOneShot(int id)
    {
        if(id < m_Sounds.Length)
        {
            m_AudioSource.PlayOneShot(m_Sounds[id], 1);
        }
    }

}
