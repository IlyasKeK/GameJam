using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionData : MonoBehaviour
{
    public int healthPoints = 2;

    public Material m_initialMaterial;
    public Material m_highlightMaterial;
    public Material m_destroyedMaterial;
    
    [HideInInspector]
    public PlayerData playerData;

    void Start () {
		
	}
	

	void Update () {
		
	}
}
