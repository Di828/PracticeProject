using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : Enemy
{
    private void Awake()
    {
        mainController = GameObject.Find("MainController").GetComponent<MainController>();
    }
    void Start()
    {
        health = 5f;        
        speed = 15f;
        killCost = 10;
    }
    private void Update()
    {        
       position = transform.position;
    }

    void FixedUpdate()
    {
        Move();
    }
    public override void TakeDamage(float Damage)
    {
        health -= Damage;
        if (health < 0)
        {
            Destroy(gameObject);
            mainController.Instance.ChangeGold(killCost);
        }
    }  
}
