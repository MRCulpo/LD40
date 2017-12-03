using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvas : Singleton<InventoryCanvas>
{
    private PlayerInventory m_PlayerInventory;
    [SerializeField]
    private Text m_TextBiscuit;
    [SerializeField]
    private Text m_TextShit;
    [SerializeField]
    private Text m_TextToxic;
    [SerializeField]
    private RectTransform m_ToxinTransform;


    private Vector2 m_TotalRect;

    private void Awake()
    {
        m_PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        m_TotalRect = m_ToxinTransform.GetComponent<RectTransform>().sizeDelta;
        m_ToxinTransform.sizeDelta = new Vector2(m_ToxinTransform.sizeDelta.x, 0);
    }

    public void UpdateAll()
    {
        UpdateBiscuit();
        UpdateShit();
        UpdateToxin();
    }

    public void UpdateShit()
    {
        m_TextShit.text = m_PlayerInventory.GetShit().ToString();
    }
    public void UpdateBiscuit()
    {
        m_TextBiscuit.text = m_PlayerInventory.GetBiscuit().ToString();

    }
    public void UpdateToxin()
    {
        StartCoroutine(EnumeratorToxin());
    }

    IEnumerator EnumeratorToxin()
    {
        int _CurrentToxin = (m_PlayerInventory.GetToxin() / GameAutoConfig.instance.m_DividerDificultToxin);
        float time = 2f;
        float elapsed = 0f;

        m_TextToxic.text = Mathf.Abs(_CurrentToxin).ToString() + "%";

        while (elapsed < time)
        {
            m_ToxinTransform.sizeDelta = Vector2.Lerp(m_ToxinTransform.sizeDelta,
                                                      new Vector2(m_ToxinTransform.sizeDelta.x, Mathf.Abs((m_TotalRect.y * _CurrentToxin) / m_PlayerInventory.MAX_AmountToxin)),
                                                      (elapsed / time));

            elapsed += Time.deltaTime;

            if (m_ToxinTransform.sizeDelta.y >= m_TotalRect.y)
            {
                m_ToxinTransform.sizeDelta = new Vector2(m_ToxinTransform.sizeDelta.x, m_TotalRect.y);
            }

            yield return null;
        }

       
    }
}
