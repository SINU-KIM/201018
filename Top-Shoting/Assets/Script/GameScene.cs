using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScene : Singleton<GameScene>
{
    private int score;

    [SerializeField]
    private Text score_Text;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        score = 0;
    }

    // Update is called once per frame
    public void AddScore(int value)
    {
        score += value;
        score_Text.text = $"Score : {score}";
    }
}