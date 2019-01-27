using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCompleteState :AbstractState<SectionFSM>
{
    private int m_healthPoints;

    private SectionFSM m_sectionFSM;
    private SectionData m_sectionData;


    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        if(!m_sectionFSM) m_sectionFSM = GetComponent<SectionFSM>();
        if (!m_sectionData) m_sectionData = GetComponent<SectionData>();

        m_healthPoints = m_sectionData.healthPoints;
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
            GameManager.Instance().ResolveDestruction();
            m_sectionFSM.fsm.ChangeState<SectionDestroyedState>();
        }
    }
}
