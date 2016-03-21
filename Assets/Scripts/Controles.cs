using UnityEngine;
using System.Collections;

public class Controles : MonoBehaviour 
{
	protected Animaciones animaciones;
	protected GameObject player;

	public bool muerte=false;

	/* Fisicas */
	public float maxSpeed=10f;
	bool facingRight=true;			//Flag hacia donde mira el personaje;
	public bool grounded=false;		//Controla si estoy en el suelo o no;
	public Transform groundCheck;	//Chequea que este en el suelo;
	public bool pared=false;		//Si estamos contra una pared;
	public Transform wallCheck;		//Chequea que tengamos pared;
	public bool escala=false;
	public Transform escalaCheck;
	float groundRadius=0.2f;		//El radio en el que vamos a comprobar si estamos en el suelo;
	public LayerMask whatIsGround;	//Para seleccionar la capa en la que almaceno las plataformas;
	public LayerMask whatIsEscala;	//Para seleccionar la capa en la que almaceno las escalas;
	public float jumpForce;			//Fuerza del salto;

	// Use this for initialization
	void Start () 
	{
		/* Recogemos el script de control de animaciones*/
		player=GameObject.FindWithTag("Player");
		animaciones=player.GetComponent<Animaciones>();
		muerto=false;
	}
	
	// Update is called once per frame
	void FixedUpdate() 
	{
		if(muerto){return;} //Si esta muerto nos vamos

		grounded=Physics2D.OverlapCircle(groundCheck.position,groundRadius,whatIsGround);
		pared=Physics2D.OverlapCircle(wallCheck.position,groundRadius,whatIsGround);

		if(escala && !Physics2D.OverlapCircle(escalaCheck.position,groundRadius,whatIsEscala))
		{
			setEscala=false;
		}

		float move=Input.GetAxis ("Horizontal");
		if(pared && move>0 && transform.localScale.x>0)
		{
			move=0;
		}
		else if(pared && move<0 && transform.localScale.x<0)
		{
			move=0;
		}

		if(escala)
		{
			GetComponent<Rigidbody2D>().velocity=new Vector2(move*maxSpeed,Input.GetAxis("Vertical")*maxSpeed);
		}
		else
		{
			GetComponent<Rigidbody2D>().velocity=new Vector2(move*maxSpeed,GetComponent<Rigidbody2D>().velocity.y);
		}
		
		/* Asignamos como velocidad el Axis "Horizontal" por la velocidad maxima y la velocidad que ya tenia en Y */
		if(grounded)
		{
			if(move!=0)
			{
				animaciones.setEstado(1);
			}
			else
			{
				animaciones.setEstado(0);
			}
		}
		else
		{
			if(escala)
			{
				if(GetComponent<Rigidbody2D>().velocity.x!=0)
				{
					animaciones.setEstado(5);
				}
				else if(GetComponent<Rigidbody2D>().velocity.y!=0)
				{
					animaciones.setEstado(4);
				}
				else
				{

				}
			}
			else
			{
				if(GetComponent<Rigidbody2D>().velocity.y>0)
				{
					animaciones.setEstado(2);
				}
				else
				{
					animaciones.setEstado(3);
				}
			}
		}

		if(move>0 && !facingRight)
		{
			flip();
		}
		else if(move<0 && facingRight)
		{
			flip();
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		if(muerte)
		{
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(grounded)
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0,jumpForce));
			}
			if(escala)
			{
				setEscala=false;
			}
		}

		if(Input.GetAxis("Vertical")!=0 && Physics2D.OverlapCircle(escalaCheck.position,groundRadius,whatIsEscala))
		{
			setEscala=true;
		}
	}

	protected bool setEscala
	{
		set
		{
			escala=value;

			if(escala)
			{
				GetComponent<Rigidbody2D>().gravityScale=0;
			}
			else
			{
				GetComponent<Rigidbody2D>().gravityScale=1;
				GetComponent<Rigidbody2D>().velocity=new Vector2(GetComponent<Rigidbody2D>().velocity.x,0);
				grounded=false;
			}
		}
	}

	void flip()
	{
		facingRight=!facingRight;
		Vector3 escala=transform.localScale;
		escala.x*=-1;
		transform.localScale=escala;
	}

	public bool muerto
	{
		set
		{
			muerte=value;

			if(muerte)
			{
				animaciones.setEstado(-1);
			}
		}
		get
		{
			return muerte;
		}
	}
}
