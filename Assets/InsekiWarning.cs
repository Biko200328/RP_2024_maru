using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsekiWarning : MonoBehaviour
{
	GameObject centerObj;

	float timer;
	public float DestroyTime;

	// Start is called before the first frame update
	void Start()
	{
		centerObj = GameObject.FindGameObjectWithTag("Center");

		transform.LookAt(centerObj.transform);
		transform.eulerAngles = new Vector3(/*transform.eulerAngles.x + */90, transform.eulerAngles.y, transform.eulerAngles.z);
	}

	// Update is called once per frame
	void Update()
	{
		if (timer >= DestroyTime)
		{
			Destroy(this.gameObject);
		}
	}

	private void FixedUpdate()
	{
		timer++;
	}
}
