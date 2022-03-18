using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToSever : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Go to Menu Scene
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Menu Scene");
    }

}
