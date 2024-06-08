using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireBullet", 1f, 1f);
    }

    void FireBullet()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Debug.Log("jugador encontrado");
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
