using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAnim : MonoBehaviour
{
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(count > 1.0f)
        {
            Destroy(gameObject);
        }
    }
}
