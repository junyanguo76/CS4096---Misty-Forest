using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
public class Battle : MonoBehaviour
{
    public static Battle instance;
    public enum AIStrategyList { Attack,Defense}
    AIStrategyList AIStrategy;

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
    private void StatusTimer(Character character)
    {
        for(int n = 0; n < character.StatusList.Count; n ++)
        {
            character.StatusList[n].lastTime -= 1;
            if(character.StatusList[n].lastTime <= 0)
            {
                character.StatusList.Remove(character.StatusList[n]);
            }
        }
    }
    private void StatusCheck(Character character)
    {
        if (character.StatusList.Find(status => status.statusType == Status.StatusList.Healing))
        {
            character.HP += 3;
            if (character.HP > character.MaxHP) character.HP = character.MaxHP;
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.Bleeding))
        {
            character.HP -= 3;
            if (character.HP < 0) character.Die();
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.IncreaseAttack))
        {
            foreach (Skill skill in character.SkillList)
            {
                skill.Damage = (int)(skill.OrignalDamage * 1.5);
            }
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.DecreaseAttack))
        {
            foreach (Skill skill in character.SkillList)
            {
                skill.Damage = (int)(skill.OrignalDamage * 0.75);
            }
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.IncreaseDefense))
        {
            character.Defense = character.OrignalDefense + 2;
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.DecreaseDefence))
        {
            character.Defense = character.OrignalDefense - 2;
        }
    }
    public void BuffCheck(Character character)
    {
        if (character.StatusList.Find(status => status.statusType == Status.StatusList.IncreaseAttack))
        {
            foreach (Skill skill in character.SkillList)
            {
                skill.Damage = (int)(skill.OrignalDamage * 1.5);
            }
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.DecreaseAttack))
        {
            foreach (Skill skill in character.SkillList)
            {
                skill.Damage = (int)(skill.OrignalDamage * 0.75);
            }
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.IncreaseDefense))
        {
            character.Defense = character.OrignalDefense + 2;
        }
        else if (character.StatusList.Find(status => status.statusType == Status.StatusList.DecreaseDefence))
        {
            character.Defense = character.OrignalDefense - 2;
        }
    }
    private Skill AISkillSelecting(Character character)
    {
        character.SelectedSkill = character.SkillB;
        character.SelectedSkill.targetCharacter = character;
        return character.SelectedSkill;
    }
    private void ChangeStrategy(int n)
    {
        Debug.Log("the monsters will choose the strategy as " + AIStrategy);
        if(Random.Range(0, 10) < n)
        {
            AIStrategy = (AIStrategyList)(1 - (int)AIStrategy);
            Debug.Log("After some thought, the monsters decided to change their strategy.");
        }
        Debug.Log("After some thought, the monsters decided to maintain their current strategy.");
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
        Debug.Log("The ratio of the player team's total health to their own team's total health is " +
            monsterTotalHP + "/" + heroTotalHP + " = " + proportion );
        if (proportion <= 0.8)
        {
            AIStrategy = AIStrategyList.Attack;
            ChangeStrategy(3);
        }
        else if(proportion > 0.8 && proportion < 1.2)
        {
            AIStrategy = AIStrategyList.Defense;
            ChangeStrategy(4);
        }
        else if(proportion > 1.2 && proportion < 1.8)
        {
            AIStrategy = AIStrategyList.Attack;
            ChangeStrategy(3);
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
            StatusCheck(character);
            StatusTimer(character);
            if (character.characterType == Character.CharacterType.Hero)
            {
                character.PerformingSkill(character.SelectedSkill, character.SelectedSkill.targetCharacter);
                UIManager.Instance.ChangeCharacterInfo(character);
                UIManager.Instance.ChangeCharacterInfo(character.SelectedSkill.targetCharacter);
                AliveJudgement(character.SelectedSkill.targetCharacter);
                character.SkillSettled = false;
                character.SelectedSkill = null;
            }
            else
            {
                character.PerformingSkill(AISkillSelecting(character), AISkillSelecting(character).targetCharacter);
                AliveJudgement(character.SelectedSkill.targetCharacter);
            }
            yield return new WaitForSeconds(1f);
        }
        
    }
}
