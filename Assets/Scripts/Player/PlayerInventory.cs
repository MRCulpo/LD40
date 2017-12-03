using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int m_AmountToxin;
    private int m_AmountShit;
    private int m_AmountBiscuit;

    public void SetToxin(int value)
    {
        m_AmountToxin -= value;
    }

    public void SetShit()
    {
        m_AmountShit++;
    }

    public void SetBiscuit()
    {
        m_AmountBiscuit++;
    }

    public void RemoveBiscuit()
    {
        m_AmountBiscuit--;
        if (m_AmountBiscuit <= 0) m_AmountBiscuit = 0;
    }

    public void RemoveShit()
    { 
        m_AmountShit--;
        if (m_AmountShit <= 0) m_AmountShit = 0;
    }

    public int AmountToxin
    {
        get
        {
            return m_AmountToxin;
        }

    }

    public int AmountShit
    {
        get
        {
            return m_AmountShit;
        }

    }

    public int AmountBiscuit
    {
        get
        {
            return m_AmountBiscuit;
        }
    }
}
