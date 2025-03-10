using UnityEngine;

public class Simulation : MonoBehaviour
{
    public GameObject circlePrefab; // Reference to the Circle Prefab
    public float gravity = 9.8f; // Gravity value
    public Vector2 position = new Vector2(0, 0); // Initial position
    public Vector2 velocity = new Vector2(0, 0); // Initial velocity
    public Vector2 boundsSize = new Vector2(10, 10); // Screen bounds size
    private GameObject circleInstance;
    
    [Range(0.1f, 2f)] // Allow changing size from Inspector
    public float circleRadius = 0.5f; // Default radius

    public float damping = 0.9f; // Damping factor

    void Start()
    {
        DrawCircle();
    }

    void DrawCircle()
    {
        if (circlePrefab != null)
        {
            if (circleInstance != null)
            {
                Destroy(circleInstance);
            }

            // Instantiate new circle
            circleInstance = Instantiate(circlePrefab, position, Quaternion.identity);

            // Scale the circle to match `circleRadius`
            circleInstance.transform.localScale = Vector3.one * (circleRadius * 2); 

            Rigidbody2D rb = circleInstance.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = velocity; // Set velocity
                rb.gravityScale = gravity / 9.8f; // Adjust gravity scale
            }
        }
        else
        {
            Debug.LogError("Circle Prefab is not assigned in the Inspector!");
        }
    }

    void ResolveCollision()
    {
        float halfWidth = boundsSize.x / 2 - circleRadius;
        float halfHeight = boundsSize.y / 2 - circleRadius;

        if (Mathf.Abs(position.y) > halfHeight)
        {
            position.y = halfHeight * Mathf.Sign(position.y);
            velocity.y = -velocity.y * damping;
        }
        if (Mathf.Abs(position.x) > halfWidth)
        {
            position.x = halfWidth * Mathf.Sign(position.x);
            velocity.x = -velocity.x * damping;
        }
    }

    void Update()
    {
        velocity += Vector2.down * gravity * Time.deltaTime;
        position += velocity * Time.deltaTime;

        ResolveCollision();
        DrawCircle();
    }
}
