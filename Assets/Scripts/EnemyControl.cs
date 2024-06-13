using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    GameObject scoreUItext;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        scoreUItext = GameObject.FindGameObjectWithTag("ScoreText");

    }

 
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            GameScore.inst.AddScore();

            Destroy(gameObject); 
        }
    }
}
