using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellGun : MonoBehaviour
{
    public GameObject motherWeapon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        GameObject[] UIObject = GameObject.FindGameObjectsWithTag("UIObject");
        foreach (GameObject obj in UIObject)
        {
            Destroy(obj);
        }
        Destroy(motherWeapon);

    }
}
