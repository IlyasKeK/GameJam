using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionCompleteState :AbstractState<SectionFSM>
{
    [SerializeField]
    private int m_healthPoints = 10;

    private SectionFSM m_sectionFSM;

    public void Start()
    {
        m_sectionFSM = GetComponent<SectionFSM>();
        Debug.Log("SectionFSM is ready");
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
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
