using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inertObject : MonoBehaviour {

    private Rigidbody2D rb;
    public float patternVelocity;
    protected float startY;
    protected float startX;
    
    void Start() {
        Pattern pattern = GetComponentInParent<Pattern>();
        patternVelocity = pattern.patternVelocity;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -patternVelocity;
        startY = this.transform.position.y;
        startX = this.transform.position.x;
    }
    
}