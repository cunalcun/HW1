using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject ShootPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) { 
            Instantiate(prefab,transform.position,transform.rotation);

            GameObject clone = Instantiate(prefab);
            clone.transform.position = transform.position;
            clone.transform.rotation = transform.rotation;
        }
    }

        
}
