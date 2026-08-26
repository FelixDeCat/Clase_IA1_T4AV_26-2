using UnityEngine;
using IA1.DesitionTreeCSharpNative;

public class Enemy : MonoBehaviour
{
    [SerializeField] IA1.DesitionTreeUnity.Core.Node firstNode;
    //Node first;



    [Header("CanSeePlayer")]
    [SerializeField] float minDistToSee = 10f;
    [SerializeField] float minDistToAttack = 2f;


    void Start()
    {
        
        //NodeExecute patrol = new NodeExecute(PatrolAction);
        //NodeExecute attack = new NodeExecute(AttackAction);
        //NodeExecute follow = new NodeExecute(FollowAction);

        //NodeQuestion inRange = new NodeQuestion(PlayerIsInRange, attack, follow);

        //first = new NodeQuestion(CanSeePlayer, inRange, patrol);

        //NodeExecute patrol = new NodeExecute(() => print("Estoy patruyando"));
        //NodeExecute attack = new NodeExecute(() =>
        //{
        //    print("me acerco");
        //    print("anticipacion");
        //    print("atack");
        //    print("recoil");
        //}
        //);
        //NodeExecute follow = new NodeExecute(FollowAction);

        //NodeQuestion inRange = new NodeQuestion(
        //    () =>
        //    {
        //        Vector3 dir = Player.Position - transform.position;
        //        return dir.sqrMagnitude < minDistToSee * minDistToSee;
        //    }
        //    , attack, follow);

        //first = new NodeQuestion(CanSeePlayer, inRange, patrol);
    }

    void Update()
    {
        firstNode.Execute();

        //first.Execute();
    }



    public bool CanSeePlayer()
    {
        Vector3 dir = Player.Position - transform.position;
        return dir.sqrMagnitude < minDistToSee * minDistToSee;
    }


    void PatrolAction()
    {
        print("Estoy patruyando");
    }
    void AttackAction()
    {
        print("Estoy atacando");
    }
    void FollowAction()
    {
        print("Estoy siguiendo");
    }
}
