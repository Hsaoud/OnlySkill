using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour {

    public GameObject pattern;
    public float patternVelocity = 5;
    

    void Start() {
        pattern = Resources.Load("Prefab/Patterns/PatternA") as GameObject;
        CreateNewPattern();
    }
    
    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Respawn") {
            CreateNewPattern();
        }
    }

    void CreateNewPattern() {
        patternVelocity =5+Time.timeSinceLevelLoad / 5;
        Instantiate(pattern, transform.position, transform.rotation, transform);
    }
}
