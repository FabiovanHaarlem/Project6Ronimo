using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    UnitStats m_stats;

    void Start()
    {
        m_stats = GetComponent<UnitStats>();  
    }

    void Update ()
    {
		if(m_stats.m_health <= 0)
        {
            Die();
        }
	}

    public void DoDamage(Collider2D attackingobject)
    {
        attackingobject.gameObject.GetComponent<UnitAttack>().TakeDamage(m_stats.m_damage);
    }

    public void TakeDamage(int amountofdamage)
    {
        m_stats.m_health -= amountofdamage;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
