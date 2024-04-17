using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleSpawn : MonoBehaviour
{
    public GameObject cube;
    public Transform spawnPosition;
    float speedPenalty;
    PlayerControl playerControl;

    float timeDif;
    void Start()
    {
        
        playerControl = FindAnyObjectByType<PlayerControl>();
        playerControl.OnPressSpace += speed;
        playerControl.OnDeath += StopSpawn;

        StartCoroutine(SpawnObstacle());

    }
    
    
  
    IEnumerator SpawnObstacle()
    {
        
        while (true)
        {

            
            int randomYAxis = Random.Range(15, 21);
            timeDif = Random.Range(1.25f,1.50f);
           
            speedPenalty = Mathf.Clamp(speedPenalty, .5f, 1.50f);
            Instantiate(cube, new Vector3(spawnPosition.position.x, randomYAxis, -1), Quaternion.identity);
            yield return new WaitForSeconds(timeDif / speedPenalty);
            
          
        }
        

    }
    void speed()
    {

        speedPenalty += 0.01f;
    }
    void StopSpawn()
    {

        StopAllCoroutines();
        StartCoroutine(OnDeathRespawnTime());
    }
    IEnumerator OnDeathRespawnTime()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(0);


    }

}
