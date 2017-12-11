using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region Variable initalization
    [SerializeField]
    private TowerAsset m_towerAsset;
    private GameObject m_projectile, m_currentTarget;
    private float m_attackRadius; //The radius in which a enemy has to be before the tower can shoot at it
    private float m_cooldown; //The attack cooldown, in seconds
    private int m_health;
    private Vector3 m_aimDirection;

    [SerializeField]
    private List<GameObject> m_enemys;

    private ITowerState m_currentState; // Holds the current state
    #endregion

    #region Unity Functions
    private void Start()
    {        
        m_attackRadius = m_towerAsset.AttackRadius;
        m_cooldown = m_towerAsset.Cooldown;
        m_health = m_towerAsset.Heath;
        m_currentState = new TowerStateAttack(this);
        m_projectile = m_towerAsset.projectile;
    }

    private void Update()
    {
        m_currentState.Update(); // Updates the current state

        // Update things that always need to be updated
        if (m_health < 0)
            Destroy();

        transform.LookAt(m_currentTarget.transform);
    }
    #endregion

    public void Shoot()
    {
        Vector3 normal = Vector3.Normalize(m_currentTarget.transform.position - transform.position);

        Debug.Log("Piew!");
        GameObject bullet = Instantiate(m_projectile);
        bullet.GetComponent<Rigidbody>().AddForce(normal * 900);
    }

    public void SwitchState(ITowerState state) // Switch the state of the tower, give new class of the state
    {
        m_currentState.End();   // Call the end of the current state
        m_currentState = state; // Switch the state
        m_currentState.Start(); // Call the start of the new state
    }

    public void RecieveDamage(int amount)
    {
        m_health -= amount;
    }

    public void Destroy()
    {
        Debug.Log("Ik ben nu kapot");
        //Destroy(gameObject);
    }

    #region Get/Set
    public float Cooldown
    {
        get { return m_cooldown; }
        set { m_cooldown = value; }
    }
    public float AttackRadius
    {
        get { return m_attackRadius; }
        set { m_attackRadius = value; }
    }
    public Vector3 AimDirection
    {
        get { return m_aimDirection; }
        set { m_aimDirection = value; }
    }
    public GameObject CurrentTarget
    {
        get { return m_currentTarget; }
        set { m_currentTarget = value; }
    }
    public List<GameObject> Enemys
    {
        get { return m_enemys; }
        set { m_enemys = value; }       
    }
    public TowerAsset TowerAsset
    {
        get { return m_towerAsset; }
    }
    #endregion
}