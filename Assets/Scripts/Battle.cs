using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        StartCoroutine(ShowTheFirstCharacterInfo());
        
    }

    IEnumerator ShowTheFirstCharacterInfo()
    {
        yield return new WaitForSeconds(0.1f);
        UIManager.Instance.ChangeCharacterInfo(heroList[0]);
        UIManager.Instance.ChangeCharacterInfo(monsterList[0]);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
