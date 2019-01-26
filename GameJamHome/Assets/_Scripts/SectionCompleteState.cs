using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCompleteState :AbstractState<SectionFSM>
{
    private int m_healthPoints;

    private SectionFSM m_sectionFSM;
    private SectionData m_sectionData;

    public void Start()
    {
        m_sectionFSM = GetComponent<SectionFSM>();
        m_sectionData = GetComponent<SectionData>();

        Debug.Log("SectionFSM is ready");
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        m_healthPoints = m_sectionData.healthPoint;
    }
	
	void Update ()
    {
		
	}

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
    }

    public void DealDamage(int damage)
    {
        m_healthPoints -= damage;
        if (m_healthPoints <= 0)
        {
            m_healthPoints = 0;
            m_sectionFSM.fsm.ChangeState<SectionDestroyedState>();
        }
    }
}
