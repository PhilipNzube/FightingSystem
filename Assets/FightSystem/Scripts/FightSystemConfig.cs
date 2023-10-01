using UnityEngine;

[CreateAssetMenu(menuName = "Combat Move")]
public class FightSystemConfig : ScriptableObject
{
    public string attackType;
    public float damage;
    public KeyCode inputKey;
    public string animationParameter;
}
