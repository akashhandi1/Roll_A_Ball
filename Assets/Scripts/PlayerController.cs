using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using TMPro;

public class PlayerController : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;

    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;
    private Vector3 moveInput;
    public Joystick joystick;

    // holds movement x and y
    private float movementX;
    private float movementY;
    
    // Start is called before first frame update
    void Start()
    {
        count = 0; //set to 0
        SetCountText();
        rb = GetComponent<Rigidbody>();  //sets rigidbody component to rb
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        // create a vector 2 variable and store the x and y movement values in it
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }



    // Update is called once per frame 
    private void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    public void Move(Vector3 direction)
    {
        rb.AddForce(direction * speed);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            
            //add 1 to score
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "count:" + count.ToString();
        if(count >= 12)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
