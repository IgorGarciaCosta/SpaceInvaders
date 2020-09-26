using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer =0;
    float timeToMove = 0.1f;
    int numOfMovements = 0;
    float speed = 0.15f;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    public GameObject enemy;
    
    void fireEnemyProjectile(){
        if(Random.Range(0f, 750f)<1){
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation) as GameObject;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down after 43 movements one direction
        if(numOfMovements==43){
            transform.Translate(new Vector3(0, -0.7f, 0));
            numOfMovements = -1;
            speed = -speed;//make the movement other way
            timer = 0;
        }

        //move sideways on timed interval
        timer += Time.deltaTime;
        if(timer>timeToMove && numOfMovements < 43){//if it's enough time stopped, move
            transform.Translate(new Vector3(speed, 0, 0));
            timer = 0;//stutter effect (wait and move, wait and move)
            numOfMovements++;
        }

        fireEnemyProjectile();
        
    }
}
