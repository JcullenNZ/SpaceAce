using UnityEngine;

public class RepeatingBG : MonoBehaviour
{
    public Transform playerTransform;
    public float parallaxEffectMultiplier;
    Renderer renderer;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        lastPlayerPosition = playerTransform.position;
    }

    void Update()
    {
        Vector3 deltaMovement = playerTransform.position - lastPlayerPosition;
        Vector2 offset = new Vector2(deltaMovement.x * parallaxEffectMultiplier, deltaMovement.y * parallaxEffectMultiplier);
        renderer.material.mainTextureOffset += offset;
        lastPlayerPosition = playerTransform.position;
    }
}