using UnityEngine;
using System.Collections;

public class Llave : MonoBehaviour 
{
	private float scal=0f;
	private bool estado=false;
	void Update () 
	{		
		if (estado) 
		{
			Destroy(gameObject);
		}
		else
		{
			transform.localScale = new Vector3(Mathf.Cos(Time.time)*0.25f, 0.25f, 0);
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(estado){return;}
		
		estado=true;		
		GameObject.FindWithTag("Puerta").GetComponent<Puerta>().Abrete=true;
	}
}
