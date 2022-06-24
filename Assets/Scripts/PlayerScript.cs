using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    //gem count increases when gem is in contact with tag "Player",
    //not when player is in contact with tag "gem"

    public TextMeshProUGUI ScoreTxt;
    public float JumpForce;
    
    private ScoreManager scoreManager;
    private PowerUpManager powerUpManager;
    
//player body fields
    private Rigidbody2D RB;
    public Transform playerFeet;
    public LayerMask groundLayer;

//jumping fields
    private float playerFeetRadius = 0.4f;
    private float gravityForce = 5f;
    public bool isAlive = true;
    public bool canDoubleJump = true;

//underside fields
    public bool isOnGround = true;
    public bool isUndersidePlatform = false;

//time control fields
    private float timePassed;
    //public static float gameSpeed = 15f;

//animation fields
    public Animator animator;
    
    private void Awake() 
    {
        RB = GetComponent<Rigidbody2D>();
        RB.gravityScale = gravityForce;
        
        
        scoreManager = FindObjectOfType<ScoreManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    void Update()
    {
        // timePassed += Time.deltaTime;
        // if (timePassed > 5f && PlayerScript.gameSpeed < 30f)
        // {
        //     Debug.Log(PlayerScript.gameSpeed);
        //     PlayerScript.gameSpeed += 5f;
        //     timePassed = 0;
        // } 
        

       
        isOnGround = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);
        
        //first jump
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            //Debug.Log("jump");
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);
            canDoubleJump = true;

            animator.SetBool("IsJumping", true);
           
        }
        
        //double jump feature
        //second jump
        if (Input.GetButtonDown("Jump") && canDoubleJump && !isOnGround)
        {
            //Debug.Log("double jump");
            canDoubleJump = false;
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);

            animator.SetBool("IsJumping", true);
        }

        //underside
        if (Input.GetButtonDown("Jump") && isUndersidePlatform) //on underside of platform and jumps
        {
            //Debug.Log("under jump");
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);
            isUndersidePlatform = false;
            canDoubleJump = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            isUndersidePlatform = true;
            isOnGround = false;
            RB.gravityScale = -gravityForce;
            animator.SetBool("IsUnder", true);
            
        }  
        else if (collision.gameObject.CompareTag("ground"))
        {
            RB.gravityScale = gravityForce;
            isUndersidePlatform = false;
            isOnGround = true;
            animator.SetBool("IsJumping", false);

        } else if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("spike"))
        {
            Debug.Log("bubble status: " + powerUpManager.getBubbleStatus());
            
            if (powerUpManager.getHungerEffectStatus())
            {
                Debug.Log("on hunger effect, eat enemy");
                Destroy(collision.gameObject);
            }
            else if (powerUpManager.getBubbleStatus())
            {
                Debug.Log("removes bubble");
                powerUpManager.setBubbleActive(false);
                Destroy(collision.collider);
                Destroy(collision.rigidbody);
            }
            else //when you dont have either effects you die
            {
                //isAlive = false;
                //this is to animate death
                //animator.SetBool("IsDead", true);
                //FindObjectOfType<GameManager>().GameOverScene(scoreManager.getScore());
                
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            RB.gravityScale = gravityForce;
            animator.SetBool("IsUnder", false);
        } 
    }
}