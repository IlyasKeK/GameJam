using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionFSM : MonoBehaviour,IAgent
{
    private Fsm<SectionFSM> m_fsm;

	void Start () {
        m_fsm = new Fsm<SectionFSM>(this);
        m_fsm.ChangeState<SectionCompleteState>();
	}
	
	void Update () {
		
	}

    public Fsm<SectionFSM> fsm { get { return m_fsm; } }
}
