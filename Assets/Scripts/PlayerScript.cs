using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    public GameManager GameManager;

    public float JumpForce;
    public float score;
    public TextMeshProUGUI ScoreTxt;

    private Rigidbody2D RB;
    public Transform playerFeet;
    public LayerMask groundLayer;

    
    private float playerFeetRadius = 0.4f;
    private float gravityForce = 5f;
    public bool isAlive = true;
    public bool canDoubleJump = true;

    public bool isOnGround = true;
    public bool isUndersidePlatform = false;

    private void Awake() 
    {
        RB = GetComponent<Rigidbody2D>();
        RB.gravityScale = gravityForce;
        score = 0;
    }

    void Update()
    {
       
        isOnGround = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            Debug.Log("jump");
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);
            canDoubleJump = true;
        }
        
        //double jump feature
        if (Input.GetButtonDown("Jump") && canDoubleJump && !isOnGround)
        {
            Debug.Log("double jump");
            canDoubleJump = false;
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);
        }
        
        if (Input.GetButtonDown("Jump") && isUndersidePlatform) //on underside of platform and jumps
        {
            Debug.Log("under jump");
            RB.gravityScale = gravityForce;
            RB.velocity = new Vector2(0, JumpForce);
            isUndersidePlatform = false;
            canDoubleJump = true;
        }
        
        if (isAlive)
        {
            score += Time.deltaTime * 50;
            
            ScoreTxt.text = "SCORE: " + score.ToString(("0")) ;
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.CompareTag("platformUndersideEnd"));
        
        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            isUndersidePlatform = true;
            isOnGround = false;
            RB.gravityScale = -gravityForce;
            
        }  else if (collision.gameObject.CompareTag("ground"))
        {
            RB.gravityScale = gravityForce;
            isUndersidePlatform = false;
            isOnGround = true;

        } else if (collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            //timescale is the cause of the bug where nothing is moving after restrting
            //Time.timeScale = 0;
            //this is to activate gameoverscreen without referencing

            FindObjectOfType<GameManager>().GameOverScene(score);
            //Time.timeScale = 0;
        }
        else if (collision.gameObject.CompareTag("gem"))
        {
            Debug.Log("touched gem");
        } 
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            RB.gravityScale = gravityForce;
        } 
    }
}