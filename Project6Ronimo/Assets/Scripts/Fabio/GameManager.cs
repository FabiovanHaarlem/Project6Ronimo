using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerFactionEnum m_PlayerFaction;

    private SpellPool m_SpellPool;
	
	void Start ()
    {
        m_PlayerFaction = PlayerFactionEnum.Yagra;
        m_SpellPool = GameObject.Find("_System").GetComponent<SpellPool>();
        m_SpellPool.SetSpells(m_PlayerFaction);
    }

    public PlayerFactionEnum GetPlayersFaction()
    {
        return m_PlayerFaction;
    }

    public void SetPlayerFaction(PlayerFactionEnum playerFaction)
    {
        m_PlayerFaction = playerFaction;
    }

    public void SetAllSystems()
    {
        m_SpellPool = GameObject.Find("_System").GetComponent<SpellPool>();
        m_SpellPool.SetSpells(m_PlayerFaction);
    }
}
