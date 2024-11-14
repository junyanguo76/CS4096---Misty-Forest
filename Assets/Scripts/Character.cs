using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Battle;

public class Character : MonoBehaviour
{
    public enum CharacterName { Knight,Assassin,Warrior,Wizard,Mushroom,Skeleton,Goblin,Flyeye}
    public enum CharacterType { Hero,Monster}
    public CharacterName characterName;
    public CharacterType characterType;

    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Speed { get; set; }
    public float Defense { get; set; }
    public bool HasMoved { get; set; }
    public bool SkillSettled { get; set; }
    public StatusList Status { get; set; }
    public Skill SkillA { get; set; }
    public Skill SkillB { get; set; }
    public Skill SkillC { get; set; }
    public Skill SelectedSkill;
    

    public List<Skill> SkillList  = new List<Skill>();
    
    public void PerformingSkill(Skill skill, Character character)
    {
        skill.SkillEffect(character);
    }
    public void Die()
    {
        Destroy(this.gameObject);

    }

    private void OnMouseDown()
    {
        UIManager.Instance.ChangeCharacterInfo(this);
        if (characterType == CharacterType.Hero && SkillSettled == false)
        {
            Battle.instance.SelectedCharacter = this;
            Debug.Log("You select this character" + this.name);
        }
        else if(characterType == CharacterType.Monster)
        {
            Battle.instance.SelectedCharacter.SelectedSkill.targetCharacter = this;
            Debug.Log("Your skill points to this monster" + this.name);
            Battle.instance.SelectedCharacter.SkillSettled = true;
        }



        //if(Battle.instance.userSelectedSkill != null)
        //{
        //    PerformingSkill(Battle.instance.userSelectedSkill, this);
        //}
        
    }
    public void Start()
    {
        SkillA = new Skill();
        SkillB = new Skill();
        SkillC = new Skill();
        SkillList.Add(SkillA);
        SkillList.Add(SkillB);
        SkillList.Add(SkillC);

        Status = StatusList.Normal;
        HasMoved = false;
        SkillSettled = false;
        switch (characterName)
        {
            case CharacterName.Knight:
                HP = 24; 
                MaxHP = 24;
                Speed = 5;
                Defense = 0.2f;
                characterType = CharacterType.Hero;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;



            case CharacterName.Assassin:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Hero;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;


            case CharacterName.Warrior:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Hero;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;


            case CharacterName.Wizard:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Hero;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;

            case CharacterName.Mushroom:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Monster;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;

            case CharacterName.Skeleton:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Monster;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;


            case CharacterName.Goblin:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Monster;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;


            case CharacterName.Flyeye:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Monster;

                SkillA.Name = "Oorah";
                SkillA.Damage = 0;
                SkillA.Status = StatusList.IncreaseDefense;

                SkillB.Name = "Chop";
                SkillB.Damage = 2;
                SkillB.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillC.Damage = 6;
                SkillC.Status = StatusList.Normal;
                break;

        }

        if (characterType == CharacterType.Hero)
        {
            Battle.instance.heroList.Add(this);
        }
        else
        {
            Battle.instance.monsterList.Add(this);
        }
    }
}
