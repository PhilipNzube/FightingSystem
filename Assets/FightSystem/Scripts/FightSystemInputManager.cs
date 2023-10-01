using UnityEngine;

public class FightSystemInputManager : MonoBehaviour
{
    public FightSystemConfig combatConfig;
    private ICombatController fightSystemControls;

    void Start()
    {
        fightSystemControls = GetComponent<ICombatController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(combatConfig.inputKey))
        {
            fightSystemControls.Attack();
        }
    }

}
