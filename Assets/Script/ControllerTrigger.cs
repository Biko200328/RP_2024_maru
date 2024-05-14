using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTrigger : MonoBehaviour
{
	[SerializeField] int prevInfo;
	[SerializeField] int isStickInfo;

	float v1;
	float h1;
	float v2;
	float h2;

	float tri;
	bool isRT;
	bool isPrevRT;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		prevInfo = isStickInfo;

		//���X�e�B�b�N
		v1 = Input.GetAxis("cVerticalL");
		h1 = Input.GetAxis("cHorizontalL");

		//�\���{�^��
		v2 = Input.GetAxis("cVerticalCross");
		h2 = Input.GetAxis("cHorizontalCross");

		if (v1 >= 0.8f || v2 >= 1)
		{
			// ��
			isStickInfo = 1;
		}
		else if (v1 <= -0.8f || v2 <= -1)
		{
			// ��
			isStickInfo = 2;
		}
		else if (h1 >= 0.8f || h2 >= 1)
		{
			// ��
			isStickInfo = 3;
		}
		else if (h1 <= -0.8f || h2 <= -1)
		{
			// ��
			isStickInfo = 4;
		}
		else
		{
			isStickInfo = 0;
		}

		//Trigger
		tri = Input.GetAxis("RT");
		//if (tri > 0)
		//{
		//	Debug.Log("L trigger:" + tri);
		//}
		//else if (tri < 0)
		//{
		//	Debug.Log("R trigger:" + tri);
		//}
		//else
		//{
		//	Debug.Log("  trigger:none");
		//}
	}

	/// <Summary>
	/// �������w�肵�ē��͂��ꂽ�u�Ԃ�Ԃ��܂�<br />
	/// ������"Up","Down","Right","Left"���Âꂩ������
	/// </Summary>
	public bool GetTrigger(string direction)
	{
		if (direction == "Up")
		{
			if (isStickInfo == 1 && prevInfo == 0)
			{
				return true;
			}
		}

		if (direction == "Down")
		{
			if (isStickInfo == 2 && prevInfo == 0)
			{
				return true;
			}
		}

		if (direction == "Right")
		{
			if (isStickInfo == 3 && prevInfo == 0)
			{
				return true;
			}
		}

		if (direction == "Left")
		{
			if (isStickInfo == 4 && prevInfo == 0)
			{
				return true;
			}
		}

		return false;
	}

	/// <Summary>
	/// �������w�肵�ē��͂��Ă���ԕԂ��܂�<br />
	/// ������"Up","Down","Right","Left"���Âꂩ������
	/// </Summary>
	public bool GetHold(string direction)
	{
		if (direction == "Up")
		{
			if (isStickInfo == 1)
			{
				return true;
			}
		}

		if (direction == "Down")
		{
			if (isStickInfo == 2)
			{
				return true;
			}
		}

		if (direction == "Right")
		{
			if (isStickInfo == 3)
			{
				return true;
			}
		}

		if (direction == "Left")
		{
			if (isStickInfo == 4)
			{
				return true;
			}
		}

		return false;
	}

	/// <Summary>
	/// �������w�肵�ė����ꂽ�u�Ԃ�Ԃ��܂�<br />
	/// ������"Up","Down","Right","Left"���Âꂩ������
	/// </Summary>
	public bool GetRelease(string direction)
	{
		if (direction == "Up")
		{
			if (isStickInfo == 0 && prevInfo == 1)
			{
				return true;
			}
		}

		if (direction == "Down")
		{
			if (isStickInfo == 0 && prevInfo == 2)
			{
				return true;
			}
		}

		if (direction == "Right")
		{
			if (isStickInfo == 0 && prevInfo == 3)
			{
				return true;
			}
		}

		if (direction == "Left")
		{
			if (isStickInfo == 0 && prevInfo == 4)
			{
				return true;
			}
		}

		return false;
	}

	public bool GetRTDown()
	{
		if(tri <= -0.8f)
		{
			isRT = true;
		}
		else
		{
			isRT = false;
		}

		if (isRT == true && isPrevRT == false)
		{
			return true;
		}

		isPrevRT = isRT;

		return false;
	}

	public bool GetRT()
	{
		if (tri <= -0.8f)
		{
			isRT = true;
		}
		else
		{
			isRT = false;
		}

		if (isRT == true)
		{
			return true;
		}

		return false;
	}
}
