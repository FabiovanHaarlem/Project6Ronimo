using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeUnit : MonoBehaviour
{
    SpriteRenderer m_spriterend;

    private void Start()
    {
        m_spriterend = GetComponent<SpriteRenderer>();
    }
}
