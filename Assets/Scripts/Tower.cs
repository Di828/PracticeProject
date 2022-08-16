using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected float attackSpeed = 2f;
    [SerializeField] protected float attackRange = 45f;
    [SerializeField] protected float attackTime = 0f;        
    public int cost = 80;
    protected int enemyToAttack = 0;
    protected List<Enemy> enemyList = new List<Enemy>();
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
    protected virtual void Attack()
    {        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
            enemyList.Add(other.GetComponent<Enemy>());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null && enemyList.Contains(other.GetComponent<Enemy>()))
            enemyList.Remove(other.GetComponent<Enemy>());
    }
}
