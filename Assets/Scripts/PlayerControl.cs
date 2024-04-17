using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public event Action OnPressSpace;
    public event Action OnDeath;
    public static PlayerControl inst;
   
    [SerializeField] float jumpForce;
    Rigidbody rb;
   
    [SerializeField] float gravityValue;
    Vector3 direction;
    public float speedPenalty;
    public int score;

    private void Start()
    {
        inst = this;
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.velocity = Vector3.up * jumpForce;
            speedPenalty += 0.01f;
            speedPenalty = Mathf.Clamp(speedPenalty, 0, 3);
            OnPressSpace?.Invoke();


        }
        if(transform.position.y > 18)
        {
            Die();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Score")
        {
            score++;

        }
        if (other.gameObject.tag == "Obstacle")
        {
            Die();



        }

    }

    void Die()
    {

        OnDeath?.Invoke();
        Destroy(gameObject);
    }
   





}
