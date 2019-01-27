using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nondestroyableOBJ : MonoBehaviour {

	
	void Start () {
        Object.DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
