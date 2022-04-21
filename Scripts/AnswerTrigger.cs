using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerTrigger : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TextController.attempt = text.GetComponent<UnityEngine.UI.Text>().text.ToString();
        TextController.answered = true;
    }
}
