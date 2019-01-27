using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class lastSCRIPT : MonoBehaviour {
    
    StudioEventEmitter emitter;
	void Start () {
        m_instance = this;

        emitter = GetComponent<StudioEventEmitter>();
	}

    public void PlayExplosion()
    {
        if(!emitter) emitter = GetComponent<StudioEventEmitter>();
        emitter.Play();
    }

    static lastSCRIPT m_instance;
    public static lastSCRIPT Instance()
    {
        return m_instance;
    }
}
