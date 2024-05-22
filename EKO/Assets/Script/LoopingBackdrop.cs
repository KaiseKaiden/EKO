using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public float speed = 5f; // Speed at which the background moves
    public float resetPositionX; // The x position where the background resets to the right
    public float startPositionX; // The x position where the background starts from the right

    void Update()
    {
        // Move the background to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Check if the background has moved past the reset position
        if (transform.position.x <= resetPositionX)
        {
            // Reposition the background to the start position
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = startPositionX;
        transform.position = newPosition;
    }
}
