using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    public InputField nameInput;

    public void ChangeName()
    {
        PhotonNetwork.NickName = nameInput.text;
    }

    public void CreateRoom()
    {
        // Make limited play by 2
        RoomOptions roomOptions = new RoomOptions
        {
            MaxPlayers = 2
        };

        // Create a room with name and phonton
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    // When you create a room, you also join it
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game Scene");
    }
}
