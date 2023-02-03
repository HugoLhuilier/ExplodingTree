using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    private string name;
    private int type;
    private int speed;
    private int HP;
    private int payload;
    
    private int direction;      // 1 = left ; -1 = right

    private Vector2 spawnPosition;


    static private string[] names = {
        "Ecureuil robot",
        "Cochon robot",
        "Ecureuil robot volant"
    };

    static private int[] speeds = {
        3,
        1,
        4
    };

    static private int[] HPs = {
        5,
        10,
        2
    };

    static private int[] payloads = {
        5,
        10,
        10
    };

    Monster(int ty, int dir){
        type = ty;
        direction = dir;
        name = names[type];
        speed = speeds[type];
        HP = HPs[type];

    }

    
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {

        while(HP>0){
            transform.position = new Vector3(direction*speed*0.01f,0,0) * Time.deltaTime;
        }
    }
}
