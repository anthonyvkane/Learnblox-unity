using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset textJSON;

    [System.Serializable]
    public class Question {
        public string question, option1, option2, option3, option4;
        public string answer;
    }

    [System.Serializable]
    public class TestBank {
        public Question[] testbank;
    }

    public TestBank myTestBank = new TestBank();
    void Start()
    {
        myTestBank = JsonUtility.FromJson<TestBank>(textJSON.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
