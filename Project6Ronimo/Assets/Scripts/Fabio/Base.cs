using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField]
    private bool m_PlayerBase;
    [SerializeField]
    private PlayerResources m_PlayerResources;
    [SerializeField]
    private Transform UnitStartingPoint;
    [SerializeField]
    private AIResources m_AIResources;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collector"))
        {
            if (m_PlayerBase)
            {
                m_PlayerResources.AddGold(40);
            }
            else if (!m_PlayerBase)
            {
                m_AIResources.AddGold(40);
            }
        }
    }
}
