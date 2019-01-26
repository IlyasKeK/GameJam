using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private string _levelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play() {
        SceneManager.LoadScene(_levelToLoad);
        return;
        if (Application.CanStreamedLevelBeLoaded(_levelToLoad))
        {
            SceneManager.LoadScene(_levelToLoad);
        }
        else
        {
            Debug.Log("this level does not exist");
        }
    }

    public void Quit() {
        Application.Quit();
    }
}
