using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractObjects : MonoBehaviour {

    [SerializeField]
    private GameObject m_pick;

    [SerializeField, Header("Biscoito para dropar")]
    private GameObject m_biscuit;


    [SerializeField, Header("Remedio para dropar")]
    private GameObject m_recoverToxin;

    private GameObject m_RefShit;
    private GameObject m_RefCat;

    private bool m_CatchShit = false;
    private bool m_CatchCat = false;

    private PlayerInventory m_Inventory;

    private void Awake()
    {
        m_Inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.J))
        {
            if(m_RefShit != null)
            {
                m_Inventory.RemoveShit();
                DropBiscuit();
                Destroy(m_RefShit);
            }
            //else if(m_RefCat != null)
            //{
            //    /// Aciona o Gato e da biscoito
            //}
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(m_RefShit == null && collision.tag == "Shit" )
        {
            m_pick.SetActive(true);

            m_RefShit = collision.gameObject;
            m_CatchShit = true;
        }
        //else if(m_RefCat == null && collision.tag == "Cat")
        //{
        //    m_pick.SetActive(true);
        //    m_RefCat = collision.gameObject;
        //    m_CatchCat = true;
        //}
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "Biscuit")
        {
            m_Inventory.SetBiscuit();
            Destroy(collision.gameObject, 1f);
        }

        if (m_RefShit == null && collision.tag == "Shit")
        {
            m_pick.SetActive(true);

            m_RefShit = collision.gameObject;
            m_CatchShit = true;
        }
        //else if(m_RefCat == null && collision.tag == "Cat")
        //{
        //    m_pick.SetActive(true);
        //    m_RefCat = collision.gameObject;
        //    m_CatchCat = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (m_RefShit != null && collision.tag == "Shit")
        {
            if (collision.gameObject.Equals(m_RefShit))
            {
                m_pick.SetActive(false);
                m_RefShit = null;
                m_CatchShit = false;
            }
        }
        //else if (m_RefCat != null && collision.tag == "Cat")
        //{
        //    m_pick.SetActive(false);
        //    m_RefCat = collision.gameObject;
        //    m_CatchCat = true;
        //}
    }

    private void DropBiscuit()
    {
        int _randon = Random.Range(0, 100);
        if (_randon <= 25)
        {
            GameObject _biscuit = Instantiate(m_biscuit);
            _biscuit.transform.position = transform.position;
        }
    }
}
