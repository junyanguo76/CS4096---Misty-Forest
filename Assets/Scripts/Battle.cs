using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static Battle instance;
    public enum StatusList
    {
        Normal, Healing, Bleeding, DecreaseDefence, IncreaseDefense,
        IncreaseAttack, DecreaseAttack, Stone
    };

    public List<Character> heroList = new List<Character>();
    public List<Character> monsterList = new List<Character>();

    public Character SelectedCharacter;

    public void AliveJudgement(Character character)
    {
        if (character.HP <= 0)
        {
            character.Die();
        }
    }
    private void Awake()
    {
        instance = this;
        StartCoroutine(ShowTheFirstCharacterInfo());


        
    }
    private void Start()
    {

    }

    private void Update()
    {
        if(heroList.Find(c => c.SkillSettled == false) == null)
        {
            StartCoroutine(StartBattle());
        }
    }
    IEnumerator ShowTheFirstCharacterInfo()
    {
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance.ChangeCharacterInfo(heroList[0]);
        UIManager.Instance.ChangeCharacterInfo(monsterList[0]);
        yield break;
    }


    IEnumerator StartBattle()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaa");

        foreach(Character character in heroList)
        {
            character.PerformingSkill(character.SelectedSkill, character.SelectedSkill.targetCharacter);
            UIManager.Instance.ChangeCharacterInfo(character.SelectedSkill.targetCharacter);
            AliveJudgement(character.SelectedSkill.targetCharacter);
            character.SkillSettled = false;
            character.SelectedSkill = null;
        }
        yield return new WaitForSeconds(0.1f);
    }
}
