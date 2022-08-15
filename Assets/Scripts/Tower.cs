using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float attackSpeed = 2f;
    [SerializeField] protected float attackRange = 45f;
    [SerializeField] protected float attackTime = 0f;
    [SerializeField] GameObject fireballPrefab;
    public int Cost { get { return cost; } }
    private int cost = 80;
    int enemyToAttack = 0;
    List<Enemy> enemyList = new List<Enemy>();
    private void Awake()
    {
        GetComponent<BoxCollider>().size = new Vector3(attackRange, GetComponent<BoxCollider>().size.y, attackRange);        
    }
    void Update()
    {
        if (attackTime < 0f && enemyList.Count > 0)
        {
            Attack();
            attackTime = attackSpeed;
        }
        else
            attackTime -= Time.deltaTime;
    }
    void Attack()
    {
        if (enemyList[enemyToAttack] == null)
            enemyList.Remove(enemyList[enemyToAttack]);
        if (enemyList.Count > 0)
        {
            var distance = (enemyList[enemyToAttack].transform.position - transform.position).magnitude;
            fireballPrefab.GetComponent<Fireball>().m_Target = enemyList[enemyToAttack];
            fireballPrefab.GetComponent<Fireball>().DistanceAdjustment = distance + 1;
            fireballPrefab.GetComponent<Fireball>().damage = damage;
            Instantiate(fireballPrefab, transform.position, transform.rotation);            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
            enemyList.Add(other.GetComponent<Enemy>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
            enemyList.Remove(other.GetComponent<Enemy>());
    }
}
