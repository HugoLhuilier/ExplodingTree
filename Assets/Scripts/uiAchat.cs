using UnityEngine;

public class uiAchat : MonoBehaviour
{
    [SerializeField] GameObject typedemachine;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject spot;
    // Start is called before the first frame update
    void Start()
    {



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
            Instantiate(typedemachine, this.transform.parent.position, this.transform.parent.rotation);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
