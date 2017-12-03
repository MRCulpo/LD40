using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int m_AmountToxin = 0;
    private int m_AmountShit = 0;
    private int m_AmountBiscuit = 0;

    public int MAX_AmountToxin = 100;

    private void Start()
    {
        InvokeRepeating("ApplyToxin", 0f, GameAutoConfig.instance.m_TimeApplyToxin);
        InventoryCanvas.instance.UpdateAll();
    }

    public void SetToxin(int value)
    {
        m_AmountToxin += value;
    }

    public void SetShit()
    {
        m_AmountShit++;
        InventoryCanvas.instance.UpdateShit();
    }

    public void SetBiscuit()
    {
        m_AmountBiscuit++;

        InventoryCanvas.instance.UpdateBiscuit();
    }

    public void RemoveBiscuit()
    {
        m_AmountBiscuit--;

        if (m_AmountBiscuit <= 0)
            m_AmountBiscuit = 0;

        InventoryCanvas.instance.UpdateBiscuit();
    }

    public void RemoveShit()
    { 
        m_AmountShit--;
        if (m_AmountShit <= 0) m_AmountShit = 0;
        InventoryCanvas.instance.UpdateShit();
    }

    public void ApplyToxin()
    {
        SetToxin(m_AmountShit);
        InventoryCanvas.instance.UpdateToxin();
    }

    public int GetBiscuit() { return m_AmountBiscuit; }
    public int GetShit() { return m_AmountShit; }
    public int GetToxin() { return m_AmountToxin; }
}

