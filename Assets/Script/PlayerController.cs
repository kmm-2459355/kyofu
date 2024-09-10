using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class PlayerContoller : MonoBehaviour
{

    Rigidbody2D rd2D;
    float jumpForce = 1000f;
    bool isGround = false;
    public float damage;

    void Start()
    {
        Application.targetFrameRate = 60;
        this.rd2D = GetComponent<Rigidbody2D>();
  
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((x) =>
        {
            Jump();
        });
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rd2D.velocity.y == 0)
        {
            this.rd2D.AddForce(transform.up * this.jumpForce);
        }
        //âEñÓàÛÇâüÇµÇΩÇ∆Ç´
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(2);
        }
        //ç∂ñÓàÛÇâüÇµÇΩÇ∆Ç´
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(-2);
        }
    }
    public void LButtonDown()
    {
        MovePlayer(-2);
    }
    public void RButtonDown()
    {
        MovePlayer(2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("paper"))
        {
            damage = 0.05f;
        }
        else if (collision.gameObject.CompareTag("cabbage"))
        {
            damage = 0.1f;
        }
        else if(collision.gameObject.CompareTag("dog"))
        {
            damage = 0.2f;
        }
        GameObject director = GameObject.Find("GameDirector");
        director.GetComponent<GameDirector>().DecreaseHp(damage);
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
    void MovePlayer(float amout)
    {
        Vector3 newPosition = transform.position + new Vector3(amout, 0, 0);

        newPosition.x = Mathf.Clamp(newPosition.x, -8f, 8f);

        transform.position = newPosition;
    }
    public void Jump()
    {
        if (isGround)
        {
            isGround = false;
            this.rd2D.AddForce(transform.up * this.jumpForce);
        }
    }
}
