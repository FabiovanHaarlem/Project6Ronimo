using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    SpriteRenderer m_spriterend;

    [SerializeField]
    Transform m_goal;

    UnitStats m_stats;
    UnitAttack m_attack;

    private void Start()
    {
        m_spriterend = GetComponent<SpriteRenderer>();
        m_stats = GetComponent<UnitStats>();
    }

    void Update()
    {
        float step = 5f * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, m_goal.position, step);
    }
            
    public void OnCollisionEnter2D(Collision2D collision)
    {
        StopAndAttack(collision);
    }

    public void MoveTo(Transform target)
    {
        m_goal = target;
    }

    public void StopAndAttack(Collision2D otherobject)
    {
        m_attack.DoDamage(otherobject);
    }
}
