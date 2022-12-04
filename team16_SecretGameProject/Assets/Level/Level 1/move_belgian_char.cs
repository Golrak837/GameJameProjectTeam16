using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
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
    [SerializeField] private int offset = 1;
    public AudioSource audioSource_move;
    public AudioSource audioSource_break;


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

        if (!(Mathf.Abs(rb2d.velocity.x) > 0.1f)) {
            audioSource_move.Stop();
        }

        if((rb2d.velocity.x > 0.1f || rb2d.velocity.x < -0.1f) && !audioSource_move.isPlaying && !isJumping && isGrounded){
            audioSource_move.Play();
        }   
    }

    void FixedUpdate()
    {      

        _horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapArea(GroundCheckLeftB.position,GroundCheckRightB.position);

        if(!isGrounded){
            audioSource_move.Stop();
        }
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
            audioSource_move.Stop();
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
            if (col.gameObject.name.Equals("Platform"))
            {
                this.transform.parent = col.transform;
            }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BreakBlock"))
        {
            Debug.Log(true);
            if(Input.GetKey(KeyCode.Q)) Destroy(collision.gameObject);
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name.Equals ("Platform"))
            this.transform.parent = null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {
            rb2d.velocity = new Vector2(0, 0);
            transform.position = GameObject.Find("Spawn").transform.position + new Vector3(offset, 0, 0);
        }

        if (col.gameObject.CompareTag("Key"))
        {
            GameObject.Find("Keysound").GetComponent<AudioSource>().Play();
            haveKey = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.name.Equals("Element")){
            GameObject.Find("Element").GetComponent<AudioSource>().Play();
            StartCoroutine(waitcor());
            
        }
    }

    IEnumerator waitDes(Collider2D col)
    {
        yield return new WaitForSeconds(1);
        Destroy(col.gameObject);
    }

    IEnumerator waitcor()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Hub");
    }

    public bool GetHaveKey()
    {
        return haveKey;
    }

    public void SetHaveKey()
    {
        haveKey = !haveKey;
    }

        
    //Character and broken block hit detection
    private void OnCollisionStay2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("BreakBlock"))
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    audioSource_break.Play();
                    Vector3 hitPos = Vector3.zero;

                    foreach (ContactPoint2D point in collision.contacts)
                    {
                        hitPos = point.point;
                    }

                    BoundsInt.PositionEnumerator position = collision.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
                    var allPosition = new List<Vector3>();

                    int minPositionNum = 0;

                    foreach (var variable in position)
                    {
                        if (collision.gameObject.GetComponent<Tilemap>().GetTile(variable) != null)
                        {
                            allPosition.Add(variable);
                        }
                    }

                    for (int i = 1; i < allPosition.Count; i++)
                    {
                        if ((hitPos - allPosition[i]).magnitude <
                            (hitPos - allPosition[minPositionNum]).magnitude)
                        {
                            minPositionNum = i;
                        }
                    }

                    Vector3Int finalPosition = Vector3Int.RoundToInt(allPosition[minPositionNum]);


                    TileBase tiletmp = collision.gameObject.GetComponent<Tilemap>().GetTile(finalPosition);

                    if (tiletmp != null)
                    {
                        Tilemap map = collision.gameObject.GetComponent<Tilemap>();
                        TilemapCollider2D tileCol = collision.gameObject.GetComponent<TilemapCollider2D>();

                        map.SetTile(finalPosition, null);
                        tileCol.enabled = false;
                        tileCol.enabled = true;
                    }
                }
            }
        }
}
