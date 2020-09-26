using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyProjectile;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Player"){//if hit the enemy
            Destroy(collision.gameObject);
            Destroy(enemyProjectile);//laser is destroyed by hitting the enemy 
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
