using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_japanese_char : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb2d;
    [SerializeField] private Vector2 velocity = Vector2.zero;
    public bool isJumping;
    public bool isGrounded;
    float _horizontalMovement;
    public Transform GroundCheckLeftJ;
    public Transform GroundCheckRightJ;
    public SpriteRenderer SpriteRendererJ;
    public Animator animatorJ;
    private bool candoublejump = false;
    [SerializeField] private int offset = -30;

    public bool haveKey = false;

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

        isGrounded = Physics2D.OverlapArea(GroundCheckLeftJ.position,GroundCheckRightJ.position);


        Movepl(_horizontalMovement);
        Flip(rb2d.velocity.x);
        
        animatorJ.SetFloat("Speed",Mathf.Abs(rb2d.velocity.x));
    }

    void Movepl(float _horizontalMovement)
    {
        // Debug.Log("moveplayer");
        Vector2 targetVelocity = new Vector2(_horizontalMovement,rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity,targetVelocity, ref velocity, .05f);        

        if(isJumping && isGrounded){
            rb2d.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
            candoublejump = true;
        }

        else if(isJumping && candoublejump){
            candoublejump = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(new Vector2(0f,jumpForce));
        }
    }

    void Flip(float _velocity){

        if (_velocity > 0.1f){ // entre -1 et 1
            SpriteRendererJ.flipX=false;
            }
        else if(_velocity < -0.1f){
            SpriteRendererJ.flipX=true;
            }
        }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Platform"))
        {
            if (col.gameObject.name.Equals("Platform"))
            {
                this.transform.parent = col.transform;
            }

        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Platform"))
            this.transform.parent = null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {
            rb2d.velocity = new Vector2(0, 0);
            transform.position = GameObject.Find("Spawn").transform.position + new Vector3(offset, 0, 0);
        }

        if(col.gameObject.CompareTag("Key"))
        {
            haveKey = true;
            Destroy(col.gameObject);
        }
    }

    public bool GetHaveKey()
    {
        return haveKey;
    }
}
