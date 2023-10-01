using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CharController : MonoBehaviour
{
	public Transform movePoint;
	public int titlesToMove;
	public bool canItMove;
	public bool haveKey;

	private enemyScript target =null;

	//=============

	public GameObject attackButton;
	public GameObject moveButton;
	public GameObject passMovement;
	public GameObject throwKeyBtn;
	public Transform upRow;
	public Transform downRow;
	public GameObject keyOBJ;
	public UnityEvent CharacterMoved;
	public UnityEvent CharacterPassed;

    void Start()
	{
		throwKeyBtn.SetActive(false);
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
			target=collision.gameObject.GetComponent<enemyScript>();
			target.canItMove = false;
			attackButton.SetActive(true);
			moveButton.SetActive(false);
			canItMove = false;
			target.EnemyDeath.AddListener(OnEnemyTargetDeath);
			Debug.Log("Collison with enemy");

		}
		if (collision.gameObject.tag == "Key")
		{
			keyOBJ = collision.gameObject;
			collision.gameObject.transform.parent=gameObject.transform;
			haveKey = true;
			throwKeyBtn.SetActive(true);
			collision.gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0.5f) ;
		}
	}
	
	public void ThrowKey()
	{
		keyOBJ.transform.position = downRow.position;
		keyOBJ.transform.parent = null;
		throwKeyBtn.SetActive(false);
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

	public void PassMove()
	{
		CharacterMoved?.Invoke();

    }
}
