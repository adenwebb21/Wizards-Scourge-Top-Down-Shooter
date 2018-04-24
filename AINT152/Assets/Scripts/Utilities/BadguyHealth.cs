using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// this is just a simple health class with an event to demonstrate the damageflash component
public class BadguyHealth : MonoBehaviour 
{
	// bad guy health, use to test if its being hit or not
	public int health = 10;

	// create an event like this on your own bad guy health scripts to use with the damage flash
	// this event will activate when the "TakeDamage" method is called
	public UnityEvent onTakeDamage;

	// this will apply damage to the bad guy, from the damage parameter
	// it will also activate the onTakeDamage event, used for our damageflash
	public void TakeDamage (int damage) 
	{
		// remove health from bad guy
		health-= damage;

		// use this to activate the damageflash in the inspector
		onTakeDamage.Invoke();
	}
}
