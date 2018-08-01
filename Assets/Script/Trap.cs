using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {

	public float damage=1;

	void OnTriggerStay (Collider col) {
		if (col.CompareTag ("Player")) {
			col.gameObject.SendMessage ("Hurt", damage);
		}
	}
}
