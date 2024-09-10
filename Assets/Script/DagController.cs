using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DagController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float jumpForce = 5f;
    private Rigidbody2D rb2D;
    private bool hasJumped = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // x軸方向に移動
        transform.Translate(moveSpeed, 0, 0);

        int px = Random.Range(-7, 7);

        // pxの位置でジャンプ
        if (Mathf.Abs(transform.position.x - px) < 0.3f && !hasJumped)
        {
            Jump();
            hasJumped = true;
        }

        // 画面外に出たらオブジェクトを削除
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }

    void Jump()
    {
        if (rb2D != null)
        {
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}