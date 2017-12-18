using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerState
{
    void Start();   // Is called at the first frame of the state
    void Update();  // Is called every frame when the state is active
    void End();     // Is called at the last frame of the state
}

public class TowerStateIdle : ITowerState
{
    private Tower m_tower; // The tower

    public TowerStateIdle(Tower tower)
    {
        m_tower = tower;
    }

    public void Start()
    {

    }

    public void Update()
    {
        Debug.Log(m_tower.Enemys.Count);

        for (int i = 0; i < m_tower.Enemys.Count; i++)
        {
            float distance = Vector3.Distance(m_tower.transform.position, m_tower.Enemys[i].transform.position);
            Debug.Log("Distance: " + distance);
            if (distance < m_tower.AttackRadius)
            {
                m_tower.SwitchState(new TowerStateAttack(m_tower));
            }
        }
    }

    public void End()
    {

    }
}

public class TowerStateAttack : ITowerState
{
    private Tower m_tower; // The tower
    private float m_cooldown; // The time the tower takes to 'cool down'
    private float m_cooldownTimer; // The current time in the cooldown

    public TowerStateAttack(Tower tower)
    {
        m_tower = tower;
        m_cooldown = m_tower.Cooldown;
        m_cooldownTimer = 0;
    }

    public void Start()
    {

    }

    public void Update()
    {
        float distance = Int32.MaxValue;
        GameObject target = null;

        for (int i = 0; i < m_tower.Enemys.Count; i++)
        {
            float newDistance = Vector3.Distance(m_tower.transform.position, m_tower.Enemys[i].transform.position);

            if (newDistance < m_tower.AttackRadius 
            && newDistance < distance)
            {
                target = m_tower.Enemys[i];
                distance = newDistance;
            }
        }

        m_tower.CurrentTarget = target;

        if (target == null)
            m_tower.SwitchState(new TowerStateIdle(m_tower));

        if (m_cooldownTimer > m_cooldown)   // Check if the tower is ready to shoot
        {
            m_tower.Shoot();        // Tell the tower to shoot
            m_cooldownTimer = 0;    // Reset the cooldown timer
        }
        
        m_cooldownTimer += Time.deltaTime;  // Time the cooldown timer
    }

    public void End()
    {

    }
}