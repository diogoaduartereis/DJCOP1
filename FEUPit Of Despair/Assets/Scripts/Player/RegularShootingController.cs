using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularShootingController : MonoBehaviour
{
    public Vector3 ShootingOffset = new Vector3(0,0.5f,0);

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
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector3 playerPos = Player.transform.position + ShootingOffset;
            Vector3 direction = new Vector3(mousePos.x - playerPos.x, mousePos.y - playerPos.y, 0).normalized;

            GameObject newBullet = Instantiate(Bullet, Player.transform.position + ShootingOffset, Quaternion.identity) as GameObject;
            newBullet.GetComponentInChildren<BulletController>().SetMovementDirection(direction);
        }
    }
}
