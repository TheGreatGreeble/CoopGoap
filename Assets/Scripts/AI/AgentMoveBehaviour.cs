using UnityEngine;
using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using Unity.AI;
using UnityEngine.AI;

public class AgentMoveBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.5f;
    private AgentBehaviour agent;
    private ITarget currentTarget;
    private bool shouldMove;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        this.agent = this.GetComponent<AgentBehaviour>();
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.updateRotation = false;
        navAgent.updateUpAxis = false;
        navAgent.autoBraking = true;
        navAgent.speed = moveSpeed;
    }

    private void OnEnable()
    {
        this.agent.Events.OnTargetInRange += this.OnTargetInRange;
        this.agent.Events.OnTargetChanged += this.OnTargetChanged;
        this.agent.Events.OnTargetOutOfRange += this.OnTargetOutOfRange;
    }

    private void OnDisable()
    {
        this.agent.Events.OnTargetInRange -= this.OnTargetInRange;
        this.agent.Events.OnTargetChanged -= this.OnTargetChanged;
        this.agent.Events.OnTargetOutOfRange -= this.OnTargetOutOfRange;
    }

    private void OnTargetInRange(ITarget target)
    {
        this.shouldMove = false;
        navAgent.isStopped = true;
    }

    private void OnTargetChanged(ITarget target, bool inRange)
    {
        this.currentTarget = target;
        this.shouldMove = !inRange;
    }

    private void OnTargetOutOfRange(ITarget target)
    {
        this.shouldMove = true;
        navAgent.isStopped = false;
    }

    public void Update()
    {
        if (!this.shouldMove){
            return;
        }
        
        if (this.currentTarget == null)
            return;
        
        navAgent.SetDestination(currentTarget.Position);
        // this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.currentTarget.Position.x, this.currentTarget.Position.y, this.currentTarget.Position.z), Time.deltaTime * moveSpeed);
    }
}