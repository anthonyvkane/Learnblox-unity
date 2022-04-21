using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField usernameInput;
    public Text buttonText;

    public void OnClickConnect(){
        if(usernameInput.text.Length >= 1) { //did a user input a name?
            PhotonNetwork.NickName = usernameInput.text;
        }
        buttonText.text = "Connecting...";
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster(){ //Called when connected to server
        SceneManager.LoadScene("Lobby");
    }

}
