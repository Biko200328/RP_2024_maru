using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float time;

	public float radius = 0.5f; //‰~‚Ì‘å‚«‚³

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;

	// Start is called before the first frame update
	void Start()
    {
		playerMoveSqr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
		transform.eulerAngles = new Vector3(-90, 0, 0);
		time -= playerMoveSqr.rotate;
	}

    // Update is called once per frame
    void Update()
    {
		_x = playerMoveSqr.radius * Mathf.Sin(-time);
		_z = playerMoveSqr.radius * Mathf.Cos(-time);

		transform.position = new Vector3(_x, transform.position.y, _z);
	}

	private void FixedUpdate()
	{
		time += speed;
	}
}
