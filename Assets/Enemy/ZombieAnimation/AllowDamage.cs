using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowDamage : StateMachineBehaviour {

	Enemy enemy;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		enemy = animator.GetComponent<Enemy> ();
		enemy.haveDamage = true;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		enemy.haveDamage = true;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		enemy.haveDamage = false;
	}
}
