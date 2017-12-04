using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spells/YagraSpell1")]
public class Spells : ScriptableObject
{
    [SerializeField]
    [Header("Duration")]
    private int m_SpellDuration;
    public int GetSpellDuration
    { get { return m_SpellDuration; } }

    [SerializeField]
    [Header("Mana Cost")]
    private int m_ManaCost;
    public int GetManaCost
    { get { return m_ManaCost; } }
}
