using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour 
{
	protected bool fin = false;
	protected Animator animator;
	public AudioClip fx;

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
		if(fin){return;}

		FadeTransition.FadeTo("gestor");
		SoundManager.PlayFX(fx);

		if(gestor.desbloqueado == gestor.lvlActual)
		{
			gestor.addLevel();
		}
		fin = true;
	}
}
