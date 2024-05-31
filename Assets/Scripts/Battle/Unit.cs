using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

	public string unitName;
	public string unitHPname;

	public int damage;

	public int maxHP;
	public int currentHP;
	public string[] taunts;
	public string[] failSentences;

	public bool TakeDamage(int dmg)
	{
		currentHP -= dmg;

		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	public void Heal(int amount)
	{
		currentHP += amount;
		if (currentHP > maxHP)
			currentHP = maxHP;
	}

	public string[] GetTaunts(){
		if(taunts != null){
			return taunts;
		}
		string[] empty = new string[1];
		empty[0] = "...";
		return empty;
	}

		public string[] GetFailTaunts(){
		if(failSentences != null){
			return failSentences;
		}
		string[] empty = new string[1];
		empty[0] = "...";
		return empty;
	}

}
