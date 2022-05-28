using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    public float speed = 50f;
    public float score;
    public TextMeshProUGUI ScoreTxt;

    private Rigidbody2D RB;
    public Transform playerFeet;
    public LayerMask groundLayer;
    
    public float playerFeetRadius = 10f;
    public float direction = 0f;
    public bool isAlive = true;
    public int jumpCount = 0;
    public bool canDoubleJump = true;

    public bool isGrounded;

    
    
    private void Awake() 
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

       void Update()
    {
       //double jump feature
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("jump");
            RB.gravityScale = 30f;
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump") && canDoubleJump && !isGrounded)
        {
            Debug.Log("double jump");
            canDoubleJump = false;
            RB.gravityScale = 30f;
            RB.velocity = new Vector2(RB.velocity.x, JumpForce);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }

            if(isAlive)
            {
                score += Time.deltaTime * 50;
            
                ScoreTxt.text = "SCORE: " + score.ToString("0.00") ;
            }
        }

        if(collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            //Time.timeScale = 0;
            
        }
    }
}
