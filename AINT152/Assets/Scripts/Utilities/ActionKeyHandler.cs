using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// this component will send a UnityEvent when a key is pressed, held down or released (or all 3)
// we can assign a key to the "actionKey" property in the inspector
public class ActionKeyHandler : MonoBehaviour 
{
	// this will be the key that wil be checked
	public KeyCode actionKey = KeyCode.None;

	// use these events in the inspector to tell other gameobjects to do something when the events are invoked
	// event for when key is pressed - only activates once each time the key is pressed
	public UnityEvent onKeyDown;
	
	// activates constantly when key is held down
	public UnityEvent onKey;

	// activates when the key is released - only activates once each time the key is released
	public UnityEvent onKeyUp;

	void Update () 
	{
		// check if our actionkey has been pressed
		if(Input.GetKeyDown(actionKey))
		{
			// send the event if the key was pressed
			onKeyDown.Invoke();
		}

		// check if our actionkey is held down
		if(Input.GetKey(actionKey))
		{
			// send the event every frame the key is held down
			// NOTE: this will send A LOT of events! (like, around 60 per second!)
			onKey.Invoke();
		}

		// check if our actionkey has been released
		if(Input.GetKeyUp(actionKey))
		{
			// send the event if the key was released
			onKeyUp.Invoke();
		}
	}
}
