using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private int m_damage=1;


    private Rigidbody2D m_rigidbody2D;

	void Start () {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
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
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance().ResolveEndRound();
    }
}
