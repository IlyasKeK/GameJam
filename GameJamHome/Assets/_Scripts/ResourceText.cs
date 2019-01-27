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

        UpdateResourceText( ResourceManager.Instance().initialResources );

        if (player == Player.ONE)
        {
            Debug.Log("Initiate playerOne");
            GameManager.Instance().m_player1.onResourcesChanged += UpdateResourceText;
        }
        if (player == Player.TWO)
        {
            Debug.Log("Initiate playerTwo");
            GameManager.Instance().m_player2.onResourcesChanged += UpdateResourceText;
        }

    }

    void UpdateResourceText(float newValue)
    {
        Debug.Log("New value in TEXT_OBJECT " + newValue);
        m_text.text = "" + newValue;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
