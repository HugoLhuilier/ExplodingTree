using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchscene : MonoBehaviour
{
    int phase = 1;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (phase == 2 && Input.GetKeyDown(KeyCode.T))
        {
            this.gameObject.SetActive(true);
            this.transform.position = new Vector3(-0.48f, 4.44f,0f) ;
           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "switch") {
            phase = 2;
            this.transform.position = new Vector3(30, 30, 0);
            this.gameObject.SetActive(false);

        }

    }
}
