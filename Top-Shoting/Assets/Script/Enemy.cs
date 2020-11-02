using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : CollisionObject
{
    // Start is called before the first frame update
    [SerializeField]
    private int hp = 3;

    // Update is called once per frame
    public void Start()
    {
        MovementVector = new Vector2(0, -5 * Time.deltaTime);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHp(int value)
    {
        hp -= value;
        if (hp == 0)
        {
            var destroyEffectPrefab = Resources.Load("Prefabs/Boom") as GameObject;
            var destroyEffect = Instantiate(destroyEffectPrefab, transform);
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            GameScene.Instance.AddScore(10);

            Invoke("Explosion", 0.5f);
        }
    }

    private void Explosion()
    {
        Destroy(gameObject);
    }
}