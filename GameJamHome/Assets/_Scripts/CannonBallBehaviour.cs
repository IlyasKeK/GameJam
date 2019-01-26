using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private int m_damage=1;


    private Rigidbody2D m_rigidbody2D;
    private GameManager Manager;

Vector3 lastHitPos;

	void Start () {
        Manager = GameManager.Instance();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("I am created");
        GameManager.Instance().ResolveCannonBallShot();
	}
	
	void Update () {
		
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

     void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
