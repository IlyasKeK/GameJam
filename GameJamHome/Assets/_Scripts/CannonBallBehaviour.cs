using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallBehaviour : MonoBehaviour
{
    [SerializeField]
    private int m_damage=1;
    [SerializeField]
    private float m_radius = 5;
    [SerializeField]
    private GameObject m_explosion;

    private Rigidbody2D m_rigidbody2D;
    private GameManager m_manager;

    public float lifeTime = 5;
    private float m_timeOfConstruction;
    Vector3 lastHitPos;

	void Start () {
        m_manager = GameManager.Instance();
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
            //Explode();
            Destroy(gameObject);
        }

        if (collision.collider.GetComponent<SectionCompleteState>())
        {
            collision.collider.GetComponent<SectionCompleteState>().DealDamage(m_damage);
            if (m_manager) { m_manager.hitResponseNeighbours(); }
            Explode();
            Destroy(gameObject);
        }
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, m_radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<SectionCompleteState>())
            {
                collider.GetComponent<SectionCompleteState>().DealDamage(200);
            }
        }
        GameObject newExplosion = GameObject.Instantiate(m_explosion, transform.position, transform.rotation);
        newExplosion.transform.localScale = new Vector3(1, 1, 1) * m_radius*2;
    }

    private void OnDestroy()
    {
        Explode();
        GameManager.Instance().ResolveEndRound();
    }


}
