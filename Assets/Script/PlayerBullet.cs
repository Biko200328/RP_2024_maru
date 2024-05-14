using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public float speed;
	[SerializeField] float time;

	public float radius = 0.5f; //‰~‚Ì‘å‚«‚³

	float _x;
	float _z;

	public PlayerMove playerMoveSqr;

	public float deadTime;
	float deadTimer;

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

		if(deadTimer >= deadTime)
		{
			Destroy(this.gameObject);
		}
	}

	private void FixedUpdate()
	{
		time += speed;

		deadTimer += Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Wall")
		{
			Destroy(this.gameObject);
		}
	}
}
