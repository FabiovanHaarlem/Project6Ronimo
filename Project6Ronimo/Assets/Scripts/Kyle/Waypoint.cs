using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    Transform m_rightwaypoint;

    [SerializeField]
    Transform m_leftwaypoint;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<UnitMovement>().MoveTo(m_rightwaypoint);
        }
        else if(other.CompareTag("AI"))
        {
            other.gameObject.GetComponent<UnitMovement>().MoveTo(m_leftwaypoint);
        }
    }
}
