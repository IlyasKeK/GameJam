using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDestroyedState : AbstractState<SectionFSM>
{
    private BoxCollider2D m_collider2D;
    private MeshRenderer m_meshRenderer;

    public void Start()
    {
        Debug.Log("COllider is ready");
    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);
        DisableObject();
    }


	void Update () {
		
	}

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
    }

    void DisableObject()
    {

        if(!m_collider2D)   m_collider2D = GetComponent<BoxCollider2D>();
        if(!m_meshRenderer) m_meshRenderer = GetComponent<MeshRenderer>();

        m_collider2D.enabled = false;
        m_meshRenderer.enabled = false;
    }
}
