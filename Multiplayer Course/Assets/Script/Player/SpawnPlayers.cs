using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;

    // Các tọa độ để tạo ra diện tích triệu hồi người chơi
    public float minX, minY, maxX, maxY;

    private void Start()
    {
        // Create a random spawn position for players
        Vector2 randomSpawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Instantiate the player
        PhotonNetwork.Instantiate(player.name, randomSpawnPos, Quaternion.identity);
    }
}
