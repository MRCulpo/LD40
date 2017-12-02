using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObjetsPlayer : MonoBehaviour {

    private GameObject m_RefShit;
    private GameObject m_RefCat;

    private bool m_CatchShit = false;
    private bool m_CatchCat = false;

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            if(m_RefShit != null)
            {
                Destroy(m_RefShit);
            }
            else if(m_RefCat != null)
            {
                /// Aciona o Gato e da biscoito
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(m_RefShit == null && collision.tag == "Shit" )
        {
            m_RefShit = collision.gameObject;
            m_CatchShit = true;
        }
        else if(m_RefCat == null && collision.tag == "Cat")
        {
            m_RefCat = collision.gameObject;
            m_CatchCat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Shit")
        {
            m_RefShit = null;
            m_CatchShit = false;
        }
        else if (collision.tag == "Cat")
        {
            m_RefCat = collision.gameObject;
            m_CatchCat = true;
        }
    }
}
