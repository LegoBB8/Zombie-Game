using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent (typeof (AudioSource))]
public class Enemy : MonoBehaviour {

	public float life = 500;
	public float deepHurt = 100;
	private float nextDeepHurt;
	public bool removeAfterDie=false;
	public float dieDelay = 5f;
	public UnityEvent dieEvent;
	public GameObject dieFX;
	public GameObject dieRemoveFX;
	public AudioClip walkSound;
	public AudioClip hurtSound;
	public bool hurtSoundPitchChange = true;
	public float hurtLowPitch=0.7f;
	public float hurtHighPitch=1.3f;
	public float attackDistance=1.5f;
	[HideInInspector]
	public bool haveDamage=false;
	AudioSource AS;
	Animator anim;
	bool dead;
	float distance;

	NavMeshAgent NM;
	Transform Player;

	void Awake () {
		Player = GameObject.FindWithTag("Player").transform;
	}

	void Start () {
		NM = GetComponent<NavMeshAgent>();
		AS = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
		nextDeepHurt = life - deepHurt;
		dead =false;
	}

	void Update () {
		if (!dead) {
			distance = Vector3.Distance (transform.position, Player.position);
			if (distance >= attackDistance) {
				NM.SetDestination (Player.position);
				NM.updateRotation = true;
				anim.ResetTrigger ("attack");
				AS.clip = walkSound;
				if (!AS.isPlaying)
					AS.Play ();
			}
			else {
				NM.SetDestination (transform.position);
				NM.updateRotation = false;
				Vector3 temPos = Player.position;
				temPos.y = transform.position.y;
				transform.LookAt (temPos);
				if (anim) {
					anim.SetTrigger ("attack");
				}

			}
		}
	}

	public void ImHit (string[] bulletInfo) {
		if (!dead) {
			life -= float.Parse (bulletInfo [1]);
			if (life <= 0) {
				Kill ();
				return;
			}
			if (hurtSound != null) {
				if (hurtSoundPitchChange)
					AS.pitch = Random.Range (hurtLowPitch, hurtHighPitch);	
				AS.PlayOneShot (hurtSound);
			}
			if (life <= nextDeepHurt) {
				anim.SetTrigger ("deephurt");
				nextDeepHurt -= deepHurt;
			}
		}
	}

	void Kill () {
		dead = true;
		AS.Stop ();
		AS.pitch = 1;
		//NM.updatePosition = false;
		//NM.updateRotation = false;
		NM.enabled=false;
		if (anim)
			anim.SetTrigger ("die");
		//Collider[] col = GetComponentsInChildren<Collider>();
		//foreach (Collider _col in col)
		//	_col.enabled = false;

		//DestroyAfter[] bullets = GetComponentsInChildren<DestroyAfter> ();
		//foreach (DestroyAfter bullet in bullets) {
		//	Destroy (bullet.transform.gameObject);
		//}

		dieEvent.Invoke ();
		if (dieFX)
			Instantiate (dieFX, transform.position, Quaternion.identity);
		if (removeAfterDie)
			Invoke ("Remove", dieDelay);
	}

	void Remove () {
		Destroy(gameObject);
		if (dieRemoveFX)
			Instantiate (dieRemoveFX, transform.position, Quaternion.identity);
	}
}
