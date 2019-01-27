using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

    [SerializeField]
    private Sprite[] IdleSprites = { };

    [SerializeField]
    private Sprite AngrySprite;

    [SerializeField]
    private Sprite HappySprite;

    [SerializeField]
    private Image SpriteImage;

    public List<GameObject> sections = new List<GameObject>();

    private int m_resources = 0;
    [HideInInspector]
    public int resources {
        get { return m_resources; }
        set
        {
            m_resources = value;
            Debug.Log("Caling ACTION " + value);
            if (onResourcesChanged != null) onResourcesChanged(value);
        } }

    private Cannon m_cannon;
    private int IdleIndex;
    private float TimerToIdle;

    public Action<float> onResourcesChanged;

	void Start () {
        m_cannon = GetComponent<Cannon>();

        resources = ResourceManager.Instance().initialResources;
        Debug.Log("Current resource amount "+m_resources);
        foreach (GameObject section in sections)
        {
            if (section.GetComponent<SectionData>())
            {
                section.GetComponent<SectionData>().playerData = this;
            }
        }
        if (SpriteImage != null && IdleSprites.Length > 0)
        {
            SpriteImage.sprite = IdleSprites[0];
        }

    }
	
	void Update () {
		if(TimerToIdle > 0)
        {
            TimerToIdle -= Time.deltaTime;
        }
        else
        {
            TimerToIdle = 0.5f;
            IdleIndex++;
            if (IdleIndex > 1) { IdleIndex = 0; }
            SpriteImage.sprite = IdleSprites[IdleIndex];
        }
    }

    public void HitResponsePlayer(bool gotHit)
    {
        if (SpriteImage == null) return;

        if (gotHit) { SpriteImage.sprite = AngrySprite; }
        else { SpriteImage.sprite = HappySprite; }

        TimerToIdle = UnityEngine.Random.Range(1,3); 
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
