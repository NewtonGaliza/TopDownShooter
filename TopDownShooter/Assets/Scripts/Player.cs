using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private float initialSpeed;
    [SerializeField] private float runSpeed;


    private Vector2 _direction;
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }





    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialSpeed = speed;        
    }


    // Update is called once per frame
    void Update()
    {
        OnInput();

        OnRun();
    }



    private void FixedUpdate()
    {
        OnMove();        
    }



    void OnInput()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    void OnMove()
    {
        rigidBody.MovePosition(rigidBody.position + direction * speed * Time.fixedDeltaTime);
    }

    void OnRun()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
        }
    }





}