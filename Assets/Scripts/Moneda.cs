using UnityEngine;
using System.Collections;

public class Moneda : MonoBehaviour 
{
	public AudioClip fx;
	private bool est;
	private Control componente;

	bool estado
	{
		get
		{
			return est;
		}
		set
		{
			est=value;
		}
	}

	void Start () 
	{
		estado = false;
	}

	void Update()
	{
		if (estado) 
		{
			transform.localScale -= new Vector3(0.025F, 0, 0);
			transform.Translate(0,0.05f,0);
			if(transform.localScale.x<0)
			{
				Destroy(gameObject);
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D coll)
	{
		if(estado){return;}

		estado=true;

		GameObject.FindWithTag("MainCamera").GetComponent<Control>().puntuacion++;
		SoundManager.PlayFX(fx);
	}
}
