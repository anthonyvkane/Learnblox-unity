using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public Text roomName;
    public GameObject startButton;

    public GameObject playerPrefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public GameObject myPlayer;

    private string roomId;

    private int currHair = 0;
    public List<Sprite> hairs = new List<Sprite>();
    private int currBody = 0;
    public List<Sprite> bodies = new List<Sprite>();

    private int currClothes = 0;
    public List<Sprite> clothess = new List<Sprite>();

    PhotonView view;

    Player xd;

    private void Start(){
        PhotonNetwork.JoinLobby();   
    }

    public void OnClickCreate(){
        roomId = generateID();
        PhotonNetwork.CreateRoom(roomId);
    }

    public override void OnJoinedRoom() {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        PhotonNetwork.AutomaticallySyncScene = true;
        spawnGuy();
    }

    public void JoinRoom(){
        if(roomInputField.text.Length >= 1) {
            roomId = roomInputField.text;
            PhotonNetwork.JoinRoom(roomInputField.text);
        }
    
    }
    private void spawnGuy() {
        if(PhotonNetwork.IsMasterClient)
            startButton.SetActive(true);
        Vector2 randomPosition = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
        myPlayer = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        view = myPlayer.GetComponent<PhotonView>();
        xd = myPlayer.GetComponent<Player>();
        
    }

    public void startGame(){
        Debug.Log("starting game...");
        PhotonNetwork.LoadLevel("Game");
        xd.ResetPos();
    }

    public string generateID(){
            string lobbyID = "";
            for(int i = 0; i < 5; i++){
                int random = UnityEngine.Random.Range(0,6);
                if(random < 26)     //big A = 65 and Z = 90
                    lobbyID += (char)(65 + random);
                else //small a = 97 and z = 122
                    lobbyID += (random - 26).ToString();
            }
            Debug.Log($"Generated ID: {lobbyID}");
            roomName.text = "Room Code: " + lobbyID;
            return lobbyID;
        }
    
    public void nextHair(){
        currHair++;
        if(currHair >= hairs.Count)
        {
            currHair = 0;
        }
        myPlayer.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = hairs[currHair];
        //view.transform.parent.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = hairs[currHair];
        
    }

    public void NextBody()
    {
        currBody++;
        if(currBody >= bodies.Count)
        {
            currBody = 0;
        }
        myPlayer.transform.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = bodies[currBody];
    }

    public void NextClothes()
    {
        currClothes++;
        if(currClothes >= clothess.Count)
        {
            currClothes = 0;
        }
        myPlayer.transform.GetChild(3).gameObject.GetComponent<SpriteRenderer>().sprite  = clothess[currClothes];
    }
}
