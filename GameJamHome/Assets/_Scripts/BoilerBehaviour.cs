using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerBehaviour : MonoBehaviour
{
    public enum Player { ONE, TWO }
    public Player player;

    public void DestroyBoiler()
    {
        Debug.Log("BOILER IS DESTROYED");
        GameManager.Instance().ResolveEndGame(this);
    }
}
