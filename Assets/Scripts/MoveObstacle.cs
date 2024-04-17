using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] float obstacleSpeed;
    PlayerControl playerControl;
    bool canMove = true;
    
    float speedPenalty;

    private void Start()
    {
        playerControl = FindAnyObjectByType<PlayerControl>();
        playerControl.OnDeath += StopMoving;
    }
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            speedPenalty = PlayerControl.inst.speedPenalty;
            speedPenalty = Mathf.Clamp(speedPenalty, 1, 2f);

            transform.Translate(Vector3.left * obstacleSpeed * speedPenalty * Time.deltaTime);
            if (transform.position.x < -15)
            {
                Destroy(gameObject);

            }
        }
        
    }
    void StopMoving()
    {
        canMove = false;
    }

   
    
}
