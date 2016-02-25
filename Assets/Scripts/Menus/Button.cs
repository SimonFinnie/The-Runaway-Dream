using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public Transform menuRoot;
	public string tip;



	
	// Update is called once per frame
	public virtual void Update () {

	
	}

	public virtual void Entered (){}
	public virtual void Exited (){}
	public virtual void Clicked (){}
}
