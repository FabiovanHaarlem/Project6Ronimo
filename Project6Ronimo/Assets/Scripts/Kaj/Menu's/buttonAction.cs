using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonAction : MonoBehaviour
{
    public enum Action
    {
        GoToSelect,
        GoToMenu,
        EndGame
    }

    private float m_timer = 0.5f;
    private bool m_acitve = false;
    [SerializeField]
    private Action m_action;
	
	// Update is called once per frame
	void Update ()
    {
		if(m_acitve)
        {
            if(m_timer <= 0)
            {
                switch (m_action)
                {
                    case Action.GoToSelect:
                        SceneManager.LoadScene(1);
                        break;
                    case Action.GoToMenu:
                        SceneManager.LoadScene(0);
                        break;
                    case Action.EndGame:
                        Application.Quit();
                        break;
                }
            }
            m_timer -= Time.deltaTime;
        }
	}

    public void Activate()
    {
        AudioManager.SFX.PlaySound(SFXManager.Sounds.MenuClick);
        m_timer = 0.55555f;
        m_acitve = true;
    }
}
