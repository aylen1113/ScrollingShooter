using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    Vector2 mousePos;

    public GameObject PlayerBullet;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();

       
        if (Input.mousePosition.x >= 0 && Input.mousePosition.y >= 0 &&
            Input.mousePosition.x <= Screen.width && Input.mousePosition.y <= Screen.height)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet01 = Instantiate(PlayerBullet);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = Instantiate(PlayerBullet);
            bullet02.transform.position = bulletPosition02.transform.position;
        }
    }

    private void FixedUpdate()
    {
        Vector2 lookDirection = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(x * speed * Time.fixedDeltaTime, y * speed * Time.fixedDeltaTime);
    }
}
