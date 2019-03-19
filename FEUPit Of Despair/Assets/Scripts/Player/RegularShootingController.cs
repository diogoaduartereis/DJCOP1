using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularShootingController : MonoBehaviour
{
    public Vector3 ShootingOffset = new Vector3(0,0.5f,0);

    public float ShootingCooldown = 0.25f;
    private float CurrentShootingCooldown = 0;

    private GameObject Player;
    private Rigidbody2D rb;

    public GameObject Bullet;

    private GameObject BulletHolder;

    void Start()
    {
        BulletHolder = new GameObject("Bullet Holder");

        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (CurrentShootingCooldown <= 0)
            {
                CurrentShootingCooldown = ShootingCooldown;
                //translate the mouse screen coordinate to in-game world coordinates
                Vector3 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                Vector3 playerPos = Player.transform.position + ShootingOffset;

                //calculate general direction for the buller
                Vector3 direction = new Vector3(mousePos.x - playerPos.x, mousePos.y - playerPos.y, 0).normalized;

                //create buller and give it a direction to move in
                GameObject newBullet =
                    Instantiate(Bullet, Player.transform.position + ShootingOffset, Quaternion.identity) as GameObject;
                newBullet.GetComponentInChildren<BulletController>().SetMovementDirection(direction);


                newBullet.transform.parent = BulletHolder.transform;
            }
        }
    }

    void Update()
    {
        if (CurrentShootingCooldown > 0)
        {
            CurrentShootingCooldown -= Time.deltaTime;
        }
        else
        {
            CurrentShootingCooldown = 0;
        }
    }
}
