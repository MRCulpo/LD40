using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClockManager : MonoBehaviour
{

    public Text t_min;
    public Text t_sec;

    public int totalSeconds;

    [SerializeField]
    private float m_CurrentSec;
    [SerializeField]
    private int m_CurrentMin;

    private bool isCount = true;

    private void Start()
    {
        m_CurrentSec = 0;
        m_CurrentMin = 0;
        SecsToWin(totalSeconds);
    }

    private void Update()
    {
        Countdown();
    }

    public void SecsToWin(int _sec)
    {

        m_CurrentSec = _sec % 60;
        _sec /= 60;
        m_CurrentMin = _sec % 60;
    }



    public void Countdown()
    {
        if (!isCount)
            return;


        if (m_CurrentMin >= 0 && m_CurrentSec >= 0)
        {
            m_CurrentSec -= Time.deltaTime * 1;
            if (m_CurrentSec <= 0 && m_CurrentMin != 0)
            { 
                m_CurrentMin--;
                m_CurrentSec = 60;
                DrawMin();
            }
            DrawSec();
        }

        if (m_CurrentMin <= 0 && m_CurrentSec <= 0)
        {
            m_CurrentSec = 0;
            m_CurrentMin = 0;
            //Chamar vitoria

            DrawMin();
            DrawSec();
            isCount = false;
            SceneManager.LoadScene("Success");
        }
    }

    void DrawSec()
    {
        if (m_CurrentSec >= 0)
        {
            if (m_CurrentSec < 10)
                t_sec.text = "0" + ((int)m_CurrentSec).ToString();
            else
                t_sec.text = ((int)m_CurrentSec).ToString();
        }
    }

    void DrawMin()
    {
        if (m_CurrentMin >= 0)
        {
            if (m_CurrentMin < 10)
                t_min.text = "0" + m_CurrentMin.ToString();
            else
                t_min.text = m_CurrentMin.ToString();
        }
    }
}

