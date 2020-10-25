using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CollisionObject
{
    // Start is called before the first frame update

    public GameObject bullet;
    private int bulletTerm = 0;
    private float defaultY;

    private void Start()
    {
        defaultY = transform.position.y;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();

        MovementVector = Vector2.zero;

        if (Input.GetMouseButton(0))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var diff = worldPosition.x - transform.position.x;

            if (Mathf.Abs(diff) < 0.05f)
            {
                transform.position = new Vector3(worldPosition.x, defaultY, 0);
            }
            else
            {
                MovementVector = new Vector2(diff / 10, 0);
            }
        }

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (this.transform.position.x >= -2.2f)
        //    {
        //        //MovementVector = new Vector2(-0.3f, 0);
        //        transform.position = transform.position + new Vector3(-0.3f, 0, 0);
        //    }
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (this.transform.position.x <= 2.2f)
        //    {
        //        //MovementVector = new Vector2(0.3f, 0);
        //        transform.position = transform.position + new Vector3(0.3f, 0, 0);
        //    }
        //}

        if (bulletTerm++ >= 0.5f)
        {
            var _bullet = Instantiate(bullet);
            _bullet.transform.position = transform.position + new Vector3(0, 1, 0);

            bulletTerm = 0;
        }
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
    }
}