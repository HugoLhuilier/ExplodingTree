using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{


    [SerializeField] private string monsterName;
    [SerializeField] private int type;
    [SerializeField] private float speed;
    [SerializeField] private float HP;
    [SerializeField] private float damage;
    [SerializeField] private int payload;


    private float globalSpeed;

    private bool alive;
    
    private int direction;      // 1 = left ; -1 = right

    //private Vector2 spawnPosition;  // Y random goes from -4 to 2 ; X is finite, -11.3 or 11.3


    public float changeDuration = 1f;

    /*
    static private string[] names = {
        "Ecureuil robot",
        "Cochon robot",
        "Ecureuil robot volant",
        "Cochon robot volant",
        "Pivert robot",
        "Monke robot",
        "Monke robot (volant)",
        "Canard robot sur des échasses"
    };

    static private float[] speeds = {
        1.8f,
        1f,
        2.3f,
        1.3f,
        3f,
        2f,
        1.6f,
        1.8f
    };

    static private int[] damages = {
        3,
        5,
        2,
        4,
        1,
        3,
        3,
        4
    };

    static private int[] HPs = {
        10,
        20,
        6,
        17,
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

    static private int[] damageTimes = {       // Time between each hit (in frames)
        75,
        90,
        40,
        10,
        55,
        40,
        120
    };

    /*
    static private Color[] colors = {       // Used for debugging -- WILL BE REPLACED BY SPRITES PATHS
        Color.red,      // equ rob
        Color.blue,     // cochon
        Color.green     // equ rob volant
                        // Pivert rob
                        // Monke rob
                        // Monke rob volant
                        // Canard sur échasses
    };
    */


    public void Consturct(int dir, float spd){        // Monster pseudo-constructor

        globalSpeed = spd;
        /*
        type = ty;
        name = Monster.names[ty];
        speed = Monster.speeds[ty];
        HP = Monster.HPs[ty];
        payload = Monster.payloads[ty];
        damage = Monster.damages[ty];
        */

        direction = dir;
        if(direction == -1)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

        

        //transform.position = new Vector3(spawnPosition.x,spawnPosition.y,0);

   }


    // Start is called before the first frame update
    void Start()
    {
        alive = true;        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive && Mathf.Abs(transform.position.x) > 1.8f){

            transform.position += new Vector3(direction*speed*0.01f*globalSpeed,0,0);
        }
        else if(alive)
        {
            DealDamage();
        }
    }


    void DealDamage()       // Deal 'damage' damage to the player. And sacrifices the monster
    {

        GameObject player = GameObject.Find("Player");

        player.GetComponent<Ressources>().GetHit(damage);      // Uncomment when the function is created in PLAYER

        Kill();
        
    }

    public void GetDamage(float damage)
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


        //GameObject player = GameObject.Find("Player");

        //player.GetComponent<Ressources>().GetReward(payload);

        Destroy(gameObject);
    }


    /*
    public IEnumerator ChangeToRed()
    {
        Color originalColor = spriteRenderer.color;
        float elapsedTime = 0f;
        while (elapsedTime < changeDuration)
        {
            spriteRenderer.color = Color.Lerp(originalColor, Color.red, elapsedTime / changeDuration);
            elapsedTime += Time.deltaTime;
            print("test");
            yield return null;
            
        }
        spriteRenderer.color = Color.red;
    }
    */
}
