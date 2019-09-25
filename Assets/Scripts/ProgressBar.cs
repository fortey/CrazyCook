using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image Progress;

    float m_TotalTime;
    float m_StartTime;
    event Action m_OnFinish;
    
    void Update()
    {
        var duration = Time.unscaledTime - m_StartTime;
        if (duration >= m_TotalTime)
        {
            m_OnFinish?.Invoke();
            gameObject.SetActive(false);
        }
        Progress.fillAmount = duration / m_TotalTime;
    }

    public void StartTimer(float time, Action onFinish)
    {
        gameObject.SetActive(true);
        m_StartTime = Time.unscaledTime;
        m_TotalTime = time;
        m_OnFinish = onFinish;
    }

    public void Stop()
    {
        gameObject.SetActive(false);
    }
}
