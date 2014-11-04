using UnityEngine;
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponEnemy[] weapons;

	
	void Awake()
	{
		weapons = GetComponentsInChildren<WeaponEnemy>();
		moveScript = GetComponent<MoveScript>();
	}
	

	void Start()
	{


		hasSpawn = false;
		collider2D.enabled = false;
		moveScript.enabled = false;
		foreach (WeaponEnemy weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			foreach (WeaponEnemy weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					if (renderer.IsVisibleFrom(Camera.main) == true){
						SoundEffectsHelper.Instance.MakeEnemyShotSound();
					}

				}
			}
		    
			//if (renderer.IsVisibleFrom(Camera.main) == false)
			//{
			//	Destroy(gameObject);
			//}
			 

		}
	}

	private void Spawn()
	{
		hasSpawn = true;
		collider2D.enabled = true;
		moveScript.enabled = true;
		foreach (WeaponEnemy weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}