using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    //gem count increases when gem is in contact with tag "Player",
    //not when player is in contact with tag "gem"
    
    public float JumpForce;

    //private FloatingScoreManager floatingScoreManager;
    private ScoreManager scoreManager;
    private PowerUpManager powerUpManager;
    private GameManager gameManager;
    
//player body fields
    private Rigidbody2D RB;
    public Transform playerFeet;
    public LayerMask groundLayer;

//jumping fields
    private float playerFeetRadius = 0.4f;
    private float gravityForce = 5f;
    public bool canDoubleJump = true;

//underside fields
    public bool isOnGround = true;
    public bool isUndersidePlatform = false;

//time control fields
    private float timePassed;
    //public static float gameSpeed = 15f;

//animation fields
    public Animator animator;

    //stores the floating +100 score object
    [SerializeField] private Transform floatingScore;

    //just set it to true to prevent dying
    private bool isAdminMode = true;
    
    private void Awake() 
    {
        RB = GetComponent<Rigidbody2D>();
        RB.gravityScale = gravityForce;


        //floatingScoreManager = FindObjectOfType<FloatingScoreManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        powerUpManager = FindObjectOfType<PowerUpManager>();
        gameManager = FindObjectOfType<GameManager>();
        
    }

    void Update()
    {
        //player is not supposed to jump when dead
        if (gameManager.gameHasEnded())
        {
            return;
        }
        
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

        } else if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("bubble status: " + powerUpManager.getBubbleStatus());
            
            if (powerUpManager.getHungerEffectStatus())
            {
                Debug.Log("on hunger effect, eat enemy");
                
                //5 is to compensate for the half length of the floating score prefab
                Vector3 spawnVector = new Vector3(this.transform.position.x + 5f, this.transform.position.y, 0);
                Instantiate(floatingScore, spawnVector, Quaternion.identity);
                
                //floatingScoreManager.spawnPoint(100, collision.transform.position);
                scoreManager.increaseMainScoreBy(100);
                Destroy(collision.gameObject);
            }
            else if (powerUpManager.getBubbleStatus())
            {
                Debug.Log("removes bubble");
                powerUpManager.setBubbleActive(false);
                //this is for bubble anim
                powerUpManager.setBubbleAlternate(2f);
                Destroy(collision.collider);
                Destroy(collision.rigidbody);
            }
            else //when you dont have either effects you die
            {
                if (isAdminMode)
                {
                    return;
                }
                //sets gameEnded boolean in GameManager to true
                gameManager.endGame();
                animator.SetBool("IsDead", true);
                FindObjectOfType<GameManager>().GameOverScene(scoreManager.getScore());
            }
        } else if (collision.gameObject.CompareTag("spike"))
        {
            if (powerUpManager.getBubbleStatus())
            {
                Debug.Log("removes bubble");
                powerUpManager.setBubbleActive(false);
                //this is for bubble anim
                powerUpManager.setBubbleAlternate(2f);
                Destroy(collision.collider);
                Destroy(collision.rigidbody);
            } else //dies even if you have hunger effect
            {
                if (isAdminMode)
                {
                    return;
                }
                
                //sets gameEnded boolean in GameManager to true
                gameManager.endGame();
                //this is to animate death
                animator.SetBool("IsDead", true);
                FindObjectOfType<GameManager>().GameOverScene(scoreManager.getScore());
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