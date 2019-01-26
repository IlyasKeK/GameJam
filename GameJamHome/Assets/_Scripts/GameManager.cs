using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField]
    private PlayerData m_player1;
    [SerializeField]
    private PlayerData m_player2;
    [Header("Settings")]
    [SerializeField]
    private GameObject m_resolutionScreen;

    private static GameManager m_instance;

    public static Action<PlayerData> onEndRound;

    bool m_isPlayerOneTurn = true;

	void Awake () {
        Debug.Log("GameManager is ready");
        m_instance = this;
    }

    private void Start()
    {
        ResolveEndRound();
    }

    void Update () {
		
	}

    public void ResolveEndGame(BoilerBehaviour boilerBehaviour)
    {
        //TODO fix after smoke
        Debug.Log("Player " + boilerBehaviour.player + " LOST"); //Other player is won,not owner of destroyed boiler
        m_resolutionScreen.SetActive(true);
    }

    public void ResolveEndRound()
    {
        //Calling global event in the end of the round
        //if (null == onEndRound) return;
        Debug.Log("1: "+m_isPlayerOneTurn);
        if (m_isPlayerOneTurn)
        {
            m_player1.ActivatePlayer();
            m_player2.ActivateSections(true);
            m_player1.ActivateSections(false);
        }
        else
        {
            m_player2.ActivatePlayer();
            m_player1.ActivateSections(true);
            m_player2.ActivateSections(false);
        }

        m_isPlayerOneTurn = !m_isPlayerOneTurn;
    }

    public static GameManager Instance()
    {
        return m_instance;
    }
}
