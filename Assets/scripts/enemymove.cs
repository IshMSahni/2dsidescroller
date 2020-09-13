using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public int EnemySpeed;
    public int XMovedirection;


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMovedirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMovedirection, 0) * EnemySpeed;
        if (hit.distance < 0.7f)
        {
            flip();
            if (hit.collider.tag == "Player")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
    void flip()
    {
        if (XMovedirection > 0) {
            XMovedirection = -1;
        }
        else {
            XMovedirection = 1;
        }
    }
}
