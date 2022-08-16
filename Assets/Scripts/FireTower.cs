using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : Tower
{
    [SerializeField] GameObject fireballPrefab;
    private void Awake()
    {
        cost = 80;
        damage = 10;
        attackRange = 45;
        attackSpeed = 2f;
    }
    protected override void Attack()
    {
        if (enemyList.Count > 0 && enemyList[enemyToAttack] == null)
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
}
