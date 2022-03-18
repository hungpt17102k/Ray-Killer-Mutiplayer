using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score = 0;
    PhotonView view;
    public Text scoreDisplay;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void AddScore()
    {
        view.RPC("AddScoreRPC", RpcTarget.All);
    }

    [PunRPC]
    private void AddScoreRPC()
    {
        score++;
        scoreDisplay.text = score.ToString();
    }
}
