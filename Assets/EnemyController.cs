using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2;        // Speed of enemy movement
    public float changeDirectionTime = 2; // Time interval to change direction

    private Vector2 moveDirection;      // Current direction of movement
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirectionRoutine());
    }

    void Update()
    {
        rb.velocity = moveDirection * moveSpeed;
        Debug.Log("Velocity: " + rb.velocity); // Debug log to check velocity
    }


    // Coroutine to change direction at intervals
    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeDirectionTime);
            ChangeDirection();
        }
    }

    // Sets a new random direction for the enemy
    private void ChangeDirection()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        moveDirection = new Vector2(randomX, randomY).normalized;
        Debug.Log("New Direction: " + moveDirection); // Debug log to check direction
    }

}
