using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject m_resolutionScreen;

    private static GameManager m_instance;

	void Awake () {
        Debug.Log("GameManager is ready");
        m_instance = this;
	}
	
	void Update () {
		
	}

    public void ResolveEndGame(BoilerBehaviour boilerBehaviour)
    {
        //TODO fix after smoke
        Debug.Log("Player " + boilerBehaviour.player + " LOST"); //Other player is won,not owner of destroyed boiler
        m_resolutionScreen.SetActive(true);
    }

    public static GameManager Instance()
    {
        return m_instance;
    }
}
