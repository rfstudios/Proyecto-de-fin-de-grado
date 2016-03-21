using UnityEngine;
using System.Collections;

public class Objeto : MonoBehaviour 
{
	public int tipo; //1: Plataforma movil, 2: Plataforma rebotante, 3: Ascensor y descensor
	public int[] val_inic = new int[2]; // Para la plataforma movil: velocidad minima y maxima
	private int valor=1; // Para la plataforma movil: velocidad
	public Transform[] valores=new Transform[2];
	protected bool interr=false;

	
	void Start () 
	{
		switch(tipo)
		{
			case 1:	case 3:
				valor=Random.Range(val_inic[0],val_inic[1]);
				break;
		}
	}
	void Update () 
	{
		switch(tipo)
		{
			case 1:
				plataforma();
				break;
			case 3:
				plataforma2();
				break;
		}
	}
	
	protected void plataforma()
	{
		if(valores[0].position.x<transform.position.x && !interr)
		{
			transform.Translate(-valor*Time.deltaTime,0,0);
		}
		else if(valores[0].position.x>=transform.position.x && !interr)
		{
			interr=true;
		}
		else if(valores[1].position.x>transform.position.x && interr)
		{
			transform.Translate(valor*Time.deltaTime,0,0);
		}
		else if(valores[1].position.x<=transform.position.x && interr)
		{
			interr=false;
		}
	}
	
	protected void plataforma2()
	{
		if(valores[0].position.y<transform.position.y && !interr)
		{
			transform.Translate(0,-valor*Time.deltaTime,0);
		}
		else if(valores[0].position.y>=transform.position.y && !interr)
		{
			interr=true;
		}
		else if(valores[1].position.y>transform.position.y && interr)
		{
			transform.Translate(0,valor*Time.deltaTime,0);
		}
		else if(valores[1].position.y<=transform.position.y && interr)
		{
			interr=false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
			switch (tipo) 
			{
				case 1:
						if (interr) {
								coll.gameObject.transform.Translate (valor * Time.deltaTime, 0, 0);
						} else {
								coll.gameObject.transform.Translate (-valor * Time.deltaTime, 0, 0);
						}
						break;
			}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		switch (tipo) 
		{
			case 3:
				if (transform.position.y < valores[0].position.y && Input.GetAxis("Vertical")>0) 
				{
					coll.gameObject.transform.Translate (0,valor * Time.deltaTime,0);
					transform.Translate(0,valor * Time.deltaTime,0);
				}

				if (transform.position.y > valores[1].position.y && Input.GetAxis("Vertical")<0) 
				{
					coll.gameObject.transform.Translate (0,-valor * Time.deltaTime,0);
					transform.Translate(0,-valor * Time.deltaTime,0);
				}
				break;
		}
	}
}