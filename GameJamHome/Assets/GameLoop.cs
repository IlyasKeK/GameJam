using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    int CannonIndex = 0;
    Cannon[] Cannons;
    // Use this for initialization
    void Start () {
        Cannons = FindObjectsOfType<Cannon>();

        if (Cannons.Length < 1)
            return;

        NextTurn();

        for (int i = 0; i < Cannons.Length; i++)
        {
            Cannons[i].BindShotEvent(NextTurn);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void NextTurn()
    {
        if (Cannons.Length < 1)
            return;

        Cannons[CannonIndex].ResetFire();
        CannonIndex++;

        if (CannonIndex >= Cannons.Length)
            CannonIndex = 0;
    }
}
