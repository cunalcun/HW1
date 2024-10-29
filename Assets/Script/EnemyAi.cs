using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum EnemyState { Normal, Angry, Chase }
    private EnemyState currentState = EnemyState.Normal;

    public float normalMoveSpeed = 0.5f;
    public float angryMoveSpeed = 4f;
    public float chaseMoveSpeed = 1.5f;
    public float changeDirectionTime = 2f;
    public LayerMask playerLayer;
    public LayerMask baseLayer;

    public GameObject angryParticlePrefab;
    public GameObject chaseParticlePrefab;

    private GameObject angryParticleInstance;
    private GameObject chaseParticleInstance;

    private Transform playerTarget;
    private Transform baseTarget;
    private Vector3 moveDirection;
    private float stateTimer = 0f;
    private float directionTimer = 0f;
    void Start()
    {
        playerTarget = FindObjectByLayer(playerLayer);
        baseTarget = FindObjectByLayer(baseLayer);
        SetRandomDirection();

        angryParticleInstance = Instantiate(angryParticlePrefab, transform);
        chaseParticleInstance = Instantiate(chaseParticlePrefab, transform);

        var angryMain = angryParticleInstance.GetComponent<ParticleSystem>().main;
        angryMain.scalingMode = ParticleSystemScalingMode.Local;

        var chaseMain = chaseParticleInstance.GetComponent<ParticleSystem>().main;
        chaseMain.scalingMode = ParticleSystemScalingMode.Local;

        angryParticleInstance.transform.localPosition = Vector3.zero;
        chaseParticleInstance.transform.localPosition = Vector3.up;

        angryParticleInstance.SetActive(false);
        chaseParticleInstance.SetActive(false);
    }
    void Update()
    {
        stateTimer += Time.deltaTime;

        switch (currentState)
        {
            case EnemyState.Normal:
                NormalState();
                break;
            case EnemyState.Angry:
                AngryState();
                break;
            case EnemyState.Chase:
                ChaseState();
                break;
        }
    }

    private void NormalState()
    {
        directionTimer += Time.deltaTime;
        if (directionTimer >= changeDirectionTime)
        {
            SetRandomDirection();
            directionTimer = 0f;
        }

        MoveInDirection(normalMoveSpeed);

        if (stateTimer >= 5f) EnterChaseState();
    }

    private void AngryState()
    {
        if (playerTarget != null)
        {
            MoveTowards(playerTarget.position, angryMoveSpeed);
        }

        if (stateTimer >= 5f) EnterNormalState();
    }

    private void ChaseState()
    {
        if (baseTarget != null)
        {
            MoveTowards(baseTarget.position, chaseMoveSpeed);
        }
    }

    private void EnterNormalState()
    {
        currentState = EnemyState.Normal;
        ResetParticles();
        ResetStateTimer();
    }

    private void EnterAngryState()
    {
        currentState = EnemyState.Angry;
        ResetParticles();
        angryParticleInstance.SetActive(true);
        ResetStateTimer();
    }

    private void EnterChaseState()
    {
        currentState = EnemyState.Chase;
        ResetParticles();
        chaseParticleInstance.SetActive(true);
        ResetStateTimer();
    }

    private void ResetParticles()
    {
        angryParticleInstance.SetActive(false);
        chaseParticleInstance.SetActive(false);
    }

    private void MoveInDirection(float speed)
    {
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        RotateTowards(moveDirection);
    }

    private void MoveTowards(Vector3 target, float speed)
    {
        Vector3 direction = new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z).normalized;
        transform.position += direction * speed * Time.deltaTime;
        RotateTowards(direction);
    }

    private void RotateTowards(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }

    private void SetRandomDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        RotateTowards(moveDirection);
    }

    private Transform FindObjectByLayer(LayerMask layerMask)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 100f, layerMask);
        return colliders.Length > 0 ? colliders[0].transform : null;
    }

    private void ResetStateTimer()
    {
        stateTimer = 0f;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            EnterAngryState();
        }
    }
}

