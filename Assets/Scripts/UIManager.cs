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


    public TextMeshProUGUI NameH;
    public TextMeshProUGUI HPH;
    public TextMeshProUGUI SpeedH;
    public TextMeshProUGUI Defence;
    public TextMeshProUGUI Status;



    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        NameH.text = "knight" ;
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
                switch (character.characterName)
                {
                    case Character.CharacterName.KnightM:
                        skillA.sprite = skillAList[0];
                        skillB.sprite = skillBList[0];
                        skillC.sprite = skillCList[0];
                    break;
                    case Character.CharacterName.KnightF:
                        skillA.sprite = skillAList[1];
                        skillB.sprite = skillBList[1];
                        skillC.sprite = skillCList[1];
                        break;
                }
                break;
        }
    }
}
