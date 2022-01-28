using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Vector3 moveDelta;
    public bool isJumping, movingRight, movingLeft, idle, sliding;
    private Animator anim;
    private SpriteRenderer _renderer;
    public float playerHealth = 100f, rigidXVel,rigidYVel;
    public GameObject player;
    Rigidbody2D playerRigid;
    public AudioClip[] audioClipArray;
    public AudioSource audioSource;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical"), xVelocity, yVelocity;
        movingLeft = helper.PlayerBoolSwitcher("left", x, y);
        movingRight = helper.PlayerBoolSwitcher("right", x, y);
        rigidXVel = transform.InverseTransformDirection(playerRigid.velocity).x;
        rigidYVel = transform.InverseTransformDirection(playerRigid.velocity).y;
        if (movingLeft == true)
            _renderer.flipX = true;
        else if (movingRight == true)
            _renderer.flipX = false;
        
        print(rigidYVel);
        if (movingLeft == true || movingRight == true && isJumping == false)
            anim.SetBool("isWalking", true);
        if (movingLeft == false && movingRight == false)
            anim.SetBool("isWalking", false);
        xVelocity = helper.PlayerMovementRestraints(isJumping, idle, movingLeft, movingRight, 'x');
        yVelocity = helper.PlayerMovementRestraints(isJumping, idle, movingLeft, movingRight, 'y');
        helper.MoveEntity(xVelocity, yVelocity, playerRigid);
        isJumping = helper.PlayerBoolSwitcher("jump", x, y);
        idle = helper.PlayerBoolSwitcher("idle", x, y);
        if (isJumping == true)
            anim.SetBool("isJumping", true);
        if (isJumping == false)
            anim.SetBool("isJumping", false);
        if (movingLeft == true || movingRight == true &&( x != 0 || y != 0))
        {
            if (movingLeft == false && movingRight == false)
            {
                anim.SetBool("isSliding", true);
                sliding = true;
            }
            if (movingRight == true || movingLeft == true)
            {
                anim.SetBool("isSliding", false);
                sliding = false;
            }
        }
        if (rigidYVel != 0)
        {
            anim.SetBool("isSliding", false);
            sliding = false;
        }
        if (rigidXVel < 2f && rigidXVel > -2f)
        {
            sliding = false;
            anim.SetBool("isSliding", false);
        }
    }
    public void Step()
    {
        audioSource.PlayOneShot(audioClipArray[0],0.7f);
    }
    public void Slide()
    {
        audioSource.PlayOneShot(audioClipArray[1], 0.7f);
    }
}
