using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public Slider hpSlider;
	public TextMeshProUGUI hpName;

	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		hpName.text = unit.unitHPname;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
	}

}
