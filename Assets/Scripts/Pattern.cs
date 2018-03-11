using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour {

    public float patternVelocity = 5;

    private Rigidbody2D rb;
    
    void Start() {
        patternVelocity = GetComponentInParent<PatternManager>().patternVelocity;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -patternVelocity;
    }

    void UpdateVelocity(float vx, float vy) {
        rb.velocity = new Vector2(vx, vy);
    }
}
