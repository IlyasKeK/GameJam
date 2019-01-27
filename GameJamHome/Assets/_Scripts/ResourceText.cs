using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceText : MonoBehaviour {

    public enum Player { ONE,TWO }
    public Player player;

    //Text
    Text m_text;

	void Start () {
        m_text = GetComponent<Text>();

        if (player == Player.ONE) GameManager.Instance().m_player1.onResourcesChanged += UpdateResourceText;
        else                      GameManager.Instance().m_player1.onResourcesChanged += UpdateResourceText;
    }

    void UpdateResourceText(float newValue)
    {
        m_text.text = "" + newValue;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
