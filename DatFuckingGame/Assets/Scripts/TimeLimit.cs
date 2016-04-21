using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour {

    public float startTime = 300.0f;
    float timeTaken = 0f;
    float deltaTime = 0f;

    public bool timeOver = false;
    public GameObject manager;
    public GameObject logic;
    public GameObject fadeObject;

    public Camera camera;

    Text timeLimitText;
    // Use this for initialization
    void Start () {
        timeLimitText = GetComponent<Text>();
        //The time taken so far
        timeTaken = startTime - Time.time;
        // Format the time nicely
        timeLimitText.text = FormatTime(timeTaken);

        camera = GameObject.FindObjectOfType<Camera>();

    }

    void Awake()
    {
        timeOver = false;
        deltaTime = 0f;
    }

    // Update is called once per frame
    void Update () {
        deltaTime += Time.deltaTime;
        timeTaken = startTime - deltaTime;
        // Format the time nicely
        if (timeTaken < startTime / 10)
        {
            GetComponent<Text>().color = Color.red;
        }
        else if (timeTaken < startTime * 0.313333333333333f) //THIS IS WHEN THE SONG GETS INTENSE!!!
        {
            GetComponent<Text>().color = Color.yellow;
        }
        

        timeLimitText.text = FormatTime(timeTaken);

        if (timeTaken < 0) {

            //manager.GetComponent<StateManagerScript>().state = 2;
            //fadeObject.GetComponent<FadeIn>().FadeToBlack();
            //logic.SetActive(false);
            if (!timeOver)
            {

                camera.GetComponent<AudioSource>().Stop();
                Application.LoadLevel(2);
            }
            timeOver = true;
        }
        else
        {
            timeLimitText.text = FormatTime(timeTaken);
        }
        //else {
        //    //Make start button
            
        //}

    }

    string FormatTime(float time)
    {

        float intTime = time;
        int minutes = (int)(intTime / 60);
        int seconds = (int)(intTime % 60);
        //var fraction : int = time * 10;
        // fraction = fraction % 10;

        //Build string with format
        // 17[minutes]:21[seconds]:05[fraction]

        // timeText = minutes.ToString () ;
        //timeText = timeText + seconds.ToString ();
        string timeText = string.Format("{0:00} {1:00}", minutes, seconds);

        // timeText += fraction.ToString ();
        return timeText;
    }



}
