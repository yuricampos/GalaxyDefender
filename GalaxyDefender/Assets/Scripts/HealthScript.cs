using UnityEngine;

public class HealthScript : MonoBehaviour
{
	public int hp = 1;
	public bool isEnemy = true;
	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if (hp <= 0)
		{
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				Destroy(shot.gameObject);
			}
		}
	}

	void OnGUI()
	{
		string stringToEdit = ""+hp.ToString();
		//GUI.Box (new Rect (0,0,100,50), hp+"lifes");
		int TextWidth = 35;
		//GUI.Label(new Rect(Screen.width-TextWidth, 10, TextWidth, 22), ""+hp);
		//GUI.Label(new Rect(Screen.width-TextWidth, 10, TextWidth, 22), "");
		//GUI.Label(new Rect(Screen.width-TextWidth, 10, TextWidth, 22), ""+hp);
		stringToEdit = GUI.TextField(new Rect(Screen.width-TextWidth, 10, TextWidth, 22), stringToEdit, 25);
	}
}