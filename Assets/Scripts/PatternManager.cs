using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternManager : MonoBehaviour
{

    public GameObject pattern;
    public float patternVelocity = 5;
    public int currentPatternDifficulty = 1;
    public int generatedPattern = 1;
    public string powerUp = "";

    void Start()
    {
        pattern = Resources.Load("Prefab/Patterns/" + currentPatternDifficulty + "Pattern" + generatedPattern) as GameObject;
        CreateNewPattern();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Respawn")
        {
            CreateNewPattern();
        }
    }

    void CreateNewPattern()
    {
        patternVelocity = 5 + Time.timeSinceLevelLoad / 5;
        updateGeneratedPattern();
        pattern = Resources.Load("Prefab/Patterns/" + currentPatternDifficulty + "/Pattern" + generatedPattern + powerUp) as GameObject;
        Instantiate(pattern, transform.position, transform.rotation, transform);
    }

    private void updateGeneratedPattern()
    {
        generatedPattern = Random.Range(1, 6);
		if (Random.Range(0, 100) < 4)
        {
            powerUp = "P";
        }
        else
        {
            powerUp = "";
        }
    }
}
