using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    [SerializeField] public Transform player;
    [SerializeField] public int maxEnemies = 100;
    [SerializeField] public int secondsBetweenWaves = 10;
    [SerializeField] public GameObject enemy1; // enemy to spawn
    [SerializeField] public int enemiesPerWave = 5; 
    [SerializeField] public int targetFramesPerSecond = 60;

    /* below vars are used to know the spawn limits on the current map, 
    // ignored since spawning at placeholder location
    [SerializeField] private float maxY = 590.0f;
    [SerializeField] private float minY = 657.0f;
    [SerializeField] private float maxX = 1072.0f;
    [SerializeField] private float minX = 427.0f;
    */


    private int framesPassed = 0;

    private List<GameObject> enemyList = new List<GameObject>();

    public void Awake()
    {
        instance = this;
        Application.targetFrameRate = targetFramesPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        // pass time until time to spawn wave
        if (++framesPassed >= secondsBetweenWaves * targetFramesPerSecond)
        {
            // reset timer
            framesPassed = 0;

            // spawn all enemies in a wave
            for (int i = 0; i < enemiesPerWave; ++i)
            {
                // ignore spawn if maxEnemies reached
                if (enemyList.Count < maxEnemies)
                {
                    // placeholder: spawn at center of map (x: 716, y: 401)                    
                    Vector3 spawnPosition = new Vector3(716.0f, 401.0f, 1f);

                    // spawn enemy
                    GameObject newEnemy = Instantiate(enemy1);

                    // get enemy object
                    Enemy newSpawn = newEnemy.GetComponent<Enemy>();

                    // move enemy to spawnPosition and assign the player as target for enemy
                    newEnemy.transform.position = spawnPosition;
                    newSpawn.player = this.player;

                    // add enemy in the list of spawned enemies
                    enemyList.Add(newEnemy);
                }
            }

        }
    }
}
