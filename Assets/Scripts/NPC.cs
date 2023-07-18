using Assets.Scripts;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private NPCStateMachine _stateMachine;

    private void Awake() => _stateMachine = new NPCStateMachine(this);

    private void Update() => _stateMachine.UpdateFromStateMachine();
}
