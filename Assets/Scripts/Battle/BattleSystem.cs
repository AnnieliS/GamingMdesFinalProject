using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { PENDING, START, PLAYERTURN, ENEMYTURN, WON, LOST, FLEE }

public class BattleSystem : MonoBehaviour
{
	[Header("Canvas")]
	[SerializeField] GameObject battleCanvas;

	[Header("Character")]
	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	[Header("Character Positions")]
	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	Unit playerUnit;
	Unit enemyUnit;
	[Header("UI")]
	public TextMeshProUGUI dialogueTitle;

	public TextMeshProUGUI dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	[Header("Battle Params")]
	[SerializeField] int attackChance;
	[SerializeField] int enemyAttackChance;
	[SerializeField] string[] attackResponsesSuccess;
	[SerializeField] string[] attackResponsesFail;
	[SerializeField] float textDelay;

	[Header("Battle State")]

	public BattleState state;

	private string[] enemyTaunts;
	private string[] enemyTauntsFail;
	private int numOfAttackSuccessLines;
	private int numOfAttackFailLines;

	// private int numOfEnemyAttackSuccessLines;
	// private int numOfEnemyAttackFailLines;

	private static BattleSystem instance;

	private void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("Found more than one Battle System in the scene.");
		}
		instance = this;
	}

	public static BattleSystem GetInstance()
	{
		return instance;
	}

	// Start is called before the first frame update
	void Start()
	{
		battleCanvas.SetActive(false);
	}

	public void StartBattle(GameObject enemyPrefab)
	{
		PlayerMovement.GetInstance().StopMovement();
		CameraControl.GetInstance().TurnOffCameraControl();
		battleCanvas.SetActive(true);
		state = BattleState.START;
		StartCoroutine(SetupBattle(enemyPrefab));
	}

	IEnumerator SetupBattle(GameObject enemy)
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemy, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();
		enemyTaunts = enemyUnit.GetTaunts();
		enemyTauntsFail = enemyUnit.GetFailTaunts();

		int numOfEnemyAttackSuccessLines = enemyTaunts.Length;
		int rand = Random.Range(0, numOfEnemyAttackSuccessLines);
		dialogueTitle.text = enemyUnit.unitName + " says:";
		dialogueText.text = enemyTaunts[rand];

		// dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		numOfAttackSuccessLines = attackResponsesSuccess.Length;
		numOfAttackFailLines = attackResponsesFail.Length;


		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		yield return new WaitForSeconds(textDelay);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}

	IEnumerator PlayerAttack()
	{
		int rand = Random.Range(0, 100);
		//attack successful
		if (rand <= attackChance)
		{
			int randLine = Random.Range(0, numOfAttackSuccessLines);
			bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

			enemyHUD.SetHP(enemyUnit.currentHP);
			dialogueTitle.text = playerUnit.unitName + " says:";
			dialogueText.text = attackResponsesSuccess[randLine];

			yield return new WaitForSeconds(textDelay);

			if (isDead)
			{
				state = BattleState.WON;
				EndBattle();
			}
			else
			{
				state = BattleState.ENEMYTURN;
				StartCoroutine(EnemyTurn());
			}
		}

		//attack failed
		else
		{
			int randLine = Random.Range(0, numOfAttackFailLines);
			dialogueTitle.text = playerUnit.unitName + " says:";
			dialogueText.text = attackResponsesFail[randLine];

			yield return new WaitForSeconds(textDelay/2);
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}


		// bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

		// enemyHUD.SetHP(enemyUnit.currentHP);
		// dialogueText.text = "The attack is successful!";

		// yield return new WaitForSeconds(2f);

		// if (isDead)
		// {
		// 	state = BattleState.WON;
		// 	EndBattle();
		// }
		// else
		// {
		// 	state = BattleState.ENEMYTURN;
		// 	StartCoroutine(EnemyTurn());
		// }
	}

	IEnumerator EnemyTurn()
	{
		bool isDead = false;
		int randAttack = Random.Range(0, 100);
		if (randAttack <= enemyAttackChance)
		{

			// dialogueText.text = enemyUnit.unitName + " attacks!";
			int numOfTaunts = enemyTaunts.Length;
			int rand = Random.Range(0, numOfTaunts);
			dialogueTitle.text = enemyUnit.unitName + " says:";
			dialogueText.text = enemyTaunts[rand];

			yield return new WaitForSeconds(textDelay/2);

			isDead = playerUnit.TakeDamage(enemyUnit.damage);

			playerHUD.SetHP(playerUnit.currentHP);
		}

		else
		{
			int numOfTaunts = enemyTauntsFail.Length;
			int rand = Random.Range(0, numOfTaunts);
			dialogueTitle.text = enemyUnit.unitName + " says:";
			dialogueText.text = enemyTauntsFail[rand];

			yield return new WaitForSeconds(textDelay/2);
		}

		yield return new WaitForSeconds(textDelay/2);

		if (isDead)
		{
			state = BattleState.LOST;
			EndBattle();
		}
		else
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}

	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			StartCoroutine(CloseBattle());

		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			StartCoroutine(CloseBattle());

		}

		else if (state == BattleState.FLEE)
		{
			dialogueText.text = "i need 2 go";
			StartCoroutine(CloseBattle());

		}
	}

	void PlayerTurn()
	{
		dialogueTitle.text = playerUnit.unitName + ":";
		dialogueText.text = "What should I do?";
	}

	// IEnumerator PlayerHeal()
	// {
	// 	playerUnit.Heal(5);

	// 	playerHUD.SetHP(playerUnit.currentHP);
	// 	dialogueText.text = "You feel renewed strength!";

	// 	yield return new WaitForSeconds(2f);

	// 	state = BattleState.ENEMYTURN;
	// 	StartCoroutine(EnemyTurn());
	// }

	void PlayerFlee()
	{
		state = BattleState.FLEE;
		EndBattle();
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
	}

	public void OnFleeButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		PlayerFlee();
	}


	IEnumerator CloseBattle()
	{
		yield return new WaitForSeconds(textDelay/2);
		PlayerMovement.GetInstance().ResumeMovement();
		CameraControl.GetInstance().TurnOnCameraControl();
		battleCanvas.SetActive(false);

	}

	public void ChangeAttackChance(int change)
	{
		attackChance += change;
		attackChance = Mathf.Clamp(attackChance, 0, 100);
	}

	public void ChangeEnemyAttackChance(int change){
		enemyAttackChance += change;
		enemyAttackChance = Mathf.Clamp(enemyAttackChance, 0, 100);	
	}

	public void clickOption(){
		Debug.Log("clicked");
	}

}
