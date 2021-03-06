﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower")]
public class TowerAsset : ScriptableObject
{
    [SerializeField]
    private float m_attackRadius, m_cooldown;
    [SerializeField]
    private int m_health;
    [SerializeField]
    private GameObject m_projectile;

    public float AttackRadius
    {
        get { return m_attackRadius; }
    }
    public float Cooldown
    {
        get { return m_cooldown; }
    }
    public int Heath
    {
        get { return m_health; }
    }
    public GameObject projectile
    {
        get { return m_projectile; }
    }
}
