using UnityEngine;
using static Battle;

public class Skill : MonoBehaviour
{
    public int Damage { get; set; }
    public string Name { get; set; }
    public StatusList Status { get; set; }
    public Character targetCharacter;
    public void SkillEffect(Character targetCharacter)
    {
        targetCharacter.HP -= Damage;
        targetCharacter.Status = Status;
    }

}
