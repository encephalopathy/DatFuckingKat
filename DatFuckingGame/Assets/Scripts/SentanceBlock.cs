using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SentanceBlock : MonoBehaviour {

    public Text SentanceTextUI;

    public void AssignSentance(string sentance)
    {
        SentanceTextUI.text = sentance;
    }
}
