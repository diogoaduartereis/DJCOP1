using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularShootingController : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject Bullet;

    void Start()
    {
        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 playerPos = Player.transform.position;
            Vector3 direction = new Vector3(mousePos.x - playerPos.x, mousePos.y - playerPos.y, 0);

            GameObject newBullet = Instantiate(Bullet, Player.transform.position, Quaternion.identity) as GameObject;
            newBullet.GetComponentInChildren<BulletController>().SetMovementDirection(direction);
        }
    }
}
