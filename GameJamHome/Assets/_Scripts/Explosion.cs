using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    [SerializeField]
    private float m_explosionRadius = 5;
    [SerializeField]
    private int m_damage = 100;

    Animator m_animator;

    public bool isActivated = false;

	void Start () {
        m_animator = GetComponent<Animator>();
        m_animator.speed = 0;

    }

    public void Explode()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(transform.position, m_explosionRadius);
        Debug.Log("Colliders in explosion radius: "+colliders.Length);

        m_animator.speed = 1;
        
        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<SectionCompleteState>())
            {
                collider.GetComponent<SectionCompleteState>().DealDamage(m_damage);
                Debug.Log(">>> Found destroyable section and destroyed it");
            }
        }
    }
	
	void Update () {
        if (!isActivated)
        {
            isActivated = true;
            Explode();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_explosionRadius);
    }
}
