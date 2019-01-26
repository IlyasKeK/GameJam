using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SectionDestroyedState : AbstractState<SectionFSM>, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    private BoxCollider2D m_collider2D;
    private MeshRenderer m_meshRenderer;
    private SectionData m_sectionData;
    private SectionFSM m_sectionFSM;

    public bool isMyTurn = false;

    public void Start()
    {

    }

    public override void Enter(IAgent pAgent)
    {
        base.Enter(pAgent);

        if (!m_sectionData) m_sectionData = GetComponent<SectionData>();
        if (!m_collider2D) m_collider2D = GetComponent<BoxCollider2D>();
        if (!m_meshRenderer) m_meshRenderer = GetComponent<MeshRenderer>();
        if (!m_sectionFSM) m_sectionFSM = GetComponent<SectionFSM>();

        m_meshRenderer.material = m_sectionData.m_destroyedMaterial;

        DisableObject();
    }


	void Update () {
		
	}

    public override void Exit(IAgent pAgent)
    {
        base.Exit(pAgent);
        DisableObject(false);
        m_meshRenderer.material = m_sectionData.m_initialMaterial;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("HELLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSuk");
        if (!isMyTurn) return;

        if (m_sectionData.playerData.reources - ResourceManager.Instance().repairCost > 0)
        {
            //Try to repair section if player has enough resources
            
            m_sectionFSM.fsm.ChangeState<SectionCompleteState>();
            m_sectionData.playerData.reources -= ResourceManager.Instance().repairCost;
            Debug.Log("Resources left "+m_sectionData.playerData.reources);
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("HELLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSuk");
        if (!isMyTurn) return;
        HighlightObject(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("HELLOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSuk");
        if (!isMyTurn) return;
        HighlightObject(false);
    }

    void DisableObject(bool disable=true)
    {
        m_collider2D.isTrigger =  disable;
        //m_meshRenderer.enabled = !disable;
    }

    void HighlightObject(bool highlight)
    {
        //m_meshRenderer.enabled = highlight;

        if (highlight) m_meshRenderer.material = m_sectionData.m_highlightMaterial;
        else           m_meshRenderer.material = m_sectionData.m_destroyedMaterial;
    }
}
