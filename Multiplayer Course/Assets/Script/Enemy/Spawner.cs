using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float startTimeBtwSpawns;
    float timeBtwSpawns;

    private void Start()
    {
        // To start time in the first frame
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        // Check if the spawner is the master client or there are 2 players in a room
        if(PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }

        // Spawning enemy
        if (timeBtwSpawns <= 0)
        {
            // Get random position of spawn points
            Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;

            // Instantiate the enemy at that point
            PhotonNetwork.Instantiate(enemy.name, spawnPos, Quaternion.identity);

            // Restart the time between spawn
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            // Reduce timeBtwSpawns every frame
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
