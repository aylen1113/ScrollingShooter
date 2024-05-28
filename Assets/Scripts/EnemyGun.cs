using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireBullet()
    {
        GameObject player = GameObject.Find("Player");

        if(player == null )
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;  

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);


        }
    }
}
