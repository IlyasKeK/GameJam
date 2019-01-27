using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int initialResources = 10;
    public int repairCost = 1;
    public int upgradeCannonCost = 5;

    private static ResourceManager m_instance;

    void Awake ()
    {
        m_instance = this;
    }
	
	void Update ()
    {
		
	}

    public static ResourceManager Instance()
    {
        return m_instance;
    }
}
