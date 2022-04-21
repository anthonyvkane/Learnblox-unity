using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class InGameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject playerPrefab;

    void Start()
    {
        //spawnGuy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnGuy() {
       // Debug.Log("spawning guy...");
        Vector2 randomPosition = new Vector2(0,0);
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
    }

}
