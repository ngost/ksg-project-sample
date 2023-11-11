using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioSource m_audioSource;

    public AudioClip stage1;
    public AudioClip stage2;
    public AudioClip stage3;
    public AudioClip stage4;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void SetBGM(int level){
        switch(level){
            case 1:
                if(m_audioSource.clip == stage1)
                    break;
                m_audioSource.clip = stage1;
                m_audioSource.Play();
                break;
            case 2:
                if(m_audioSource.clip == stage2)
                    break;
                m_audioSource.clip = stage2;
                m_audioSource.Play();
                break;
            case 3:
                if(m_audioSource.clip == stage3)
                    break;
                m_audioSource.clip = stage3;
                m_audioSource.Play();
                break;
            case 4:
                if(m_audioSource.clip == stage4)
                    break;
                m_audioSource.clip = stage4;
                m_audioSource.Play();
                break;
        }
    }
}
