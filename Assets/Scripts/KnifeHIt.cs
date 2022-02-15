using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHIt : MonoBehaviour
{
    [SerializeField]
    private Vector2 force;

    private bool isActive = true;
    
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;

    
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        knifeCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            rb.gravityScale = 1;
           

        }
    }

    
private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isActive)
            return;
        isActive = false;

        if (collision.collider.tag == "Ball")
        {
            rb.velocity = new Vector2(0 , 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.4f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.2f);
   
        }
        else if (collision.collider.tag == "Knife")
        {
            Debug.Log("Game Over");
            
            rb.velocity = new Vector2 (rb.velocity.x , -2 );
        }            
    
    }
}
