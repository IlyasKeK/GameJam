using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject[] clouds;
    public float speedCloud = 1;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < clouds.Length; i++)
        {
            if (clouds[i].transform.position.x < -50)
            {
                clouds[i].transform.position = new Vector3(Random.Range(40, 60), clouds[i].transform.position.y, clouds[i].transform.position.z);
            }
            clouds[i].transform.position -= new Vector3(speedCloud, 0,0);
        }
	}
}
