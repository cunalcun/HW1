using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public float attack;

    public float crit;

    public float health;

    public float defence;

    public float atkrate;

    public float rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) { transform.Translate(0, 0, speed*Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(0, 0, -speed*Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationspeed*Time.deltaTime, 0);
    }
}
