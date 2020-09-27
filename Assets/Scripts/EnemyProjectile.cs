using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;
    Vector3 respawn = new Vector3(7, -4, 0);

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){//if hit the enemy
            collision.gameObject.transform.position = respawn;//respawn player
            Destroy(enemyProjectile);//laser is destroyed by hitting the enemy 
            GameManager.lives--;
            GameManager.playGame = false;//pause the game
        }
        if(collision.gameObject.tag == "Finish"){
            Destroy(enemyProjectile);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5*Time.deltaTime, 0));
    }
}
