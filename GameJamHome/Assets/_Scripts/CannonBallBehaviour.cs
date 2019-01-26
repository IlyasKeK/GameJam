using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private int m_damage=1;


    private Rigidbody2D m_rigidbody2D;
    private GameManager Manager;

    public float lifeTime = 5;
    private float m_timeOfConstruction;
Vector3 lastHitPos;

	void Start () {
        Manager = GameManager.Instance();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("I am created");
        GameManager.Instance().ResolveCannonBallShot();
        m_timeOfConstruction = Time.time;
	}
	
	void Update () {
        if (Time.time > m_timeOfConstruction + lifeTime)
        {
            Destroy(gameObject);
        }
        else { Debug.Log(Time.time-(m_timeOfConstruction + lifeTime)); }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            Destroy(gameObject);
            return;
        }
        if (collision.collider.GetComponent<BoilerBehaviour>())
        {
            collision.collider.GetComponent<BoilerBehaviour>().DestroyBoiler();
            Destroy(gameObject);
        }

        if (collision.collider.GetComponent<SectionCompleteState>())
        {
            collision.collider.GetComponent<SectionCompleteState>().DealDamage(m_damage);
            if (Manager) { Manager.hitResponseNeighbours(); }
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance().ResolveEndRound();
    }


}
