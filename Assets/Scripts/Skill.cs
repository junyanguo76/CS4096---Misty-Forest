using UnityEngine;


public class Skill : MonoBehaviour
{
    public int Damage { get; set; }
    public int OrignalDamage { get; set; }
    public string Name { get; set; }
    public Status status = new Status();
    public Character targetCharacter;
    public enum SkillType { Normal,BuffSkill,DebuffSkill}
    public SkillType skillType;
    public void SkillEffect(Character targetCharacter)
    {
        targetCharacter.HP -= (int)(Damage * (10 - targetCharacter.Defense)/10);
        targetCharacter.StatusList.Add(this.status);
        Battle.instance.BuffCheck(targetCharacter);
    }

    private void Start()
    {
        OrignalDamage = Damage;
    }
}
