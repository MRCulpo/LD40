using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvas : MonoBehaviour
{
    private PlayerInventory m_PlayerInventory;
    [SerializeField]
    private Text m_TextBiscuit;
    [SerializeField]
    private Text m_TextShit;

    private void Awake()
    {
        m_PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    public void UpdateShit()
    {
        //m_TextShit.text = m_PlayerInventory
    }
    public void UpdateBiscuit() { }
    public void UpdateToxic() { }
}
