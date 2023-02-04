using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject monsterPrefab;

    [SerializeField] private Vector2[] spawnPoints;
    [SerializeField] private int startTime;
    [SerializeField] private int waveDuration;
    [SerializeField] private int breakDuration;

    [SerializeField] private int startingSpawnsPerSeconds;
    [SerializeField] private int easingFactor;
    [SerializeField] private int[] possibleEnnemies;


    
    private Object monster;
    private int timer;
    private int waveLevel;
    private int spawnsRate;



    public Monster create(int ty, Vector2 spawn){                // Constructor of a monster
        GameObject monster  = Instantiate(monsterPrefab) as GameObject;
        Monster obj = monster.GetComponent<Monster>();
        obj.type = ty;
        obj.name = Monster.names[ty];
        obj.speed = Monster.speeds[ty];
        obj.HP = Monster.HPs[ty];

        obj.spawnPosition = spawn;

        if(obj.spawnPosition.x < 0){
            obj.direction = 1;
        }
        else{
            obj.direction = -1;
        }
        return obj;
    }
    



    // Start is called before the first frame update
    void Start()
    {
        timer = -startTime*60;
        waveLevel = 1;
        spawnsRate = 60/startingSpawnsPerSeconds;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer>=breakDuration){

            if(timer<(waveDuration+breakDuration)*60){
                Monster newMonster;
                if(timer%spawnsRate == 0){
                    newMonster = create(0,spawnPoints[Random.Range(0,6)]); // Le monstre ne spawn pas au bon endroit /!\
                }
            }
            else{
                timer = 0;
            }

        }


        timer++;
    }




}
