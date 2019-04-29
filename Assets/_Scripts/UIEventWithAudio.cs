using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIEventWithAudio : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public AudioClip enterClip;
    public AudioClip clickClip;
    public AudioClip exitClip;
    protected AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = this.transform.parent.parent.GetComponent<AudioSource>();
        if (m_AudioSource == null)
        {
            m_AudioSource = this.transform.parent.parent.gameObject.AddComponent<AudioSource>();
            m_AudioSource.playOnAwake = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //点击
    public void OnPointerClick(PointerEventData eventData)
    {
        this.PlayAudio(this.clickClip);
    }
    //进入
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.PlayAudio(this.enterClip);
    }
    //退出
    public void OnPointerExit(PointerEventData eventData)
    {
        this.PlayAudio(this.exitClip);
    }
    //播放音乐
    private void PlayAudio(AudioClip ac)
    {
        if (ac == null)
        {
            return;
        }
        this.m_AudioSource.PlayOneShot(ac);
    }
}
