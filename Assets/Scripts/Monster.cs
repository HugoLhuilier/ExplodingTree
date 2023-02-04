using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    public string name;
    public int type;
    public int speed;
    public int HP;
    public int payload;
    
    public int direction;      // 1 = left ; -1 = right

    public Vector2 spawnPosition;


    static public string[] names = {
        "Ecureuil robot",
        "Cochon robot",
        "Ecureuil robot volant"
    };

    static public int[] speeds = {
        3,
        1,
        4
    };

    static public int[] HPs = {
        5,
        10,
        2
    };

    static public int[] payloads = {       // Resources granted when defeated
        5,
        10,
        10
    };



   


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(spawnPosition.x,spawnPosition.y,0);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(HP>0){
            transform.position += new Vector3(direction*speed*0.1f,0,0);
        }
    }
}
