using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]  public Rigidbody2D rb;
    [SerializeField]  Animator animator;
    [SerializeField] public float JumpForce = 1f;
    private bool facingright = true;
    [SerializeField]  private GameObject Cam;


    [SerializeField]  private float runSpeed = 25f;

    [SerializeField]  private Transform groundcheck;

    private float horizontalMove = 0f;

    [SerializeField] private LayerMask groundLayer;//the layer on which we can be grounded
    /*
    private float groundedHeight = 0.5f; // the height above ground to determine if the player is grounded
    private float checkRate = 1.0f; // how often in seconds we check to see if we are grounded
    private bool grounded = false;// is grounded or not
    
    private float heightOffset = 0.25f; // we dont want to cast from the players feet (may cast underground sometimes), so we offset it a bit
    */
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Cam.transform.parent = this.gameObject.transform;
      //  InvokeRepeating("GroundCheck", 0, checkRate);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (((Input.GetButtonDown("Jump")) || Input.GetKeyDown("up")) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            
            // Debug.Log("jumped");
            gameObject.transform.SetParent(null);
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
    }
    private void FixedUpdate()
    {
        GroundCheck();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime;

        if (horizontalMove > 0 && !facingright)
        {
            Flip();
        }
        if (horizontalMove < 0 && facingright)
        {
            Flip();
        }
        
    }
    

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingright = !facingright;
    }
   public void OnLanding()
    {
        //Debug.Log("islanded");
            animator.SetBool("isJumping", false);
    }

   

  void GroundCheck()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(groundcheck.transform.position, -Vector2.up,  0.1f, groundLayer);
       // Debug.DrawRay(groundcheck.transform.position, -Vector2.up * 0.1f, Color.green, 0.1f);
        if ((hit && rb.velocity.y < 0f))
        {
            OnLanding();
            Debug.Log("is grounded");
            if (hit.collider.gameObject.GetComponent<MovingPlatform>())
            {
                gameObject.transform.parent = hit.collider.gameObject.transform;
            } else
            {
                gameObject.transform.SetParent(null);
            }
        }
    }

}
