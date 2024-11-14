using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public List<Sprite> skillAList = new List<Sprite>();
    public List<Sprite> skillBList = new List<Sprite>();
    public List<Sprite> skillCList = new List<Sprite>();

    public Image skillA;
    public Image skillB;
    public Image skillC;


    public List<Skill> SkillList = new List<Skill>();

    public TextMeshProUGUI heroInfo;
    public TextMeshProUGUI monsterInfo;




    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacterInfo(Character character)
    {
        switch (character.characterType)
        {
            case Character.CharacterType.Hero:
                int temp = 0;
                switch (character.characterName)
                {
                    case Character.CharacterName.Knight:
                    break;
                    case Character.CharacterName.Assassin:
                        temp++;
                        break;
                    case Character.CharacterName.Warrior:
                        temp += 2;
                        break;
                    case Character.CharacterName.Wizard:
                        temp += 3;
                        break;
                }
                skillA.sprite = skillAList[temp];
                skillB.sprite = skillBList[temp];
                skillC.sprite = skillCList[temp];

                heroInfo.text = character.name + "\nHP: " + character.HP + "/" +character.MaxHP
                    + "\nSpeed: " + character.Speed + "\nDefense: " + character.Defense
                    + "\nStatus: " + character.Status;
                SkillList = character.SkillList;

                break;

            case Character.CharacterType.Monster:
                monsterInfo.text = character.name + "\nHP: " + character.HP + "/" + character.MaxHP
                    + "\nSpeed: " + character.Speed + "\nDefense: " + character.Defense
                    + "\nStatus: " + character.Status;
                break;

        }
    }

    public void PressSkillA()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[0];
    }
    public void PressSkillB()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[1];
    }
    public void PressSkillC()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[2];
    }

}
