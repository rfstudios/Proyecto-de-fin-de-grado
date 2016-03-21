using UnityEngine;
using System.Collections;

public class Complementos : MonoBehaviour 
{
	public int actual=-1,anterior=-1;
	private int cMax=2; //Maximo de complementos
	protected float[,] complementos=new float[3,4];
	protected Animator animator;
	
	/* Atributos */
	public int complemento
	{
		get
		{
			return actual;
		}
		set
		{
			actual=value;
			
			if(actual>cMax)
			{
				actual=-1;
			}
			else if(actual<-1)
			{
				actual=cMax;
			}

			if(actual!=anterior)
			{
				anterior=actual;
				cambioComplemento();
			}
		}
	}
	/* Miembros */	
	protected void cambioComplemento()
	{
		animator.SetInteger("complemento",actual);
		
		if(actual>-1)
		{
			transform.localPosition=new Vector3(complementos[actual,0],complementos[actual,1],complementos[actual,2]);
			transform.localScale=new Vector3(complementos[actual,3],complementos[actual,3],complementos[actual,3]);
		}
	}

	// Use this for initialization
	void Start () 
	{
		animator=GetComponent<Animator>();	
		complemento=actual;

		/* Gafas */
		complementos[0,0]=0.09f; //Posicion X;
		complementos[0,1]=0.27f; //Posicion Y;
		complementos[0,2]=-1.0f; //Posicion Z (-1 -> delante; 1 -> detras);
		complementos[0,3]=0.7f; //Escala

		/* Alas */
		complementos[1,0]=-0.01f; //Posicion Z (-1 -> delante; 1 -> detras);
		complementos[1,1]=0.4f; //Posicion Z (-1 -> delante; 1 -> detras);
		complementos[1,2]=1f; //Posicion Z (-1 -> delante; 1 -> detras);
		complementos[1,3]=4f; //Escala
		
		/* Sombrero */
		complementos[2,0]=0f; //Posicion X;
		complementos[2,1]=0.7f; //Posicion Y;
		complementos[2,2]=-1.0f; //Posicion Z (-1 -> delante; 1 -> detras);
		complementos[2,3]=1f; //Escala
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Input.GetKeyDown(KeyCode.KeypadPlus))
		{
			complemento++;
		}

		if(Input.GetKeyDown(KeyCode.KeypadMinus))
		{
			complemento--;
		}
	}
}
