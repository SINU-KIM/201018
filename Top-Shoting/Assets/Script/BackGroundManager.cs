using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    public List<GameObject> BackGroundSprites;
    public float MovementSpeed;
    private float StartPointY;
    private float spriteHeight;

    // Start is called before the first frame update
    private void Start()
    {
        StartPointY = BackGroundSprites[0].transform.position.y;
        spriteHeight = BackGroundSprites[0].GetComponent<SpriteRenderer>().bounds.size.y;

        for (int i = 1; i < BackGroundSprites.Count; i++)
        {
            var prevBack = BackGroundSprites[i - 1];
            var curBack = BackGroundSprites[i];
            curBack.transform.position = new Vector2(0, prevBack.transform.position.y + spriteHeight);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < BackGroundSprites.Count; ++i)
        {
            var background = BackGroundSprites[i];

            if (background.transform.position.y < StartPointY - spriteHeight)
            {
                var prevIndex = i - 1 >= 0 ? i - 1 : BackGroundSprites.Count - 1;
                var prevBack = BackGroundSprites[prevIndex];
                background.transform.position = new Vector2(0, prevBack.transform.position.y + spriteHeight);
            }

            background.transform.Translate(new Vector2(0, -MovementSpeed * Time.deltaTime));
        }
    }
}