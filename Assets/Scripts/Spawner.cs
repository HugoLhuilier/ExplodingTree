using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Spawner : MonoBehaviour
{

    public GameObject monsterPrefab;

    [SerializeField] private int startTime;                 // Initial delay (in s) before the start of the FIRST wave
    [SerializeField] private int cooldownBetweenWaves;      // Delay between waves (in s)

    //[SerializeField] private int easingFactor;
    [SerializeField] private int numberOfMonsters;
    [SerializeField] private int numberOfWaves;

    // A wave is defined as :
    // { spawnRate (spawns every 10 seconds), numberOfMob1, numberOfMob2, ... , numberOfMobN }



    public int[][] waves;



    private int timer;                      // timer wave
    private int waveLevel;                  // Number of current wave
    private int spawnRate;                  // Current wave spawnRate
    private bool noMoreMonsterToSpawn;      // Value indicating if all enemies are defeated


    public List<GameObject> monstersAlive;


    public GameObject CreateMonster(int ty)                         // Constructor of a monster
    {                        
        GameObject monster  = Instantiate(monsterPrefab) as GameObject;
        Monster script = monster.GetComponent<Monster>();

        script.Consturct(ty);                                        // construct initializes the monster (setting his name hp speed etc.)

        return monster;
    }
    



    // Start is called before the first frame update
    void Start()
    {
        timer = -startTime;
        waveLevel = 0;

        waves = new int[2][];

        waves[0] = new int[] { 5, 1, 1, 0, 0, 0, 0, 0, 0};
        waves[1] = new int[] { 5, 0, 1, 1, 0, 0, 0, 0, 0};
        //waves[2] = new int[] { 2, 0, 3, 0 };
        //waves[3] = new int[] { 3, 10, 5, 0 };


        Debug.Log("Game start ! Begin of first wave in " + startTime + " seconds");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (noMoreMonsterToSpawn)
        {
            if(monstersAlive.Count == 0)
            {
                noMoreMonsterToSpawn = false;
                Debug.Log("Last Monster died, end of wave\nNext wave in "+cooldownBetweenWaves+" seconds");
            }
        }
        else
        {
            if (timer == 0)
            {
                float spR = 10 * 60f / waves[waveLevel][0];
                print(spR);
                spawnRate = (int)spR;
            }
            else if (timer > 0)
            {

                if (timer % spawnRate == 0)
                {
                    List<int> monsterList = GetMonsterList();
                    if (monsterList.Count > 0)
                    {
                        int randomMonster = monsterList[Random.Range(0, monsterList.Count)];
                        monstersAlive.Add(CreateMonster(randomMonster));
                        waves[waveLevel][randomMonster + 1] -= 1;
                    }
                    else
                    {
                        timer = -cooldownBetweenWaves*60;
                        Debug.Log("No more monsters to spawn, end of wave");
                        noMoreMonsterToSpawn = true;

                        if (waveLevel+1 < numberOfWaves)
                        {
                            waveLevel++;
                            Debug.Log("Waiting for death off all ennemies");
                        }
                        else
                        {
                            Debug.Log("No more waves !");
                            Application.Quit();
                        }
                    }
                }

            }


            timer++;
        }

        
    }


    List<int> GetMonsterList(){      // Return a list of possible monsters that can be instantiated, returns null if any

        List<int> monsterList = new List<int>();

        for (int i = 1; i <= numberOfMonsters; i++)
        {
            if (waves[waveLevel][i] > 0)
            {
                monsterList.Add(i - 1);
            }
        }

        return monsterList;

    }
    


}
