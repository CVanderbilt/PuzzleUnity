using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float reach = 2f;
    public LayerMask ignore;
    // Start is called before the first frame update
    public Transform head;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
 
    public float minimumX = -360F;
    public float maximumX = 360F;
 
    public float minimumY = -60F;
    public float maximumY = 60F;
 
    float rotationY = 0F;
   
    Vector3 bodyDir;
    //Player player;
 
    void Start()
    {
    	Cursor.lockState = CursorLockMode.Locked;
        //player = GetComponent<Player>();
    }
   
 
    void Update ()
    {
    	//if (!player.IsAlive())
         //   return ;

        float rotationX = head.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

        head.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        bodyDir = transform.localEulerAngles;
        bodyDir.y = head.localEulerAngles.y;
        transform.localEulerAngles = bodyDir;
        Debug.DrawRay(head.position, head.forward, Color.yellow);


    }

}
