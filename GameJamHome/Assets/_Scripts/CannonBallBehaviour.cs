using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private int m_damage = 2;
    [SerializeField]
    private Vector2 m_initialForce=new Vector2(1,-1);

    private Rigidbody2D m_rigidbody2D;

	void Start () {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_rigidbody2D.velocity = m_initialForce;
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<SectionCompleteState>())
        {
            Debug.Log("Collidedwith Destroyable Object");
            collision.collider.GetComponent<SectionCompleteState>().DealDamage(m_damage);
            Destroy(gameObject);
        }
    }
}
