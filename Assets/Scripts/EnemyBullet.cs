using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 direction;
    bool isReady;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        isReady = false;
    }

    public void SetDirection(Vector2 direction)
    {
        direction = direction.normalized;

        isReady = true;

    }
    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            Vector2 position = transform.position;

            position += direction * speed * Time.deltaTime;

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < max.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    }




