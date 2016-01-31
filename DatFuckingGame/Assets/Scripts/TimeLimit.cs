using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeLimit : MonoBehaviour {

    float startTime = 200f;
    float timeLimit = 90.0f;
    float timeTaken = 0f;

    public bool timeOver = false;

    Text timeLimitText;
    // Use this for initialization
    void Start () {
        timeLimitText = GetComponent<Text>();
        //The time taken so far
        timeTaken = startTime - Time.time;
        // Format the time nicely
        timeLimitText.text = FormatTime(timeTaken);

    }

    // Update is called once per frame
    void Update () {
        timeTaken = startTime - Time.time;
        // Format the time nicely
        timeLimitText.text = FormatTime(timeTaken);

        if (timeTaken >= timeLimit)
            timeOver = true;

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
