using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelectSystem : MonoBehaviour
{
    private GameManager m_GameManager;
    private SpellPool m_SpellPool;
    private SpellSpawner m_SpellSpawner;

    private SpellHolder m_CurrentSelectedSpell;

    void Start()
    {
        m_SpellPool = GetComponent<SpellPool>();
        m_SpellSpawner = GetComponent<SpellSpawner>();
    }

    public void ActivateSpell(int spellIndex)
    {
        SpellHolder spell = m_SpellPool.GetSpells(spellIndex);

        m_CurrentSelectedSpell = spell;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_CurrentSelectedSpell != null)
            {
                Vector3 selectedPosition = GetSelectedPosition();
                m_SpellSpawner.SpawnSpell(m_CurrentSelectedSpell, selectedPosition);
            }
        }
    }

    public Vector3 GetSelectedPosition()
    {
        Vector3 pos = new Vector3();
        return pos;
    }
}
