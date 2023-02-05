using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{


    //[SerializeField] Sprite[] Sprites;

    /*
    [SerializeField] Sprite ecureuilRobotSprite;
    [SerializeField] Sprite cochonSprite;
    [SerializeField] Sprite ecureuilVolantSprite;
    [SerializeField] Sprite cochonVolantSprite;
    [SerializeField] Sprite pivertRobotSprite;
    [SerializeField] Sprite monkeSprite;
    [SerializeField] Sprite monkeVolantSprite;
    [SerializeField] Sprite canardRobotSurEchasseSprite;
    */


    private string monsterName;
    private int type;
    private float speed;
    private float HP;
    private float damage;
    private int payload;
    private int damageTime;
    private int damageCoolDown;

    private bool alive;
    
    private int direction;      // 1 = left ; -1 = right

    private Vector2 spawnPosition;  // Y random goes from -4 to 2 ; X is finite, -11.3 or 11.3

    private SpriteRenderer spriteRenderer;
    private Sprite sprite;


    public float changeDuration = 1f;

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
        12,
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


    public void Consturct(int ty){        // Monster pseudo-constructor
        type = ty;
        name = Monster.names[ty];
        speed = Monster.speeds[ty];
        HP = Monster.HPs[ty];
        payload = Monster.payloads[ty];
        damage = Monster.damages[ty];
        //sprite = Sprites[ty];

        direction = 1;

        if (Random.Range(0,2) == 0){
            direction = -1;
        }

        spawnPosition = new Vector3(-11*direction,0,0) + new Vector3(0,Random.Range(-4f,2f),0);

        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

   }


    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(spawnPosition.x,spawnPosition.y,0);
        alive = true;
        damageCoolDown = damageTime/2;
        //spriteRenderer.sprite = sprite;
        
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if(alive && Mathf.Abs(transform.position.x) > 1.8f){

            transform.position += new Vector3(direction*speed*0.01f,0,0);
        }
        else if(alive)
        {
            if(damageCoolDown <= 0)
            {
                DealDamage();
                damageCoolDown = damageTime;
            }
            damageCoolDown--;
        }
    }


    void DealDamage()       // Deal 'damage' damage to the player.
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


        GameObject player = GameObject.Find("Player");

        player.GetComponent<Ressources>().GetReward(payload);

        Destroy(gameObject);
    }

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

}
