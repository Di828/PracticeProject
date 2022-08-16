using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float health = 10f;    
    protected int killCost = 10;
    protected MainController mainController;    
    protected float startSpeed;
    protected float freezeTime;
    public Vector3 position;
    public float Health 
    {
        get { return health; }        
    }
    public int Number { get; set; }
    protected int rotations = 0;    
    protected bool DetectWall()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position,fwd, out hit, 10f))
        {            
            if (hit.collider.gameObject.CompareTag("Wall"))
                return true;
        }
        return false;
    }
    protected void Move()
    {
        if (DetectWall())
        {
            Rotate();
            if (rotations % 2 == 0)
                Rotate();
        }
        else
            rotations = 0;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);        
    }
    protected void Rotate()
    {
        transform.Rotate(0, 90, 0);
        rotations++;
    }
    public virtual void TakeDamage(float Damage)
    {        
    }
    public void HealthBuff(int waveNumber)
    {
        health += (waveNumber - 1);
    }
    public void SlowDown(float slowdown, float slowdownTime)
    {
        speed *= slowdown;
        freezeTime = slowdownTime;
        StartCoroutine(SlowDownCoroutine());        
    }
    IEnumerator SlowDownCoroutine()
    {
        yield return new WaitForSeconds(freezeTime);
        speed = speed * 2;        
    }
}
