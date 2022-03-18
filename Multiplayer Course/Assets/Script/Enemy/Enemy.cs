using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Enemy : MonoBehaviour
{
    PlayerController[] players;
    PlayerController nearestPlayer;
    public float speed;

    Score score;

    private void Start()
    {
        // Find the object have the PlayerController script as component
        players = FindObjectsOfType<PlayerController>();
        score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        // The distance between enemy and players
        float distance1 = Vector2.Distance(transform.position, players[0].transform.position);
        float distance2 = Vector2.Distance(transform.position, players[1].transform.position);

        if (distance1 < distance2)
        {
            nearestPlayer = players[0];
        }
        else
        {
            nearestPlayer = players[1];
        }

        // Move towrad to the nearestPlayer
        if (nearestPlayer != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, nearestPlayer.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (other.CompareTag("GoldenRay"))
            {
                score.AddScore(); // Add point when kill a enemy
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
