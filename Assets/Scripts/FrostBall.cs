using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostBall : MonoBehaviour
{
    public Enemy m_Target;
    protected float speed = .1f;
    public float damage;
    public float DistanceAdjustment = 1;
    public float slowdown = 0.5f;
    public float slowdownTime = 4f;
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void LateUpdate()
    {
        if (m_Target == null)
            Destroy(gameObject);
        else
        {
            var newEnemyPos = m_Target.position + Vector3.forward * speed * Time.deltaTime * DistanceAdjustment;
            rb.AddForce((newEnemyPos - transform.position) * speed, ForceMode.Impulse);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() == m_Target)
        {
            m_Target.TakeDamage(damage);
            m_Target.SlowDown(slowdown,slowdownTime);
            Destroy(gameObject);
        }
    }
}
