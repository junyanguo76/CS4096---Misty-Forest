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

                heroInfo.text = character.name + "\nHP: " + character.HP
                    + "\nSpeed: " + character.Speed + "\nDefense: " + character.Defense
                    + "\nStatus: " + character.Status;

                break;

            case Character.CharacterType.Monster:
                monsterInfo.text = character.name + "\nHP: " + character.HP
                    + "\nSpeed: " + character.Speed + "\nDefense: " + character.Defense
                    + "\nStatus: " + character.Status;
                break;

        }
    }
}
