using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour 
{
	protected Animator animator;

	protected bool abierto;
	public bool Abrete
	{
		get
		{
			return abierto;
		}
		set
		{
			abierto = true;
			animator.SetBool("Abierta",true);
		}
	}

	void Start () 
	{
		animator=GetComponent<Animator>();
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(!Abrete){return;}
		FadeTransition.FadeTo("gestor");

		if(gestor.desbloqueado == gestor.lvlActual)
		{
			gestor.addLevel();
		}
	}
}
