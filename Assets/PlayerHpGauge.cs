using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpGauge : MonoBehaviour
{
	public PlayerHp playerHp;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var scale = gameObject.transform.localScale;
		scale.x = playerHp.nowHp / playerHp.maxHp;
		gameObject.transform.localScale = scale;
	}
}
