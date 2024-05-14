using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
	public ControllerTrigger controllerTriggerSqr;

	[SerializeField] GameObject bulletObj;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if(controllerTriggerSqr.GetRTDown())
		{
			Instantiate(bulletObj, transform.position, Quaternion.identity);
		}
	}
}
