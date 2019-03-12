using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private GameObject Player;
    public float PlayerSpeed = 0.15f;

    public float DashSpeed = 1f;
    public float DashCooldown = 5f;
    public float DashTime = 1f;

    private bool dashing = false;
    private Vector3 dashDirection;
    private float currDashCD = 0.0f;
    private float remainingDashTime = 0.0f;

    private Rigidbody2D rb;

    void Start()
    {
        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
       float xMov = Input.GetAxis("Horizontal") * PlayerSpeed;
       float yMov = Input.GetAxis("Vertical") * PlayerSpeed;
       if (!dashing)
       {
           rb.MovePosition(Player.transform.position + new Vector3(xMov, yMov, 0));
       }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
       {
           if (!dashing && currDashCD <= 0 && remainingDashTime <= 0)
           {
                dashDirection = (new Vector3(xMov,yMov,0)).normalized;

                dashing = true;
                currDashCD = DashCooldown;
                remainingDashTime = DashTime;
           }
       }
    }

    void Update()
    {
        Player.transform.rotation = Quaternion.identity;

        if (dashing)
        {
            rb.MovePosition(Player.transform.position + dashDirection * DashSpeed * Time.deltaTime);
            remainingDashTime -= Time.deltaTime;

            if (remainingDashTime <= 0)
            {
                dashing = false;
                remainingDashTime = 0.0f;
                dashDirection = Vector2.zero;
            }
        }

        if (currDashCD > 0)
        {
            currDashCD -= Time.deltaTime;
        }
        else
        {
            currDashCD = 0;
        }

    }
}
