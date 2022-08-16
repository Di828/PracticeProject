using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTower : Tower
{
    [SerializeField] GameObject frostballPrefab;
    private void Awake()
    {
        cost = 60;
        damage = 5;
        attackRange = 55;
        attackSpeed = 2f;
    }
    protected override void Attack()
    {
        if (enemyList.Count > 0 && enemyList[enemyToAttack] == null)
            enemyList.Remove(enemyList[enemyToAttack]);
        if (enemyList.Count > 0)
        {
            var distance = (enemyList[enemyToAttack].transform.position - transform.position).magnitude;

            frostballPrefab.GetComponent<FrostBall>().m_Target = enemyList[enemyToAttack];
            frostballPrefab.GetComponent<FrostBall>().DistanceAdjustment = distance + 1;
            frostballPrefab.GetComponent<FrostBall>().damage = damage;
            Instantiate(frostballPrefab, transform.position, transform.rotation);
        }
    }
}
