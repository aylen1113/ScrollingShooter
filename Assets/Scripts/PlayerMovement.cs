using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject PlayerBullet;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;


        Move(direction);

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet01 = Instantiate(PlayerBullet);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = Instantiate(PlayerBullet);
            bullet02.transform.position = bulletPosition02.transform.position;
        }
    }



void Move(Vector2 direction)
    {
      
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); 
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 
        //max.x = max.x - 0.225f; //subtract the player sprite half width
        //min.x = min.x + 0.225f; //add the player sprite half width

        //max.y = max.y - 0.285f; //subtract the player sprite half height
        //min.y = min.y + 0.285f; //add the player sprite half height

    
        Vector2 pos = transform.position;

 
        pos += direction * speed * Time.deltaTime;

     
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

     
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || (collision.CompareTag("EnemyBullet")))
        {
            Destroy(gameObject);

        }
    }
}

