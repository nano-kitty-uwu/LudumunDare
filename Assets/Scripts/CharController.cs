using UnityEngine;
using UnityEngine.Events;

public class CharController : MonoBehaviour
{
	public Transform movePoint;
	public int titlesToMove;
	public bool canItMove;
	public bool haveKey;
	private enemyScript target =null;
	private bool targetExists;
	public LayerMask stopsMove;

	//=============
	public GameObject attackButton;
	public GameObject moveButton;
	public GameObject passMovement;
	public GameObject throwKey;

	public UnityEvent CharacterMoved;
	
	void Start()
	{
		throwKey.SetActive(false);
		attackButton.SetActive(false);
		canItMove = true;
	}
	public void Move()
	{
		if (canItMove)
		{
			for (int i = 1; i <= titlesToMove; i++)
			{

				transform.position = movePoint.position;
			}
			CharacterMoved?.Invoke();
        }
		
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{

			canItMove = false;
			Debug.Log("Collision with obstcle");
			moveButton.SetActive(false);
		}
		if(collision.gameObject.tag == "Enemy")
		{
			attackButton.SetActive(true);
			moveButton.SetActive(false);
			canItMove = false;
			target=collision.gameObject.GetComponent<enemyScript>();
			target.EnemyDeath.AddListener(OnEnemyTargetDeath);
			targetExists = true;
			Debug.Log("Collison with enemy");
		}
		if (collision.gameObject.tag == "Key")
		{
			haveKey = true;
			throwKey.SetActive(true);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}
	public void Attack()
	{
		//if (targetExists) target.takeDamage(atack1Damage);
		//else Debug.Log("No targert");
	}
	public void Update()
	{

	}

	private void OnEnemyTargetDeath()
	{
		attackButton.SetActive(false);
		moveButton.SetActive(true);
		target = null;
		canItMove = true;
	}
}
