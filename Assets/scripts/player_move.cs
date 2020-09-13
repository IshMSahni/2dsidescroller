using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public int playerspeed = 10;
    private bool facingright = false;
    public int playerjumppower = 1250;
    private float moveX;
    public bool isGrounded;
    public float playertillbottomblock = 0.7f;

    // Update is called once per frame
    void Update()
    {
        Playermove();
        PlayerRaycast();
        
    }
    void Playermove()
    {
        //controls
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true) { Jump(); }
        //animations
        //player direction
        if (moveX <0.0f && facingright == false) { FlipPlayer(); }
        else if(moveX > 0.0f && facingright == true)
        {
            FlipPlayer();
        }
        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerspeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
        //jumping code
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerjumppower);
        isGrounded = false;
    }
    void FlipPlayer() {
        facingright = !facingright;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
    }
    void PlayerRaycast()
    {
        RaycastHit2D rayup = Physics2D.Raycast(transform.position, Vector2.up);
        //TO DO fix this up
        if (rayup != null && rayup.collider != null && rayup.distance < playertillbottomblock && rayup.collider.name == "breakblock")
        {
            Destroy(rayup.collider.gameObject);
        }
        //Debug.Log("killed da enemy");
        RaycastHit2D raydown = Physics2D.Raycast(transform.position, Vector2.down);
        //Debug.Log(hit.distance);
            if (raydown != null && raydown.collider!= null && raydown.distance < playertillbottomblock && raydown.collider.tag == "enemy") {
            //Debug.Log("killed da enemy");
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            //Destroy(raydown.collider.gameObject);
            raydown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            raydown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            raydown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            raydown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            raydown.collider.gameObject.GetComponent<enemymove>().enabled = false;
        }
        if (raydown.distance < playertillbottomblock && raydown.collider.tag != "enemy")
        {
            isGrounded = true;
        }
    }
}
