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

    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    private Rigidbody2D rb;

    void Start()
    {
        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
       playerMoving = false;
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
       if (!dashing)
       {
           rb.MovePosition(Player.transform.position + new Vector3(horizontal, vertical, 0) * PlayerSpeed);
            if (horizontal > 0.5f || horizontal < -0.5f)
            {
                //rb.MovePosition(Player.transform.position + new Vector3(horizontal, vertical, 0));
                //Player.transform.Translate(new Vector3(horizontal * PlayerSpeed, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(horizontal, 0f);
            }
            if (vertical > 0.5f || vertical < -0.5f)
            {
                //rb.MovePosition(Player.transform.position + new Vector3(horizontal, vertical, 0));
                //Player.transform.Translate(new Vector3(0f, vertical * PlayerSpeed, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, vertical);
            }

            anim.SetFloat("MoveX", horizontal);
            anim.SetFloat("MoveY", vertical);
            anim.SetBool("PlayerMoving", playerMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
       {
           if (!dashing && currDashCD <= 0 && remainingDashTime <= 0)
           {
                dashDirection = (new Vector3(horizontal,vertical,0)).normalized;

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
