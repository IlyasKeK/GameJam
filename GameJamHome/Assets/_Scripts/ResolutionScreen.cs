using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionScreen : MonoBehaviour {

    public Sprite winner_p1;
    public Sprite winner_p2;

    private Image m_image;

    private static ResolutionScreen m_instance;

    private void Awake()
    {
        m_instance = this;
        Debug.Log("INSTANCE IS READY");
    }

    void Start () {
 
        m_image = GetComponent<Image>();
	}

    public void SetWinner(int winner)
    {
        if(!m_image) m_image = GetComponent<Image>();

        if (winner == 1)
        {
            m_image.sprite = winner_p1;
        }
        if (winner == 2)
        {
            m_image.sprite = winner_p2;
        }
    }

    public static ResolutionScreen Instance()
    {
        return m_instance;
    }
}
