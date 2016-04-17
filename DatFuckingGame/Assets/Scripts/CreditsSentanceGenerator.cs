using UnityEngine;
using System.Collections.Generic;

public class CreditsSentanceGenerator : MonoBehaviour {

    public string FirstSentance;
    public GameObject SentanceTemplate;
    public RectTransform rectObject;
    public float SentenceHeight = 100;

    public UnityEngine.UI.Text ScoreText;

	// Use this for initialization
	void Start () {
        rectObject = GetComponent<RectTransform>();
        float rectHeight = 0;

        if(SentanceStaticSaver.Sentances.Count > 0)
            FirstSentance = SentanceStaticSaver.Sentances[0];
        foreach(string sentanceText in SentanceStaticSaver.Sentances)
        {
            if (sentanceText.Length > 1)
            {
                CreateSentance(char.ToUpper(sentanceText[0]) + sentanceText.Substring(1));
                //rectHeight += SentenceHeight;
                Debug.Log("Added Sentence: " + sentanceText+ ", Rectangle Height = "+rectHeight);
            }
        }

        rectHeight = transform.childCount * SentenceHeight;
        rectObject.sizeDelta = new Vector2(rectObject.rect.width, 0);
        rectObject.sizeDelta = new Vector2(rectObject.rect.width, rectHeight+(SentenceHeight*3));
        ScoreText.text = string.Format("Total Sentance Matches: {0}", SentanceStaticSaver.TotalMatches);
	}

    public void CreateSentance(string sentanceText)
    {
        GameObject sentanceObject = Instantiate(SentanceTemplate) as GameObject;
        sentanceObject.transform.SetParent(transform, false);
        SentanceBlock sentanceBlock = sentanceObject.GetComponent<SentanceBlock>();
        sentanceBlock.AssignSentance(sentanceText);
    }
}
