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
    public StatusList Status { get; set; }
    Skill SkillA { get; set; }
    Skill SkillB { get; set; }
    Skill SkillC { get; set; }


    List<Skill> SkillList { get; set; } = new List<Skill>();
    void PerformingSkill(Skill skill, Character character)
    {
        skill.SkillEffect(character);
    }


    private void OnMouseDown()
    {
        UIManager.Instance.ChangeCharacterInfo(this);
    }
    public void Start()
    {
        SkillA = new Skill();
        SkillB = new Skill();
        SkillC = new Skill();


        Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
                SkillA.Damage = 2;
                SkillA.Status = StatusList.Stone;

                SkillC.Name = "Punches";
                SkillA.Damage = 6;
                SkillA.Status = StatusList.Normal;
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
