using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPool : MonoBehaviour
{
    private SpellHolder[] m_Spells;

    private SpellDamage m_PlayerSpellDamage;
    private SpellHeal m_PlayerSpellHeal;
    private SpellDamage m_AISpellDamage;
    private SpellHeal m_AISpellHeal;

    [SerializeField]
    private Spells m_SpellsValue;
    
    private int m_AmountOfSpells;


    public void MakeSpellObjects()
    {
        m_PlayerSpellDamage = new SpellDamage();
        m_PlayerSpellHeal = new SpellHeal();
        m_AISpellDamage = new SpellDamage();
        m_AISpellHeal = new SpellHeal();

        m_AmountOfSpells = 4;
        m_Spells = new SpellHolder[4];

        for (int i = 0; i < m_AmountOfSpells; i++)
        {
            GameObject spell = GameObject.CreatePrimitive(PrimitiveType.Cube); ;
            spell.AddComponent<SpellHolder>();
            BoxCollider collider = spell.GetComponent<BoxCollider>();
            collider.isTrigger = true;
            collider.size = new Vector2(2f, collider.size.y);
            spell.gameObject.SetActive(false);
            m_Spells[i] = (spell.GetComponent<SpellHolder>());
        }

        m_Spells[0].SetSpell(m_PlayerSpellDamage, m_SpellsValue);
        m_Spells[0].gameObject.name = "PlayerSpellDamage";
        m_Spells[1].SetSpell(m_PlayerSpellHeal, m_SpellsValue);
        m_Spells[1].gameObject.name = "PlayerSpellHeal";
        m_Spells[2].SetSpell(m_AISpellDamage, m_SpellsValue);
        m_Spells[2].gameObject.name = "AISpellDamage";
        m_Spells[3].SetSpell(m_AISpellHeal, m_SpellsValue);
        m_Spells[3].gameObject.name = "AISpellHeal";
    }



    public void SetSpells()
    {
        MakeSpellObjects();
    }

    public SpellHolder GetSpells(int spellIndex)
    {
        return m_Spells[spellIndex];
    }
}
