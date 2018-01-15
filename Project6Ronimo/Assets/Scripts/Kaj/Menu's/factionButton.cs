using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class factionButton : MonoBehaviour
{
    public static PlayerFactionEnum faction;
    private float m_timer = 0.5f;
    private bool m_acitve = false;
    [SerializeField]
    private PlayerFactionEnum m_facc;

    // Update is called once per frame
    void Update()
    {
        if (m_acitve)
        {
            if (m_timer <= 0)
            {
                faction = m_facc;
                SceneManager.LoadScene(2);
            }
            m_timer -= Time.deltaTime;
        }
    }

    public void Activate()
    {
        m_timer = 0.5f;
        m_acitve = true;
    }
}
