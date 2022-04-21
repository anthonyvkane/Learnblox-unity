using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class Player : MonoBehaviour
{
    public float speed;
    public Sprite head;
    

    //Animator animator;
    PhotonView view;
    
    void Start()
    {
        view = GetComponent<PhotonView>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine){
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * speed * Time.deltaTime;
            
        }
    }

    public void ResetPos(){
        transform.position = new Vector3(0,0,0);
    }
}
