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
    public float DashCost = 10f;
    private StaminaController StaminaController;

    private bool dashing = false;
    private Vector3 dashDirection;
    private float currDashCD = 0.0f;
    private float remainingDashTime = 0.0f;

    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    private HealthController health;
    private bool guarding = false;

    private Rigidbody2D rb;

    private SpriteRenderer renderer;
    public Color GuardFilter = new Color(200,0.1f,0.1f,1.0f);
    private Color RegularColor;

    public float GuardStaminaCost = 0.5f;
    private float FreezeTime;
    private bool Frozen;

    public AudioSource walkingSound;
    private AudioSource dashSound;

    void Start()
    {
        Player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        health = GetComponent<HealthController>();
        renderer = GetComponent<SpriteRenderer>();
        RegularColor = renderer.color;
        StaminaController = this.GetComponent<StaminaController>();
        FreezeTime = 0;
        walkingSound = this.GetComponents<AudioSource>()[0];
        dashSound = this.GetComponents<AudioSource>()[1];
    }
    
    void FixedUpdate()
    {
       playerMoving = false;
       float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
        
        if(!Frozen)
        {
            if (!dashing)
            {
                if (!guarding)
                {
                    rb.MovePosition(
                        Player.transform.position + new Vector3(horizontal, vertical, 0).normalized * PlayerSpeed * Time.deltaTime);
                    if (horizontal > 0.1f || horizontal < -0.1f)
                    {
                        //rb.MovePosition(Player.transform.position + new Vector3(horizontal, vertical, 0));
                        //Player.transform.Translate(new Vector3(horizontal * PlayerSpeed, 0f, 0f));
                        playerMoving = true;
                        if(!walkingSound.isPlaying)
                            walkingSound.Play();
                        lastMove = new Vector2(horizontal, 0f);
                    }

                    if (vertical > 0.1f || vertical < -0.1f)
                    {
                        //rb.MovePosition(Player.transform.position + new Vector3(horizontal, vertical, 0));
                        //Player.transform.Translate(new Vector3(0f, vertical * PlayerSpeed, 0f));
                        playerMoving = true;
                        if (!walkingSound.isPlaying)
                            walkingSound.Play();
                        lastMove = new Vector2(0f, vertical);
                    }

                    anim.SetFloat("MoveX", horizontal);
                    anim.SetFloat("MoveY", vertical);
                    anim.SetBool("PlayerMoving", playerMoving);
                    anim.SetFloat("LastMoveX", lastMove.x);
                    anim.SetFloat("LastMoveY", lastMove.y);

                    if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
                    {
                        if (StaminaController.getStamina() > this.GuardStaminaCost)
                        {
                            SetGuarding();
                        }
                    }
                }
                else
                {
                    if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
                    {
                        SetNotGuarding();
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            
            if (StaminaController.getStamina() >= this.DashCost)
            {
                if (!dashing && currDashCD <= 0 && remainingDashTime <= 0)
                {
                    dashDirection = (new Vector3(horizontal, vertical, 0)).normalized;

                    dashing = true;
                    currDashCD = DashCooldown;
                    remainingDashTime = DashTime;
                    StaminaController.playerDash(this.DashCost);
                    dashSound.Play();
                }
            }
       }

        if (!playerMoving)
            walkingSound.Stop();

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

        if(FreezeTime > 0)
        {
            FreezeTime -= Time.deltaTime;
        }
        else
        {
            FreezeTime = 0;
            this.Frozen = false;
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

    public void SetNotGuarding()
    {
        guarding = false;
        health.SetInvulnerable(false, 0);
        renderer.color = RegularColor;
    }

    public void SetGuarding()
    {
        guarding = true;
        health.SetInvulnerable(true, GuardStaminaCost);
        renderer.color = GuardFilter;
    }

    public void FreezePlayer(float FreezeTime)
    {
        this.FreezeTime = FreezeTime;
        this.Frozen = true;
    }
}
