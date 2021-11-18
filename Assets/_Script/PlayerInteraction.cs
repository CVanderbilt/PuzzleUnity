using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public float reach = 10;
	public Camera vision; //player visual
	//public Interactable[] _grabbedObjects;
	//public int handSize = 1;
	//private int _amount = 0;
	//private Transform _grabbedObject;
	private Rigidbody _grabbedObject;
	public float grabSpeed = 10;
	HingeJoint handy_hand;
    void Start()
    {
		handy_hand = GetComponent<HingeJoint>();
		if (handy_hand == null)
			Debug.Log("Missing hinge joint component in hand");
    }

    void Update()
    {
		Debug.DrawRay(vision.transform.position, vision.transform.forward * reach, Color.green);

        if (Input.GetMouseButtonDown(0))
			Grab();
    }

	public float objectDistance;
	void FixedUpdate() {
		if (_grabbedObject != null)
		{
			Vector3 diff = transform.position - _grabbedObject.transform.position;
			objectDistance = diff.x * diff.x + diff.y * diff.y + diff.z * diff.z;
			if (objectDistance > reach)
				Drop();
			else
				_grabbedObject.velocity = diff * 10;
		}
	}

	void Drop()
	{
		_grabbedObject.GetComponent<Interactable>().MakeTransparent(false);
		Debug.Log("dropping object");
		_grabbedObject.useGravity = true;
		_grabbedObject = null;
	}
	void Grab()
	{
		RaycastHit hit;
		
		if (_grabbedObject != null)
			Drop();
		else if (Physics.Raycast(vision.transform.position, vision.transform.forward, out hit, reach))
		{
			if (hit.transform.GetComponent<Interactable>() == null)
				return ;
			_grabbedObject = hit.transform.GetComponent<Rigidbody>();
			if (_grabbedObject != null)
				_grabbedObject.useGravity = false;
			hit.transform.GetComponent<Interactable>().MakeTransparent(true);
		}
	}
}
