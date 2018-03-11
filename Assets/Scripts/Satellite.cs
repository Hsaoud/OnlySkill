using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : inertObject {


    public float speed = 5.0f;
    public float amplitude = 1.0f;
    // Update is called once per frame
    void FixedUpdate() {
        transform.position = new Vector3(transform.position.x, startY + amplitude*(Mathf.Sin(Time.time * speed)), transform.position.z);
    }
}
