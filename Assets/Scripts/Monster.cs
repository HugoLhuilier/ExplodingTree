using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    
    private string monsterName;
    private int type;
    private float speed;
    private int HP;
    private int damage;
    private int payload;

    private bool alive;
    
    private int direction;      // 1 = left ; -1 = right

    private Vector2 spawnPosition;  // Y random goes from -4 to 2 ; X is finite, -11 or 11


    static private string[] names = {
        "Ecureuil robot",
        "Cochon robot",
        "Ecureuil robot volant",
        "Pivert robot",
        "Monke robot",
        "Monke robot (volant)",
        "Canard robot sur des �chasses"
    };

    static private float[] speeds = {
        1.8f,
        1f,
        2.3f,
        3f,
        2f,
        1.6f,
        1.8f
    };

    static private int[] damages = {
        3,
        5,
        2,
        1,
        3,
        3,
        4
    };

    static private int[] HPs = {
        10,
        20,
        6,
        3,
        15,
        13,
        15
    };

    static private int[] payloads = {       // Resources granted when defeated
        5,
        10,
        10,
        8,
        15,
        18,
        20
    };

    static private Color[] colors = {       // Used for debugging
        Color.red,
        Color.blue,
        Color.green
    };



    public void Consturct(int ty){        // Monster pseudo-constructor
        type = ty;
        name = Monster.names[ty];
        speed = Monster.speeds[ty];
        HP = Monster.HPs[ty];
        payload = Monster.payloads[ty];
        damage = Monster.damages[ty];

        direction = 1;

        if (Random.Range(0,2) == 0){
            direction = -1;
        }

        spawnPosition = new Vector3(-11*direction,0,0) + new Vector3(0,Random.Range(-4f,2f),0);

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colors[ty];

   }


    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        transform.position = new Vector3(spawnPosition.x,spawnPosition.y,0);
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive && Mathf.Abs(transform.position.x) > 1.5f){

            transform.position += new Vector3(direction*speed*0.01f,0,0);
        }
        else
        {
            DealDamage();
        }
    }


    void DealDamage()
    {
        // Deal 'damage' damage to the player.
    }

    void GetDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        alive = false;

        // Do some action to reward the player (getcomponent<> my balls) with material

        List<GameObject> monstersAlive = GameObject.Find("Spawner").GetComponent<Spawner>().monstersAlive;

        monstersAlive.Remove(gameObject);

        Destroy(gameObject);
    }

}
