using UnityEngine;
using System.Collections;

[RequireComponent ( typeof ( Explodable ) )]
public class pot: MonoBehaviour
	{

	private Explodable _explodable;
	public GameObject ShotTag;
	public string shotNameString;
	public GameObject[] ticks;


	void Start ( )
		{
		_explodable = GetComponent<Explodable> ( );
		}
    private void OnTriggerEnter2D ( Collider2D collision )
        {
        if(collision.gameObject.tag == shotNameString)
			{
			GameObject.Find ( "pots" ).GetComponent<playPotBreakSound> ( ).PotBreakSoundPlay ( );
			Destroy ( ShotTag );
			_explodable.explode ( );
			ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
			//ef.doExplosion(transform.position);
			

			if (shotNameString == "uh1s")
                {
				ticks [ 0 ].SetActive ( true );

                }
			if (shotNameString == "uh2s")
				{
				ticks [ 1 ].SetActive ( true );
				}
			if (shotNameString == "uk1s")
				{
				ticks [ 2 ].SetActive ( true );
				}
			if (shotNameString == "uk2s")
				{
				ticks [ 3 ].SetActive ( true );
				}
			}
		}
		
	}

