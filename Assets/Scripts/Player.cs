using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public GameObject projectileClone;

    
    void movement(){
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(new Vector3(-5*Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(new Vector3(5*Time.deltaTime, 0, 0));
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            transform.Translate(new Vector3(0, -5*Time.deltaTime, 0));
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            transform.Translate(new Vector3(0, 5*Time.deltaTime, 0));
        }
    }

    void fireProjectile(){//maybe i'll have to erase this && later
        if(Input.GetKeyDown(KeyCode.Space)&& projectileClone == null){
            projectileClone = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, 0), player.transform.rotation) as GameObject;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.lives>0){
           movement();
           fireProjectile(); 
        }
        else{
            player.transform.position = new Vector3(500, 0, 0);
        }
        
    }

}
