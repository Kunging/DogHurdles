using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject sprite;
    Rigidbody2D rb;
    bool isDead;
    public bool IsDead
    {
        get
        {
            return isDead;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1")&& transform.position.y < maxHeight)
        {
            if(!isDead)
            {
                rb.velocity = new Vector2(0.0f, jumpVelocity);
            }
        }
        // 강아지 회전
        float angle;
        if(isDead)
        {
            angle = -90f;
        }
        else
        {
            angle = Mathf.Atan2(rb.velocity.y, 10) * Mathf.Rad2Deg;
        }
        angle = Mathf.Atan2(rb.velocity.y, 10)*Mathf.Rad2Deg;

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag != "ground")
        {
            Debug.Log("다이");
            isDead = true;
        }
    }
    public void SetKinematic(bool value)
    {
        rb.isKinematic = value;
    }
}
