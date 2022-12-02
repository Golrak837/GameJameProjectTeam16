using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_belgian_char : MonoBehaviour
{
public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb2d;
    [SerializeField] private Vector2 velocity = Vector2.zero;
    public bool isJumping;
    public bool isGrounded;
    float _horizontalMovement;
    public Transform GroundCheckLeftB;
    public Transform GroundCheckRightB;
    public SpriteRenderer SpriteRendererB;
    public Animator animatorB;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
            {
                isJumping=true;
            }       
    }

    void FixedUpdate()
    {      

        _horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapArea(GroundCheckLeftB.position,GroundCheckRightB.position);


        Movepl(_horizontalMovement);
        Flip(rb2d.velocity.x);
        
        animatorB.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
    }

    void Movepl(float _horizontalMovement)
    {
        // Debug.Log("moveplayer");
        Vector2 targetVelocity = new Vector2(_horizontalMovement,rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity,targetVelocity, ref velocity, .05f);        

        if(isJumping && isGrounded){
            rb2d.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity){

        if (_velocity > 0.1f){ // entre -1 et 1
            SpriteRendererB.flipX=false;
            }
        else if(_velocity < -0.1f){
            SpriteRendererB.flipX=true;
            }
        }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals ("Platform"))
        {
            if (col.gameObject.name.Equals("Platform"))
            {
                this.transform.parent = col.transform;
            }
          
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals ("Platform"))
            this.transform.parent = null;
    }

}
