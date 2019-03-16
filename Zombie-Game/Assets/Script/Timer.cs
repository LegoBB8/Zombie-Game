using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour {

	Text text;
	public float time=60;
	public UnityEvent timesupEvent;
	bool timesup = false;

	void Start () {
		text = GetComponent<Text>();
	}
	
	void Update () {
		if (!timesup) {
			if (time > 0)
				time -= Time.deltaTime;
			text.text = Mathf.Ceil (time).ToString ("00");
			if (time <= 0) {
				timesup = true;
				timesupEvent.Invoke ();
			}
		}
	}
}
