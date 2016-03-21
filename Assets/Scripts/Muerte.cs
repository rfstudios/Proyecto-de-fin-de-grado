using UnityEngine;
using System.Collections;

public class Muerte : MonoBehaviour {
	bool recargado=false;
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag=="Player_f")
		{
			GameObject player=col.gameObject;
			player.GetComponent<Controles>().muerto=true;
			Invoke("recarga",3);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag=="Player_f")
		{
			GameObject player=col.gameObject;
			player.GetComponent<Controles>().muerto=true;
			Invoke("recarga",3);
		}
	}

	protected void recarga()
	{
		if(recargado){return;}
		gestor.reloadLevel();
		recargado = true;
	}
}
