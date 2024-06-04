using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private Vector2 backgroundSize;
    private Vector3 startPosition;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundSize = spriteRenderer.bounds.size;
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 diff = Camera.main.transform.position - startPosition;

        if (Mathf.Abs(diff.x) >= backgroundSize.x)
        {
            float offsetX = diff.x > 0 ? backgroundSize.x : -backgroundSize.x;
            startPosition.x += offsetX;
            transform.position = new Vector3(startPosition.x, transform.position.y, transform.position.z);
        }

        if (Mathf.Abs(diff.y) >= backgroundSize.y)
        {
            float offsetY = diff.y > 0 ? backgroundSize.y : -backgroundSize.y;
            startPosition.y += offsetY;
            transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
        }
    }
}