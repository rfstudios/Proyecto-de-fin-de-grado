using UnityEngine;
using System.Collections;

public class boton : MonoBehaviour 
{
	public int mio;
	public AudioClip fx;
	GameObject camara;
	protected bool activo=false;
	
	void Start()
	{
		camara=GameObject.FindWithTag("MainCamera");
	}
	void Update () 
	{
		if(mio<=gestor.desbloqueado)
		{
			activo=true;
		}
		else
		{
			activo=false;
		}

		GetComponent<Renderer>().enabled = activo;
		GetComponent<Collider2D>().enabled = activo;
	}

	void OnMouseUp()
	{
		gestor.goLevel(mio);
		SoundManager.PlayFX(fx);
	}
}
