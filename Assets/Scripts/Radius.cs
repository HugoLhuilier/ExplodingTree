using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public GameObject circle;
    public GameObject motherWeapon;
    public float range;

    // Start is called before the first frame update
    void Start()
    {
        range = motherWeapon.GetComponent<UIGun>().range;
        circle.transform.localScale = new Vector3(range, range, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
