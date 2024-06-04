using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerControls controls;
    public float speed = 5.0f;
    public float rotationSpeed = 200.0f;

    public Weapon weapon;
    void Awake()
    {
        controls = new PlayerControls();
        controls.InGame.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.InGame.Shoot.performed += ctx => Shoot();
        //controls.InGame.Pause.performed += ctx => Pause();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        controls.InGame.Enable();
    }

    void OnDisable()
    {
        controls.InGame.Disable();
    }   

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = controls.InGame.Move.ReadValue<Vector2>();
        Move(direction);
    }


    void Move(Vector2 direction)
    {
        transform.position += transform.up * direction.y * speed * Time.deltaTime;
        transform.Rotate(0,0,-direction.x * rotationSpeed * Time.deltaTime);
        
    }

    void Shoot()
    {
        try
        {
        weapon.Shoot();
        }
        catch (System.Exception e)
        {
            Debug.Log("Waiting In player: " + e.Message);}

    }
}
