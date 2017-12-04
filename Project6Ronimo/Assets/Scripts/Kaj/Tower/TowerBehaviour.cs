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