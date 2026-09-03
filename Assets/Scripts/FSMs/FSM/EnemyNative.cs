using IA1.MonoFSM;
using UnityEngine;

public class EnemyNative : MonoBehaviour
{
    FSM fsm;

    public const string INPUT_SeeEnemy = "SeeEnemy";
    public const string INPUT_EnemyAttackMe = "EnemyAttackme";
    public const string INPUT_Calm = "calm";
    public const string INPUT_EnemyInRange = "EnemyInRange";

    void Start()
    {
        // crear los estados
        Idle idle = new Idle("Idle");
        Run run = new Run("Run");
        Attack attack = new Attack("Attack", DebugState);

        // crear conexiones
        idle.AddTransition(INPUT_SeeEnemy, run);
        idle.AddTransition(INPUT_EnemyAttackMe, attack);

        run.AddTransition(INPUT_Calm, idle);
        run.AddTransition(INPUT_EnemyInRange, attack);

        //attack.AddTransition(INPUT_Calm, idle);
        //attack.AddTransition(INPUT_EnemyInRange, attack);



        // creo FSM, y le paso la Semilla (First)
        fsm = new FSM(idle);
    }

    void SendINput(string input) // SeeEnemy
    {
        if (fsm != null)
        {
            fsm.SendInput(input);
        }
    }

    void Update()
    {
        if (fsm != null)
        {
            fsm.UpdateFSM();
        }


        if (Input.GetKeyDown(KeyCode.T))
        {
            SendINput(INPUT_SeeEnemy);
        }
    }

    void DebugState(string msg)
    {
        Debug.Log("<color=cyan>state:</color> " + msg);
    }
}
