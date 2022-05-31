using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    public float score;
    public TextMeshProUGUI ScoreTxt;

    private Rigidbody2D RB;
    public Transform playerFeet;
    public LayerMask groundLayer;
    
    private float playerFeetRadius = 0.4f;
    public bool isAlive = true;
    public bool canDoubleJump = true;

    public bool isOnGround = true;
    public bool isUndersidePlatform = false;

    private void Awake() 
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

       void Update()
    {
       
        isOnGround = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            Debug.Log("jump");
            RB.gravityScale = 30f;
            RB.velocity = new Vector2(0, JumpForce);
            canDoubleJump = true;
        }
        
        //double jump feature
        if (Input.GetButtonDown("Jump") && canDoubleJump && !isOnGround)
        {
            Debug.Log("double jump");
            canDoubleJump = false;
            RB.gravityScale = 30f;
            RB.velocity = new Vector2(0, JumpForce);
        }
        
        if (Input.GetButtonDown("Jump") && isUndersidePlatform) //on underside of platform and jumps
        {
            Debug.Log("under jump");
            RB.gravityScale = 30f;
            RB.velocity = new Vector2(0, JumpForce);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platformUnderside"))
        {
            isUndersidePlatform = true;   
            RB.gravityScale = -30f;
        }
        
        if(collision.gameObject.CompareTag("ground"))
        {
            RB.gravityScale = 30f;
            isUndersidePlatform = false;
            
            if(isOnGround == false)
            {
                isOnGround = true;
            }

            if(isAlive)
            {
                score += Time.deltaTime * 50;
            
                ScoreTxt.text = "SCORE: " + score.ToString(("0.00")) ;
            }
        }

        // if(collision.gameObject.CompareTag("spike"))
        // {
        //     isAlive = false;
        //     Time.timeScale = 0;
        //     
        // }

        if(collision.gameObject.CompareTag("enemy"))
        {
            isAlive = false;
            Time.timeScale = 0;
            
        }
    }
}
