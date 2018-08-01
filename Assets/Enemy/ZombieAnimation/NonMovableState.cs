using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NonMovableState : StateMachineBehaviour {

	NavMeshAgent NM;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		NM = animator.GetComponent<NavMeshAgent> ();
		NM.updatePosition = false;
		NM.updateRotation = false;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		NM.updatePosition = true;
		NM.updateRotation = true;
	}
}
