using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public Text healthDisplay;

    PhotonView view;

    public GameObject gameOver;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamge()
    {
        view.RPC("TakeDamgeRPC", RpcTarget.All);
    }

    [PunRPC]
    private void TakeDamgeRPC()
    {
        // Reduce health by 1
        health--;

        // When game is over
        if(health <= 0)
        {
            gameOver.SetActive(true);
        }

        // To display the health and can change when take damage
        healthDisplay.text = health.ToString();
    }
}
