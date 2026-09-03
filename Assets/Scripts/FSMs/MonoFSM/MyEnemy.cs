using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    [SerializeField] IA1.MonoFSM.MonoFSM _fsm;
    [SerializeField] IA1.MonoFSM.State first; // Idle


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _fsm.SetFirst(first);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _fsm.SendInput("seePlayer");
        }

        if (Input.GetKeyDown(KeyCode.Y)) //estoy en run
        {
            _fsm.SendInput("calm");
        }

        if (Input.GetKeyDown(KeyCode.U)) // se supone que estoy en IDle
        {
            _fsm.SendInput("playerAttackMe");
        }
        if (Input.GetKeyDown(KeyCode.I)) // se supone que estoy en IDle
        {
            _fsm.SendInput("EnemyDeath");
        }
    }
}
