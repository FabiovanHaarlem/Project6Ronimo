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

    bool m_attacking;
    public bool getIfAttacking
    { get { return m_attacking; } }

    bool m_playerunitstandstill;

    float m_attacktimer;

    //Voeg een attackspeed toe in je editor

    private void Start()
    {
        m_spriterend = GetComponent<SpriteRenderer>();
        m_stats = GetComponent<UnitStats>();
        m_attack = GetComponent<UnitAttack>();
        m_playerunitstandstill = false;
        m_attacking = false;
    }

    void Update()
    {
        float step = m_stats.m_movespeed * Time.deltaTime;


        if(m_attacking != true)
        {
            if (m_playerunitstandstill != true)
            {
                Move(step);
            }
        }

    }

    private void Move(float step)
    {
        transform.position = Vector2.MoveTowards(transform.position, m_goal.position, step);
    }

    private void FixedUpdate()
    {

        if (gameObject.CompareTag("Player"))
        {

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + 1.2f, transform.position.y), Vector2.right, 1f);
            Debug.DrawRay(new Vector2(transform.position.x + 1.2f, transform.position.y), Vector2.right * 1f);
            m_playerunitstandstill = false;
            if (hit != false)
            {
                if (hit.collider.gameObject.CompareTag("Player") && hit != false)
                {
                    if (hit.collider.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                    {
                        m_playerunitstandstill = hit;
                    }
                }
                else
                {
                    m_playerunitstandstill = false;
                }
            }


        }
        else if (gameObject.CompareTag("AI"))
        {

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 1.2f, transform.position.y), Vector2.left, 1f);
            Debug.DrawRay(new Vector2(transform.position.x - 1.2f, transform.position.y), Vector2.left * 1f);
            m_playerunitstandstill = false;
            if (hit != false)
            {
                if (hit.collider.gameObject.CompareTag("AI"))
                {
                    if (hit.collider.gameObject.GetInstanceID() != gameObject.GetInstanceID())
                    {
                        m_playerunitstandstill = hit;
                    }
                }
                else
                {
                    m_playerunitstandstill = false;
                }
            }


        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            if (collision.CompareTag("AI"))
            {
                m_attacking = true;

                StopAndAttack(collision);

                m_attacktimer += Time.deltaTime;
            }
        }
        else if (gameObject.CompareTag("AI"))
        {
            if (collision.CompareTag("Player"))
            {
                m_attacking = true;

                StopAndAttack(collision);

                m_attacktimer += Time.deltaTime;
            }
        }


    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        m_attacktimer = 0;
        m_attacking = false;
    }

    public void MoveTo(Transform target)
    {
        m_goal = target;
    }

    public void StopAndAttack(Collider2D otherobject)
    {
        if (otherobject.gameObject.CompareTag("Player") && this.tag == "Player")
        {
            Debug.Log("Don't attack because friendly");
        }
        else if (otherobject.gameObject.CompareTag("AI") && this.tag == "AI")
        {
            Debug.Log("Don't attack because friendly");
        }
        else if (otherobject.gameObject.CompareTag("AI") && this.tag == "Player")
        {
            if(m_attacktimer > 1.4)
            {
                GetComponent<UnitAttack>().DoDamage(otherobject);
            }
        }
        else if (otherobject.gameObject.CompareTag("Player") && this.tag == "AI")
        {
            if (m_attacktimer > 1.4)
            {
                GetComponent<UnitAttack>().DoDamage(otherobject);
            }
        }
    }
}
