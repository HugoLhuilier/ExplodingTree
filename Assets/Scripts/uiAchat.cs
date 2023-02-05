using UnityEngine;

public class uiAchat : MonoBehaviour
{
    [SerializeField] GameObject typedemachine;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject spot;
    [SerializeField] GameObject player;
    [SerializeField] int price;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectsWithTag("player")[0];

    }

    // Update is called once per frame
    void Update()
    {




    }
    void OnMouseOver()

    {
        print("oui3");
        if (Input.GetMouseButtonDown(0))
        {
            print("oui2");
            Instantiate(typedemachine, this.transform.parent.position +new Vector3(0, 0.5f), this.transform.parent.rotation);
            player.GetComponent<Ressources>().resources[0] -= price;
            Destroy(this.transform.parent.gameObject);
        }
    }
}
