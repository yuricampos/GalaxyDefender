﻿using UnityEngine;


public class WeaponEnemy : MonoBehaviour
{
	
	public Transform shotPrefab;
	
	public float shootingRate = 0.25f;
	
	private float shootCooldown;
	
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}
	
	
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.position = transform.position;
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			MoveShot move = shotTransform.gameObject.GetComponent<MoveShot>();
			if (move != null)
			{
				move.direction = this.transform.right;
			}
		}
	}
	
	
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}