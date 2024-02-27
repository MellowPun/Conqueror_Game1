using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArmyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float moveSpeed = 2f;
    private int FlatFee = 50;


    private Transform target;
    private int pathIndex;
    private void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }
    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position)<=0.1f)
        {
            pathIndex++;

            if(pathIndex == LevelManager.instance.path.Length)
            {
                Destroy(gameObject);
                LevelManager.instance.levelHP --;
                LevelManager.instance.IncreaseIncome(FlatFee);
                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex];

            }

        }
        if(LevelManager.instance.levelHP <= 0) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

}
