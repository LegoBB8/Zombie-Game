using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireButton : MonoBehaviour {

	public string buttonName="Fire1";
	public UnityEvent buttonDown;
	public UnityEvent buttonUp;
	public UnityEvent buttonHold;

	void Update () {
		if (Input.GetButtonDown (buttonName))
			buttonDown.Invoke ();
		if (Input.GetButtonUp (buttonName))
			buttonUp.Invoke ();
		if (Input.GetButton (buttonName))
			buttonHold.Invoke ();
	}
}
