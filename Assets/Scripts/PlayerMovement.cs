using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Input settings")]
    public KeyCode ForwardInput = KeyCode.W;  
    public KeyCode BackwardInput = KeyCode.S;
    public KeyCode LeftInput = KeyCode.A;
    public KeyCode RightInput = KeyCode.D;

    public float movementSpeed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void FixedUpdate()
    {
        
        if (Input.GetKey(ForwardInput))
        {
            transform.position += Vector3.forward* movementSpeed;
        }else if (Input.GetKey(BackwardInput)){
            transform.position += Vector3.back * movementSpeed;
        }
        if (Input.GetKey(LeftInput)){
            transform.position += Vector3.left * movementSpeed;

        }else if (Input.GetKey(RightInput))
        {
            transform.position += Vector3.right * movementSpeed;
        }
    }
}
