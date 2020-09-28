using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.1f;
    int numOfMovements = 0;
    float speed = 0.1f;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;
    public GameObject enemy;

    void fireEnemyProjectile()
    {
        if (Random.Range(0f, 550f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation) as GameObject;
        }
    }

     private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player"){//if hit the enemy
            GameManager.lives--;
            GameManager.playGame = false;//pause the game
        }
        if(collision.gameObject.tag == "Finish"){
            GameManager.lives = 0;//player loses automatically
            GameManager.playGame = false;//pause the game
        }
        if(collision.gameObject.tag == "laser"){
            GameManager.beatedEnemies++;
        }
    }


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int moves = 60;
        //move down after "moves" movements one direction
        if (GameManager.playGame)//enemy can move if game is not paused
        {

            if (numOfMovements == moves)
            {
                transform.Translate(new Vector3(0, -0.7f, 0));
                numOfMovements = -1;
                speed = -speed;//make the movement other way
                timer = 0;
            }

            //move sideways on timed interval
            timer += Time.deltaTime;
            if (timer > timeToMove && numOfMovements < moves)
            {//if it's enough time stopped, move
                transform.Translate(new Vector3(speed, 0, 0));
                timer = 0;//stutter effect (wait and move, wait and move)
                numOfMovements++;
            }

            fireEnemyProjectile();
        }

    }
}
