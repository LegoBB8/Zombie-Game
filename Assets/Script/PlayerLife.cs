using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent (typeof (AudioSource))]
public class PlayerLife : MonoBehaviour {

	public float life=10;
	public float hurtRate = 0.4f;
	public AudioClip[] hurtSound;
	public AudioClip dieSound;
	public GameObject bloodScreen;
	public GameObject GameOverScreen;
	public UnityEvent dieEvent;
	AudioSource AS;
	public static bool dead;
	float nextHurtTime=0;

	void Start () {
		AS = GetComponent<AudioSource>();
		dead = false;
	}

	void Update () {
		if (dead) {
			Vector3 newDir = Vector3.RotateTowards(transform.forward, Vector3.up, 2*Time.deltaTime, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
		}
	}

	public void Hurt (float damage) {
		if (!dead && Time.time > nextHurtTime) {
			life -= damage;
			if (bloodScreen)
				bloodScreen.SetActive(true);
			nextHurtTime = Time.time + hurtRate;
			if (life <=0) {
				Die ();
				return;
			}
			else {
				AS.PlayOneShot(hurtSound[Random.Range(0, hurtSound.Length)]);
			}
		}
	}

	public void Die () {
		dead = true;
		dieEvent.Invoke ();
		AS.PlayOneShot(dieSound);
		Gun[] allgun = GameObject.FindObjectsOfType<Gun> ();
		foreach (Gun mygun in allgun)
			mygun.enabled = false;

		Invoke ("Restart", 4f);
	}

	void Restart () {
		if (GameOverScreen)
			GameOverScreen.SetActive(true);
		else
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}

