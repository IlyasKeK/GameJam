using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionFSM : MonoBehaviour,IAgent
{
    [SerializeField]
    private bool m_isDestroyed = false;

    private Fsm<SectionFSM> m_fsm;

	void Start () {
        m_fsm = new Fsm<SectionFSM>(this);
        if(!m_isDestroyed) m_fsm.ChangeState<SectionCompleteState>();
        else m_fsm.ChangeState<SectionDestroyedState>();
    }
	
	void Update () {
		
	}

    public Fsm<SectionFSM> fsm { get { return m_fsm; } }
}
