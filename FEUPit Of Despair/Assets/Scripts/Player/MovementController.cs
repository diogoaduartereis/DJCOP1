using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public GameObject Player;
    public float speed = 0.15f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       float xMov = Input.GetAxis("Horizontal") * speed;
       float yMov = Input.GetAxis("Vertical") * speed;

       rb.MovePosition(Player.transform.position + new Vector3(xMov,yMov,0));
    }

    void Update()
    {
        Player.transform.rotation = Quaternion.identity;
    }
}
