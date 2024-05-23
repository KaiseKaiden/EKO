using UnityEngine;

public class BackdropScroller : MonoBehaviour
{
    public GameObject backdropPrefab; // The prefab to be used as the backdrop
    public float scrollSpeed = 2.0f; // The speed at which the backdrop scrolls
    public int numBackdrops = 3; // Number of backdrop instances to create for the looping effect
    private GameObject[] backdrops;
    private float backdropWidth;

    void Start()
    {
        // Instantiate backdrop instances
        backdrops = new GameObject[numBackdrops];
        for (int i = 0; i < numBackdrops; i++)
        {
            backdrops[i] = Instantiate(backdropPrefab, transform);
            backdrops[i].transform.position = new Vector3(i * backdropPrefab.transform.localScale.x, 0, 0);
        }

        // Calculate backdrop width based on the prefab's scale
        backdropWidth = backdropPrefab.transform.localScale.x;
    }

    void Update()
    {
        // Move each backdrop instance to the left
        for (int i = 0; i < numBackdrops; i++)
        {
            backdrops[i].transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);

            // If a backdrop moves completely off screen to the left, move it to the right end
            if (backdrops[i].transform.position.x <= -backdropWidth)
            {
                float rightmostPosition = FindRightmostBackdropPosition();
                backdrops[i].transform.position = new Vector3(rightmostPosition + backdropWidth, 0, 0);
            }
        }
    }

    private float FindRightmostBackdropPosition()
    {
        float rightmostPosition = backdrops[0].transform.position.x;
        for (int i = 1; i < numBackdrops; i++)
        {
            if (backdrops[i].transform.position.x > rightmostPosition)
            {
                rightmostPosition = backdrops[i].transform.position.x;
            }
        }
        return rightmostPosition;
    }
}
