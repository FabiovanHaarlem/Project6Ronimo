using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(easeAnimator))]
public class appearAndDisappear : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The animations for appearing and disappearing")]
    private easeAsset m_appearAnimation, m_disappearAnimation;

    [SerializeField]
    [Tooltip("The delay in seconds for appearing and disappearing")]
    private float m_appearDelay, m_disappearDelay;
    private float m_appearTimer, m_disappearTimer;

    private easeAnimator m_animator;

    void Start ()
    {
        m_animator = GetComponent<easeAnimator>();
        Appear();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (m_appearTimer > 0)
        {
            m_appearTimer -= Time.deltaTime;

            m_animator.Activate(m_appearAnimation);
        }

        if (m_disappearTimer > 0)
        {
            m_disappearTimer -= Time.deltaTime;

            if (m_disappearTimer <= 0)
            {
                m_animator.Activate(m_disappearAnimation);
            }
        }
    }

    public void Appear()
    {
        m_appearTimer = m_appearDelay;    
    }

    public void Disappear()
    {
        m_disappearTimer = m_disappearDelay;
    }


}
