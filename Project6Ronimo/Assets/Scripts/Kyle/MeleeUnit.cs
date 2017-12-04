using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
    SpriteRenderer m_spriterend;

    Rigidbody m_rigibody;
    NavMeshAgent m_agent;

    [SerializeField]
    Transform endpoint;

    private void Start()
    {
        m_rigibody = GetComponent<Rigidbody>();
        m_agent = GetComponent<NavMeshAgent>();
        m_spriterend = GetComponent<SpriteRenderer>();
        //transform.LookAt()
        //m_agent.SetDestination(endpoint.position);
    }
}
