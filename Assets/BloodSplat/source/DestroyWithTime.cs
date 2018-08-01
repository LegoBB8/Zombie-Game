using UnityEngine;
using System.Collections;

public class DestroyWithTime : MonoBehaviour {

	void Start () {
		Destroy(gameObject, 0.4f);
	}
}
