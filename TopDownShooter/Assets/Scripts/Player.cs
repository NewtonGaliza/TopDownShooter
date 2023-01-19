using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rigidBody;
    private float initialSpeed;
    [SerializeField] private float runSpeed;

    // [SerializeField] private Transform weapon;
    private Camera mainCamera;


    private Vector2 _direction;
    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }


    private bool _isShooting;
    public bool isShooting
    {
        get { return _isShooting; }
        set {_isShooting = value; }
    }




    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        initialSpeed = speed;  

        mainCamera  = Camera.main;      
    }


    // Update is called once per frame
    void Update()
    {
        OnInput();

        OnRun();

        LookAtMouse();

        OnShooting();
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

    void LookAtMouse()
    {
        Vector3 mouse = Input.mousePosition;
        //Debug.Log(Input.mousePosition);
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,angle);
    }


    void OnShooting()
    {
        //pressionar botao esquerdo do mouse
        if(Input.GetMouseButtonDown(0))
        {
            _isShooting = true;
        }

        if(Input.GetMouseButtonUp(0))
        {
            _isShooting = false;
        }
    }
    
    
}