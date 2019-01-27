using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chargebar : MonoBehaviour {

    public enum Player { ONE, TWO }
    public Player player;

    float m_maxPower;
    float m_currentPower;
    float m_minPower;

    private Slider m_slider;

    bool m_isActivated = false;

    void Start ()
    {
        

    }


    void UpdateSliderValues(float newValue)
    {
        Debug.Log("        new VALUE IS  " + newValue);
        m_slider.value = newValue;
    }

	void Update () {
        if (!m_isActivated)
        {
            m_isActivated = true;
            m_slider = GetComponent<Slider>();

            if (player == Player.ONE)
            {
                Debug.Log("Initiate playerOne");
                m_minPower = GameManager.Instance().m_player1.cannon.minPower;
                m_currentPower = GameManager.Instance().m_player1.cannon.currentPower;
                m_maxPower = GameManager.Instance().m_player1.cannon.maxPower;

                GameManager.Instance().m_player1.cannon.onPowerChanges += UpdateSliderValues;
            }
            if (player == Player.TWO)
            {
                Debug.Log("Initiate playerTwo");
                m_minPower = GameManager.Instance().m_player2.cannon.minPower;
                m_currentPower = GameManager.Instance().m_player2.cannon.currentPower;
                m_maxPower = GameManager.Instance().m_player2.cannon.maxPower;

                GameManager.Instance().m_player2.cannon.onPowerChanges += UpdateSliderValues;
            }

            Debug.Log("MIN: " + m_minPower);
            Debug.Log("MAX: " + m_maxPower);

            m_slider.minValue = m_minPower;
            m_slider.maxValue = m_maxPower;
        }
	}
}
