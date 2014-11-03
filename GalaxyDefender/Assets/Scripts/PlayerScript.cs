using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public Vector2 speed = new Vector2(20, 0);
	private Vector2 movement;
	
	void Start () {
	
	}
	

	void Update () {

		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			0 * inputY);

		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		
		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				weapon.Attack(false);
			}
		}

		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;

		/**
		 * 		if (transform.position.y == topBorder) {
			Debug.Log ("I WON");
		}

		 * */



		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
			);

		
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		LifeScript life = collision.gameObject.GetComponent<LifeScript>();
		FireScript fire = collision.gameObject.GetComponent<FireScript>();
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}

		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
		if (life != null) {
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			playerHealth.Life(1);

				}
		if (fire != null) {
			WeaponScript weapon = this.GetComponent<WeaponScript>();
			weapon.NewRate(0.2f);
				}
	}

	void OnDestroy()
	{
		if (Application.loadedLevelName == "LevelOne") {
			transform.parent.gameObject.AddComponent<GameOverScript>();
				}
		if (Application.loadedLevelName == "LevelTwo") {
			transform.parent.gameObject.AddComponent<GameOverScriptTwo>();
		}
		if (Application.loadedLevelName == "LevelThree") {
			transform.parent.gameObject.AddComponent<GameOverScriptThree>();
		}

	}



	}
