using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	float speed = 0.5f;  //ƒJƒƒ‰‚ÌˆÚ“®‘¬“x
	public float radius = 0.5f; //‰~‚Ì‘å‚«‚³

	float _x;
	float _z;

	public GameObject playerObj;
	public PlayerMove playerMoveSqr;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.A))
		{
			speed += playerMoveSqr.addSpeed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			speed += -playerMoveSqr.addSpeed;
		}

		_x = radius * Mathf.Sin(speed);
		_z = radius * Mathf.Cos(speed);

		transform.position = new Vector3(_x, transform.position.y, _z);
		transform.LookAt(playerObj.gameObject.transform);
	}
}
