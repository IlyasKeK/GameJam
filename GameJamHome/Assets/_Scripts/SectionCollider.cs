using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SectionCollider : MonoBehaviour {

    public Action<Collision2D> onCollisionEnter;

    [HideInInspector]
    public BoxCollider2D boxCollider2D;
    

	void Start ()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (null != onCollisionEnter) onCollisionEnter(collision);
    }
}
