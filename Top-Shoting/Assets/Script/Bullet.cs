using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CollisionObject
{
    // Start is called before the first frame update
    private void Start()
    {
        MovementVector = new Vector2(0, 1);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Square")
            Destroy(gameObject);
        else if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            collision.gameObject.GetComponent<Enemy>().DecreaseHp(1);
            Destroy(gameObject);
        }
    }
}