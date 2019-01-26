using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public List<GameObject> sections = new List<GameObject>();

    private Cannon m_cannon;

	void Start () {
        m_cannon = GetComponent<Cannon>();

    }
	
	void Update () {
		
	}

    public void ActivatePlayer()
    {
        if(!m_cannon) m_cannon = GetComponent<Cannon>();
        m_cannon.ResetFire();
    }

    public void ActivateSections(bool activate)
    {
        foreach (GameObject section in sections)
        {
            if (section.GetComponent<SectionDestroyedState>())
            {
                section.GetComponent<SectionDestroyedState>().isMyTurn = !activate;
            }
        }
    }
}
