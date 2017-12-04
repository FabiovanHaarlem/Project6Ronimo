
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit/UnitCosts")]
public class UnitCosts : ScriptableObject
{
    [SerializeField]
    [Header("Collector Unit")]
    private int m_CollectorCost;
    public int GetCollectorCost
    { get { return m_CollectorCost; } }

    [SerializeField]
    [Header("Melee Unit")]
    private int m_MeleeCost;
    public int GetMeleeCost
    { get { return m_MeleeCost; } }

    [SerializeField]
    [Header("Ranged Unit")]
    private int m_RangedCost;
    public int GetRangedCost
    { get { return m_RangedCost; } }

    [SerializeField]
    [Header("Spellcaster Unit")]
    private int m_SpellcasterCost;
    public int GetSpellcasterCost
    { get { return m_SpellcasterCost; } }

    [SerializeField]
    [Header("Special Unit")]
    private int m_SpecialCost;
    public int GetSpecialCost
    { get { return m_SpecialCost; } }
}
