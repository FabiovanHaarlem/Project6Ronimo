using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    bool m_iamaplayerswitch;
    [SerializeField]
    bool m_iamgoingup;

    [SerializeField]
    Transform m_uppath;

    [SerializeField]
    Transform m_downpath;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (m_iamgoingup == true)
        {
            if(CompareTag("Player") && m_iamaplayerswitch == true)
            {
                other.gameObject.GetComponent<UnitMovement>().MoveTo(m_uppath);
            }
            else if (CompareTag("AI") && m_iamaplayerswitch == false)
            {
                other.gameObject.GetComponent<UnitMovement>().MoveTo(m_uppath);
            }
            else if (CompareTag("Player") && m_iamaplayerswitch == false)
            {
                Debug.Log("Follow original Player chosen path");
            }
            else if (CompareTag("AI") && m_iamaplayerswitch == true)
            {
                Debug.Log("Follow original AI chosen path");
            }
        }
        else if (m_iamgoingup == false)
        {
            if(CompareTag("Player") && m_iamaplayerswitch == true)
            {
                other.gameObject.GetComponent<UnitMovement>().MoveTo(m_uppath);
            }
            else if(CompareTag("AI") && m_iamaplayerswitch == false)
            {
                other.gameObject.GetComponent<UnitMovement>().MoveTo(m_downpath);
            }
            else if(CompareTag("Player") && m_iamaplayerswitch == false)
            {
                Debug.Log("Follow original Player chosen path");
            }
            else if(CompareTag("AI") && m_iamaplayerswitch == true)
            {
                Debug.Log("Follow original AI chosen path");
            }
        }
    }
}
