using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testCharaScript : MonoBehaviour
{
    [SerializeField] private float MOVE_SPEED = 0.0f;
    [SerializeField] private float JUMP = 0.0f;

    private Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        rigid2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float LR = Input.GetAxisRaw("Horizontal");

        if(LR != 0.0f)
        {
            gameObject.transform.Translate(new Vector3(LR * Time.deltaTime * MOVE_SPEED, 0.0f, 0.0f));
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            rigid2D.AddForce(new Vector2(0.0f, JUMP));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("BreakBlock"))
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Vector3 hitPos = Vector3.zero;

                foreach (ContactPoint2D point in collision.contacts)
                {
                    hitPos = point.point;
                }

                BoundsInt.PositionEnumerator position = collision.gameObject.GetComponent<Tilemap>().cellBounds.allPositionsWithin;
                var allPosition = new List<Vector3>();

                //一番近い場所を保存したいので変数を宣言
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
                    //それぞれのあたった場所からの大きさを取得、最小を更新したらminPositionNumを更新する
                    if ((hitPos - allPosition[i]).magnitude <
                        (hitPos - allPosition[minPositionNum]).magnitude)
                    {
                        minPositionNum = i;
                    }
                }

                //最終的な位置を一旦格納した。RoundToIntは四捨五入とのことです
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Death"))
        {
            Debug.Log(true);
        }
    }
}
