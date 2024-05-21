using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
	public SceneController sceneController;
	// Start is called before the first frame update
	void Start()
	{
		Screen.SetResolution(1280, 720, false);
		Application.targetFrameRate = 60;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetButtonDown("buttonA"))
		{
			sceneController.sceneChange("GameScene");
		}
	}
}
