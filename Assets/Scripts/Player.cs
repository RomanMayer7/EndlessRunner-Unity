using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 8;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public float distanceTraveled;
    [SerializeField] UIController UIController;
    public int collectedCoins;
    [SerializeField]  bool airJump;
    [SerializeField] bool shieldEnabled;
    [SerializeField] GameObject shield;
    [SerializeField] SFXManager sfxManager;
    bool playerIsFalling;

    // Start is called before the first frame update
    void Start()
    {
        lastYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        CheckIfPlayerIsFalling();

    }

    void CheckForJump()
    {
        if (jump == true)
        {
            jump = false;
            sfxManager.PlaySFX("Jump");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void FixedUpdate()
    {
        CheckForGrounded();
        CheckForJump();
    }

    void CheckForInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || airJump==true))
        {
            if(airJump==true && isGrounded==false)
            {
                airJump = false;
            }
            jump = true;
            anim.SetTrigger("Jump");
            
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);
        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
                anim.SetBool("IsGrounded",true);
                if (playerIsFalling == true)
                {
                    sfxManager.PlaySFX("Land");
                }
                
            }
            else
            {
                isGrounded = false;
                anim.SetBool("IsGrounded", false);
            }
            //Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }

    void CheckIfPlayerIsFalling()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;
        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }

        lastYPos = transform.position.y;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            if (!shieldEnabled)
            {
                Debug.Log("Collision with Obstacle");
                sfxManager.PlaySFX("GameOverHit");
                UIController.ShowGameOverScreen();
            }
            else
            {
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
                shield.SetActive(false);
                shieldEnabled = false;
            }
        }

        if (collision.transform.CompareTag("DeathBox"))
        {
            sfxManager.PlaySFX("GameOverHit");
            UIController.ShowGameOverScreen();
        }

        //Debug.Log("Collision");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("powerupDoubleJump");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ScarabShield"))
        {
            shieldEnabled = true;
            shield.SetActive(true);
            sfxManager.PlaySFX("powerupShield");
            Destroy(collision.gameObject);
        }
    }
}
