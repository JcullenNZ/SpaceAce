using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float parallaxEffectMultiplierX = 0.5f; // Multiplier for horizontal movement
    public float parallaxEffectMultiplierY = 0.5f; // Multiplier for vertical movement

    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void Update()
    {
        Vector3 deltaMovement = player.position - lastPlayerPosition;

        // Adjust the background's position based on the player's movement
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplierX, deltaMovement.y * parallaxEffectMultiplierY, 0);

        lastPlayerPosition = player.position;
    }

    
}