using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemy
{
    private void Awake()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
        health = base.health;
        startSpeed = base.speed;
    }
    void Start()
    {
    }
    private void Update()
    {        
       position = transform.position;        
    }

    void FixedUpdate()
    {
        if (!mainController.Instance.gameover)
            Move();
    }
    public override void TakeDamage(float Damage)
    {        
        health -= Damage;        
        if (health <= 0)
        {
            Destroy(gameObject);
            mainController.Instance.ChangeGold(killCost);
        }
    }    
}
