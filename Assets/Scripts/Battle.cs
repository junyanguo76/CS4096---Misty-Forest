using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public static Battle instance;
    public enum AIStrategyList { Attack,Defense}
    AIStrategyList AIStrategy;
    public enum StatusList
    {
        Normal, Healing, Bleeding, DecreaseDefence, IncreaseDefense,
        IncreaseAttack, DecreaseAttack, Stone
    };

    public List<Character> heroList = new List<Character>();
    public List<Character> monsterList = new List<Character>();
    public List<Character> characterList = new List<Character>();

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

    private void SpeedSorting()
    {
        characterList.Clear();
        characterList.AddRange(heroList);
        characterList.AddRange(monsterList);
        for(int n = 0; n < characterList.Count; n++)
        {
            for(int i = 0; i < characterList.Count; i++)
            {   
                if(n == i)
                {
                    break;
                }
                else if (characterList[n].Speed > characterList[i].Speed)
                {
                    Character tempCharacter = characterList[n];
                    characterList[n] = characterList[i];
                    characterList[i] = tempCharacter;
                }
            }
        }
    }


    private Skill AISkillSelecting(Character character)
    {

        character.SelectedSkill.targetCharacter = character;
        return character.SelectedSkill;
    }

    private void AIStrategySelecting()
    {
        double heroTotalHP = 0;
        double monsterTotalHP = 0;
        foreach(Character character in heroList)
        {
            heroTotalHP += character.HP;
        }
        foreach(Character character in monsterList)
        {
            monsterTotalHP += character.HP;
        }
        double proportion = heroTotalHP / monsterTotalHP;
        if(proportion <= 0.8)
        {
            AIStrategy = AIStrategyList.Attack;
        }
        else if(proportion > 0.8 && proportion < 1.2)
        {
            AIStrategy = AIStrategyList.Defense;
        }
        else if(proportion > 1.2 && proportion < 1.8)
        {
            AIStrategy = AIStrategyList.Attack;
        }
        else if(proportion > 1.8)
        {
            AIStrategy = AIStrategyList.Attack;
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
        SpeedSorting();

        foreach(Character character in characterList)
        {
            if(character.characterType == Character.CharacterType.Hero)
            {
                character.PerformingSkill(character.SelectedSkill, character.SelectedSkill.targetCharacter);
                UIManager.Instance.ChangeCharacterInfo(character.SelectedSkill.targetCharacter);
                AliveJudgement(character.SelectedSkill.targetCharacter);
                character.SkillSettled = false;
                character.SelectedSkill = null;
            }
            else
            {
                character.PerformingSkill(AISkillSelecting(character), AISkillSelecting(character).targetCharacter);
            }

        }
        yield return new WaitForSeconds(0.1f);
    }
}
