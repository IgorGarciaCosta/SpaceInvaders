using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag=="Enemy"){//if hit the enemy
            Destroy(collision.gameObject);
            Destroy(projectile);//laser is destroyed by hitting the enemy 
            
        }
        if(collision.gameObject.tag == "Finish"){
            Destroy(projectile);
        }
    }
 
    // Start is called before the first frame update
    void Start()
    {
        GameManager.playGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -8*Time.deltaTime, 0));
    }
}
