using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUD : Singleton<GameHUD>
{
    private int score;
    private Text score_Text;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        score = 0;

        foreach (var child in transform.GetComponentsInChildren<Transform>(true))
        {
            if (child.gameObject.name == "Text")
            {
                score_Text = child.gameObject.GetComponent<Text>();
                break;
            }
        }
    }

    // Update is called once per frame
    public void AddScore(int value)
    {
        score += value;
        score_Text.text = $"Score : {score}";
    }
}