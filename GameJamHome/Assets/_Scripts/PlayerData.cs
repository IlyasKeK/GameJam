using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public List<GameObject> sections = new List<GameObject>();
    [HideInInspector]
    public int reources = 0;

    private Cannon m_cannon;

	void Start () {
        m_cannon = GetComponent<Cannon>();

        reources = ResourceManager.Instance().initialResources;

        foreach (GameObject section in sections)
        {
            if (section.GetComponent<SectionData>())
            {
                section.GetComponent<SectionData>().playerData = this;
            }
        }
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
