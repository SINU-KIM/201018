using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject bullet;
    private int bulletTerm = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.transform.position.x >= -2.2f)
            {
                transform.position = transform.position + new Vector3(-0.3f, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (this.transform.position.x <= 2.2f)
            {
                transform.position = transform.position + new Vector3(0.3f, 0, 0);
            }
        }

        if (bulletTerm++ >= 1)
        {
            var _bullet = Instantiate(bullet);
            _bullet.transform.position = transform.position;

            bulletTerm = 0;
        }
    }
}
