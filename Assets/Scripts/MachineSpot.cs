using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MachineSpot : MonoBehaviour
{
    private int cost;
    GameObject machine;
    Dialogs diagBox;
    [SerializeField] Transform pt;
    [SerializeField] GameObject player;
    float distance;
    [SerializeField] float distancemax = 5;
    [SerializeField] int price;
    [SerializeField] GameObject UIAchat;
    GameObject a;
    GameObject b;
    GameObject c;
    GameObject w;

    [SerializeField] private GameObject wheel;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject red;
    [SerializeField] private GameObject orange;


    // Start is called before the first frame update
    void Start()
    {
        print("début");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(pt.position, this.transform.position);
        if (distance < distancemax)
        {
            print("range");

            if (Input.GetKeyDown(KeyCode.F) && player.GetComponent<Ressources>().getCoins() > price )
            {
                print("oui");
                Create();

            }
        }
        else
        {
            if (w != null)
                Destroy(w);
                
        }
        this.GetComponent<Renderer>().enabled = true;
    }

    public void buy(Ressources player)
    {
        if (player.getCoins() >= cost)
        {
            player.addCoins(-cost);
            Instantiate(machine);
            Destroy(this.gameObject);
        }
        else
        {
            diagBox.sendMessage("Vous devez posséder " + cost + " pièces pour construire un extracteur ici.",5f);
        }
    }
    void Create()
    {
        w = Instantiate(wheel, this.transform.position + new Vector3(0, -0.5f), Quaternion.identity);
        a = Instantiate(red, this.transform.position + new Vector3(0, 0.5f), Quaternion.identity);
        b = Instantiate(blue, this.transform.position + new Vector3(0, -1.5f), Quaternion.identity);
        c = Instantiate(orange, this.transform.position + new Vector3(1, -0.5f), Quaternion.identity);
        a.transform.SetParent(w.transform);
        b.transform.SetParent(w.transform);
        c.transform.SetParent(w.transform);
        
        this.gameObject.GetComponent<Renderer>().enabled = false;
        this.gameObject.SetActive(false);
     


    }
}
