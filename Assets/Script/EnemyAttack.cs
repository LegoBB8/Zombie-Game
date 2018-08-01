using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

	public float damage=1;
	Enemy enemy;

	void Start () {
		enemy = GetComponentInParent<Enemy> ();
	}

	void OnTriggerEnter (Collider col) {
		if (enemy.haveDamage) {
			if (col.CompareTag ("Player")) {
				col.gameObject.SendMessage ("Hurt", damage);
			}
		}
	}
}
