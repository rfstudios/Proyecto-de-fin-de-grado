using UnityEngine;
using System.Collections;

public class Animaciones : MonoBehaviour 
{
	protected Animator animator;
	protected int estado;
	
	public void setEstado(int est)
	{
		estado=est;
		animator.SetInteger("estado",estado);
	}
	public void setEstado(float est)
	{
		estado=(int)est;
		animator.SetInteger("estado",estado);
	}

	// Use this for initialization
	void Start () 
	{
		animator=GetComponent<Animator>();
		animator.SetInteger("estado",0);
		setEstado(0);
	}
}
