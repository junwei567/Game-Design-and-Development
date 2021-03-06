using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "GameConstants", menuName =  "ScriptableObjects/GameConstants", order =  1)]
public class GameConstants : ScriptableObject
{
    // for Scoring system
    int currentScore;
    int currentPlayerHealth;

    public bool playerAlive = true;

    // for Reset values
    Vector3 gombaSpawnPointStart = new Vector3(2.5f, -0.45f, 0); // hardcoded location
    // .. other reset values 

    // for Consume.cs
    public  int consumeTimeStep =  10;
    public  int consumeLargestScale =  4;
    
    // for Break.cs
    public  int breakTimeStep =  30;
    public  int breakDebrisTorque =  10;
    public  int breakDebrisForce =  10;
    
    // for SpawnDebris.cs
    public  int spawnNumberOfDebris =  10;
    
    // for Rotator.cs
    public  int rotatorRotateSpeed =  6;
    
    // for EnemyController.cs
    public float maxOffset = 5.0f;
    public float enemyPatrolTime = 2.0f;

    public int groundSurface = -1;

    public int Score = 0;
    // for testing
    public  int testValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
