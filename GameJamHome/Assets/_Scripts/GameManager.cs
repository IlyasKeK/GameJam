using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField]
    public PlayerData m_player1;
    [SerializeField]
    public PlayerData m_player2;
    [Header("Settings")]
    [SerializeField]
    private GameObject m_resolutionScreen;

    [SerializeField]
    private Sprite P1Turn;

    [SerializeField]
    private Sprite P2Turn;

    [SerializeField]
    private Image TurnImage;

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

    public PlayerData GetCurrentPlayer()
    {
        if (m_isPlayerOneTurn) return m_player2;
        else return m_player1;
    }

    public void ResolveEndGame(BoilerBehaviour boilerBehaviour)
    {
        //TODO fix after smoke
        Debug.Log("Player " + boilerBehaviour.player + " LOST"); //Other player is won,not owner of destroyed boiler
        m_resolutionScreen.SetActive(true);

        if (boilerBehaviour.player == BoilerBehaviour.Player.ONE)
        {
            ResolutionScreen.Instance().SetWinner(2);
        }
        else
        {
            ResolutionScreen.Instance().SetWinner(1);
        }

        m_player1.cannon.enabled = false;
        m_player2.cannon.enabled = false;
    }

    public void ResolveEndRound()
    {
        //Calling global event in the end of the round

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

        if (TurnImage == null) return;

        if(m_isPlayerOneTurn)
        {
            TurnImage.sprite = P1Turn;
        }
        else
        {
            TurnImage.sprite = P2Turn;
        }
    }

    public void ResolveCannonBallShot()
    {
        m_player1.ActivateSections(true);
        m_player2.ActivateSections(true);
    }

    
    public void hitResponseNeighbours()
    {
        m_player1.HitResponsePlayer(m_isPlayerOneTurn);
        m_player2.HitResponsePlayer(!m_isPlayerOneTurn);
    }

    public void ResolveDestruction()
    {
        if (m_isPlayerOneTurn)
        {
            m_player2.resources++;
        }
        else
        {
            m_player1.resources++;
        }
    }
        
    public static GameManager Instance()
    {
        return m_instance;
    }
}
