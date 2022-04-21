using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TextController : MonoBehaviour
{
    public TextAsset textJSON;
    public GameObject QuestionText;
    public GameObject OptionTextA;
    public GameObject OptionTextB;
    public GameObject OptionTextC;
    public GameObject OptionTextD;
    public GameObject CorrectnessText;
    public GameObject CompleteText;
    public static string answer;
    public static string attempt;
    public static bool answered = false;
    public bool correct = false;
    public static int level = 0;
    int totalLevels;

    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] options;
        public string answer;
    }

    [System.Serializable]
    public class TestBank
    {
        public Question[] questions; 
    }

    public TestBank testBank = new TestBank();
    void Start()
    {
    testBank = JsonUtility.FromJson<TestBank>(textJSON.text);

        Debug.Log(testBank.questions.Length);
        for (int i = 0; i < testBank.questions.Length; i++) {
            Debug.Log(testBank.questions[i].question);
        }
        totalLevels = testBank.questions.Length;
        Debug.Log("Total Levels:"+totalLevels);
    }


    void Update()
    {
        
        if(level >= testBank.questions.Length ){    //if game over, stop looking at array, causes errors otherwise
        
            CompleteText.GetComponent<UnityEngine.UI.Text>().text = "Game Complete!";
            return;
        }
            
        answer = testBank.questions[level].answer;
        QuestionText.GetComponent<UnityEngine.UI.Text>().text = testBank.questions[level].question;
        OptionTextA.GetComponent<UnityEngine.UI.Text>().text = testBank.questions[level].options[0];
        OptionTextB.GetComponent<UnityEngine.UI.Text>().text = testBank.questions[level].options[1];
        OptionTextC.GetComponent<UnityEngine.UI.Text>().text = testBank.questions[level].options[2];
        OptionTextD.GetComponent<UnityEngine.UI.Text>().text = testBank.questions[level].options[3];
        
        
       if (answered)
        {
            if (attempt == answer) {
                correct = true;
            }
            Debug.Log(attempt);
            if (correct)
            {
                CorrectnessText.GetComponent<UnityEngine.UI.Text>().text = "Correct";
                if (level < testBank.questions.Length)
                {
                    answered = false;
                    answer = "";
                    attempt = "";
                    CorrectnessText.GetComponent<UnityEngine.UI.Text>().text = "";
                    level++;
                }
            }
            else 
            {
                CorrectnessText.GetComponent<UnityEngine.UI.Text>().text = "Incorrect";
            }
        }

        // txt.GetComponent<UnityEngine.UI.Text>().text = question;

    }
}
