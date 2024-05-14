using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] float speed;

	public float radius = 0.5f; //‰~‚Ì‘å‚«‚³

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		_x = playerMoveSqr.radius * Mathf.Sin(Time.time * speed);
		_z = playerMoveSqr.radius * Mathf.Cos(Time.time * speed);

		transform.position = new Vector3(_x, 1, _z);
	}
}
