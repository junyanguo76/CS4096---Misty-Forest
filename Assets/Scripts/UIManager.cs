using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.TextCore.Text;

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

    private string CharacterStatusList;


    void Start()
    {
        Instance = this;

    }

    public void ChangeCharacterInfo(Character character)
    {
        CharacterStatusList = null;
        foreach (Status status in character.StatusList)
        {
            if(status.statusType != Status.StatusList.Normal)
            {
                CharacterStatusList += status.statusType + " ";
            }
        }
        bool haveStatus = new bool();
        foreach (Status status in character.StatusList)
        {
            if(status.statusType != Status.StatusList.Normal) haveStatus = true;
        }
        if (haveStatus == false) CharacterStatusList = "Normal";
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
                    + "\nStatus: " + CharacterStatusList;
                SkillList = character.SkillList;

                break;

            case Character.CharacterType.Monster:
                monsterInfo.text = character.name + "\nHP: " + character.HP + "/" + character.MaxHP
                    + "\nSpeed: " + character.Speed + "\nDefense: " + character.Defense
                    + "\nStatus: " + CharacterStatusList;
                break;

        }
    }

    public void PressSkillA()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[0];
        Battle.instance.SelectedCharacter.skillSelected = true;
    }
    public void PressSkillB()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[1];
        Battle.instance.SelectedCharacter.skillSelected = true;
    }
    public void PressSkillC()
    {
        Battle.instance.SelectedCharacter.SelectedSkill = SkillList[2];
        Battle.instance.SelectedCharacter.skillSelected = true;
    }

}
