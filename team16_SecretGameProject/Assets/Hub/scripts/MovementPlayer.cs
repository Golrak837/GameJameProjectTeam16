using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    private bool m_FarcingRight = true;
    private bool m_FarcingTop = true ;
    public AudioSource audioSource;
    public Rigidbody2D rb2d;
    [SerializeField] private Vector2 velocity = Vector2.zero;
    public Animator animator;

    void Start(){
        rb2d = GetComponent<Rigidbody2D> ();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    
    private void Move()
    {   
        direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        var deplacement = direction * speed * Time.deltaTime;
        if ((deplacement.x < 0 && m_FarcingRight) || (deplacement.x > 0 && !m_FarcingRight))
        {
            if(!audioSource.isPlaying){
                audioSource.Play();
            }
            Flipx();
            animator.SetBool("isMoving",true);
        }

        if ((deplacement.y < 0 && m_FarcingTop) || (deplacement.x > 0 && !m_FarcingTop))
            {
                if(!audioSource.isPlaying){
                    audioSource.Play();
                }

                Flipy();
                animator.SetBool("isMoving",true);
            }

        else if (deplacement.x==0 && deplacement.y ==0){
                audioSource.Stop();
            animator.SetBool("isMoving",false);

        }
        
        transform.position += deplacement;
    }
    
    private void Flipx()
    {
        m_FarcingRight = !m_FarcingRight;
        transform.Rotate(0f,180f,0f);
    }

        private void Flipy()
    {
        m_FarcingTop = !m_FarcingTop;
        transform.Rotate(0f,0f,180f);
    }
}
