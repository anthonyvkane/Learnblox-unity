using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ClothesManager : MonoBehaviourPunCallbacks
{
    PhotonView view;
    public SpriteRenderer hair;
    private int currHair = 0;
    public List<Sprite> hairs = new List<Sprite>();

    public SpriteRenderer body;
    private int currBody = 0;
    public List<Sprite> bodies = new List<Sprite>();

    public SpriteRenderer clothes;
    private int currClothes = 0;
    public List<Sprite> clothess = new List<Sprite>();


    void Start()
    {
        view = GetComponent<PhotonView>();
    }
    public void NextHair()
    {
        if(!view.IsMine)
            return;
        Debug.Log("Hit next.");
        currHair++;
        if(currHair >= hairs.Count)
        {
            currHair = 0;
        }
        hair.sprite = hairs[currHair];
    }
    public void NextBody()
    {
        if(!view.IsMine)
            return;
        currHair++;
        if(currBody >= bodies.Count)
        {
            currBody = 0;
        }
        body.sprite = bodies[currBody];
    }

    public void NextClothes()
    {
        if(!view.IsMine)
            return;
        currClothes++;
        if(currClothes >= clothess.Count)
        {
            currClothes = 0;
        }
        clothes.sprite = clothess[currBody];
    }
    
}
