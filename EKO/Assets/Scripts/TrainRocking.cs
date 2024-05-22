using UnityEngine;

public class TrainHeartbeatMovement : MonoBehaviour
{
    // Settings for the movement
    public float downDistance = 0.2f; // Distance to move down
    public float upDistance = 0.2f; // Distance to move up
    public float quickDuration = 0.1f; // Duration of quick down and up movement
    public float stayUpDuration = 1.0f; // Duration to stay up

    // Internal state
    private Vector3 startPosition;
    private float timer = 0f;
    private int state = 0; // 0 = down, 1 = up, 2 = down, 3 = up, 4 = stay up

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        switch (state)
        {
            case 0:
            case 2:
                if (timer >= quickDuration)
                {
                    // Move down to up
                    state++;
                    timer = 0f;
                }
                break;
            case 1:
            case 3:
                if (timer >= quickDuration)
                {
                    // Move up to down or up to stay up
                    state++;
                    timer = 0f;
                }
                break;
            case 4:
                if (timer >= stayUpDuration)
                {
                    // Stay up to down
                    state = 0;
                    timer = 0f;
                }
                break;
        }

        // Calculate the new position based on state
        Vector3 newPosition = startPosition;
        if (state == 0 || state == 2)
        {
            newPosition -= new Vector3(0, downDistance, 0);
        }
        else if (state == 1 || state == 3)
        {
            newPosition += new Vector3(0, upDistance, 0);
        }

        // Interpolate between the current and new position
        float duration = (state == 4) ? stayUpDuration : quickDuration;
        transform.position = Vector3.Lerp(transform.position, newPosition, timer / duration);
    }
}
