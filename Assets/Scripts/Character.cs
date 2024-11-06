using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Battle;

public class Character : MonoBehaviour
{
    public enum CharacterName { KnightM,KnightF,Warrior,Wizard}
    public enum CharacterType { Hero,Monster}
    public CharacterName characterName;
    public CharacterType characterType;

    public int HP { get; set; }
    public int MaxHP { get; set; }
    public int Speed { get; set; }
    public float Defense { get; set; }
    public StatusList Status { get; set; }

    List<Skill> SkillList { get; set; } = new List<Skill>();
    void PerformingSkill(Skill skill, Character character)
    {
        skill.SkillEffect(character);
    }

    Skill skillA = new Skill();
    Skill skillB = new Skill();
    Skill skillC = new Skill();
    private void OnMouseDown()
    {
        UIManager.Instance.ChangeCharacterInfo(this);
    }
    public void Start()
    {
        switch (characterName)
        {
            case CharacterName.KnightM:
                HP = 24; 
                MaxHP = 24;
                Speed = 5;
                Defense = 0.2f;
                characterType = CharacterType.Hero;

                skillA.Name = "Oorah";
                skillA.Damage = 0;
                skillA.Status = StatusList.IncreaseDefense;

                skillB.Name = "Chop";
                skillA.Damage = 2;
                skillA.Status = StatusList.Stone;

                skillC.Name = "Punches";
                skillA.Damage = 6;
                skillA.Status = StatusList.Null;
                break;

            case CharacterName.KnightF:
                HP = 20;
                MaxHP = 20;
                Speed = 8;
                Defense = 0;
                characterType = CharacterType.Hero;

                skillA.Name = "Oorah";
                skillA.Damage = 0;
                skillA.Status = StatusList.IncreaseDefense;

                skillB.Name = "Chop";
                skillA.Damage = 2;
                skillA.Status = StatusList.Stone;

                skillC.Name = "Punches";
                skillA.Damage = 6;
                skillA.Status = StatusList.Null;
                break;
        }
    }
}
