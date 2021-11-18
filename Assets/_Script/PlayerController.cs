using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public CharacterController controller;
	public float movSpeed = 10;
	public Transform groundChecker;
	public float checkRadius = 0.4f;
	public float gravity = -9.8f;

	public Vector3 velocity;
    bool isGrounded;
    public LayerMask groundMask;
    public Transform head;

    //Player player;
    // Start is called before the first frame update
    void Start()
    {
      //  player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(!player.IsAlive())
          //  return ;
    	isGrounded = CheckGround();
    	if(!isGrounded)
    	{
    		velocity.y += gravity * Time.deltaTime;
    	}
    	else if (velocity.y < 0)
    		velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			velocity.y = 5;
		}
        
        Vector3 moveVec = head.right * x + head.forward * y;
        moveVec.y = 0;

        controller.Move(moveVec * Time.deltaTime * movSpeed);
        controller.Move(velocity * Time.deltaTime);
    }

    private bool CheckGround()
    {
    	return Physics.CheckSphere(groundChecker.position, checkRadius, groundMask);
    }
}
