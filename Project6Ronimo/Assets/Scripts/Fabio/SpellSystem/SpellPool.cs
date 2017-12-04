using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellPool : MonoBehaviour
{
    private SpellHolder[] m_Spells;

    private YagraSpell1 m_YagraSpell1;
    private YagraSpell2 m_YagraSpell2;
    private SeliosSpell1 m_SeliosSpell1;
    private SeliosSpell2 m_SeliosSpell2;
    private BakasuSpell1 m_BakasuSpell1;
    private BakasuSpell2 m_BakasuSpell2;
    
    private int m_AmountOfSpells;

    public void MakeSpellObjects()
    {
        m_YagraSpell1 = new YagraSpell1();
        m_YagraSpell2 = new YagraSpell2();
        m_SeliosSpell1 = new SeliosSpell1();
        m_SeliosSpell2 = new SeliosSpell2();
        m_BakasuSpell1 = new BakasuSpell1();
        m_BakasuSpell2 = new BakasuSpell2();

        m_AmountOfSpells = 4;
        m_Spells = new SpellHolder[4];

        for (int i = 0; i < m_AmountOfSpells; i++)
        {
            GameObject spell = new GameObject();
            spell.AddComponent<SpellHolder>();
            m_Spells[i] = (spell.GetComponent<SpellHolder>());
        }
    }

    public void SetSpells(PlayerFactionEnum playerFaction)
    {
        MakeSpellObjects();

        switch (playerFaction)
        {
            case PlayerFactionEnum.Yagra:
                m_Spells[0].SetSpell(m_YagraSpell1);
                m_Spells[1].SetSpell(m_YagraSpell2);
                break;
            case PlayerFactionEnum.Selios:
                m_Spells[0].SetSpell(m_SeliosSpell1);
                m_Spells[1].SetSpell(m_SeliosSpell2);
                break;
            case PlayerFactionEnum.Bakasu:
                m_Spells[0].SetSpell(m_BakasuSpell1);
                m_Spells[1].SetSpell(m_BakasuSpell2);
                break;
        }
    }

    public SpellHolder GetSpells(int spellIndex)
    {
        return m_Spells[spellIndex];
    }
}
