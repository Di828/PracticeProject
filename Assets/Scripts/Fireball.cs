using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Enemy m_Target;
    private float speed = .1f;
    public float damage;
    public float DistanceAdjustment = 1;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        var newEnemyPos = m_Target.position + Vector3.forward * speed * Time.deltaTime * DistanceAdjustment;
        rb.AddForce((newEnemyPos - transform.position) * speed, ForceMode.Impulse);         
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.GetComponent<Enemy>() == m_Target)
        {
            m_Target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
