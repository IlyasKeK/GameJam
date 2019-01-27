using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class MusicEmitterHandler : MonoBehaviour {


    StudioEventEmitter emitter;
    void Start()
    {
        m_instance = this;

        emitter = GetComponent<StudioEventEmitter>();
    }

    public void RandomizePorgression()
    {
        if (!emitter) emitter = GetComponent<StudioEventEmitter>();
        ParamRef[] refs=emitter.Params;
        foreach (ParamRef reference in refs)
        {
            if (reference.Name == "progression")
            {
                reference.Value = (int)Random.Range(2,7);
            }
        }
    }

    public void PlayMusic()
    {
        if (!emitter) emitter = GetComponent<StudioEventEmitter>();
        emitter.Play();
    }

    static MusicEmitterHandler m_instance;
    public static MusicEmitterHandler Instance()
    {
        return m_instance;
    }
}
