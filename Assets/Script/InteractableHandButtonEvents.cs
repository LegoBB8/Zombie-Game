//======= Copyright (c) Vincent Lam, All rights reserved. ===============
//
// Purpose: Modify InteractiableButtonEvents by Vincent Lam
//
//=============================================================================

using UnityEngine;
using UnityEngine.Events;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class InteractableHandButtonEvents : MonoBehaviour
	{
		public UnityEvent onTriggerDown;
		public UnityEvent onTriggerUp;
		public UnityEvent onGripDown;
		public UnityEvent onGripUp;
		public UnityEvent onTouchpadDown;
		public UnityEvent onTouchpadUp;
		public UnityEvent onTouchpadTouch;
		public UnityEvent onTouchpadRelease;

		//-------------------------------------------------
		void Update()
		{

			Hand hand = transform.GetComponentInParent<Hand>();

				if ( hand.controller != null )
				{
					if ( hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger ) )
					{
						onTriggerDown.Invoke();
					}

					if ( hand.controller.GetPressUp( Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger ) )
					{
						onTriggerUp.Invoke();
					}

					if ( hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_Grip ) )
					{
						onGripDown.Invoke();
					}

					if ( hand.controller.GetPressUp( Valve.VR.EVRButtonId.k_EButton_Grip ) )
					{
						onGripUp.Invoke();
					}

					if ( hand.controller.GetPressDown( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad ) )
					{
						onTouchpadDown.Invoke();
					}

					if ( hand.controller.GetPressUp( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad ) )
					{
						onTouchpadUp.Invoke();
					}

					if ( hand.controller.GetTouchDown( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad ) )
					{
						onTouchpadTouch.Invoke();
					}

					if ( hand.controller.GetTouchUp( Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad ) )
					{
						onTouchpadRelease.Invoke();
					}
				}

		}
	}
}
