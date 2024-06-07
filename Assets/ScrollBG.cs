using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float scrollSpeedX;
    public float scrollSpeedY;
    private Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 offset = new Vector2(Time.time * scrollSpeedX, Time.time * scrollSpeedY);
        renderer.material.mainTextureOffset = offset;
    }
}
