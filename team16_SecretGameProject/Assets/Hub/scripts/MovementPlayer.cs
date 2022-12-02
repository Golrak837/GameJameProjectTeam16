using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private float speed;
    private bool m_FarcingRight = true;
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
            Flip();
        }
        
        transform.position += deplacement;
    }
    
    private void Flip()
    {
        m_FarcingRight = !m_FarcingRight;
        transform.Rotate(0f,180f,0f);
    }
}
