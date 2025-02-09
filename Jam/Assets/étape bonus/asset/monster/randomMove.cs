using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Camera playerCamera;
    public Camera monsterCamera;
    private bool isKilling = false;
    public Transform cameraAnchor;
    public float detectionRange = 10f;
    public float visionAngle = 60f;
    public float wanderRange = 10f;
    public float idleSpeed = 2f;
    public float chaseSpeed = 5f;
    public GameObject gameOverScreen;
    private Animator animator;
    private Vector3 wanderTarget;
    private bool isPlayerInSight = false;
    private Vector3 lastPlayerPosition;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Wander();
        gameOverScreen.SetActive(false);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 1.5f && !isKilling)
        {
            StartKillSequence();
        }

        if (IsPlayerInSight() && distanceToPlayer <= detectionRange)
        {
            isPlayerInSight = true;
            if (IsPlayerRunning())
            {
                ChasePlayer(true);
            }
            else
            {
                ChasePlayer(false);
            }
        }
        else if (!IsPlayerInSight() && IsPlayerRunning())
        {
            MoveToLastPlayerPosition();
        }
        else if (isPlayerInSight && distanceToPlayer > detectionRange)
        {
            isPlayerInSight = false;
            Wander();
        }
        else if (!isPlayerInSight)
        {
            Wander();
        }

        if (Vector3.Distance(transform.position, wanderTarget) < 2f && !isPlayerInSight)
        {
            Wander();
        }
    }

    void StartKillSequence()
    {
        isKilling = true;
        agent.isStopped = true;
        animator.SetBool("isKill", true);

        player.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(false);
        monsterCamera.gameObject.SetActive(true);

        StartCoroutine(ShowGameOverScreenAndReload());
    }

    IEnumerator ShowGameOverScreenAndReload()
    {
        yield return new WaitForSeconds(1f);
        gameOverScreen.SetActive(true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerCamera.gameObject.SetActive(true);
        monsterCamera.gameObject.SetActive(false);
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRange;
        randomDirection += transform.position;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRange, 1))
        {
            wanderTarget = hit.position;
            agent.SetDestination(wanderTarget);
            animator.SetBool("isWalking", true);
            agent.speed = idleSpeed;
        }
    }

    bool IsPlayerInSight()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float angle = Vector3.Angle(transform.forward, directionToPlayer);

        if (angle < visionAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool IsPlayerRunning()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    void ChasePlayer(bool isRunning)
    {
        agent.SetDestination(player.position);
        agent.speed = isRunning ? chaseSpeed : idleSpeed;
        animator.SetBool("isWalking", true);
    }

    void MoveToLastPlayerPosition()
    {
        if (lastPlayerPosition != Vector3.zero)
        {
            agent.SetDestination(lastPlayerPosition);
            agent.speed = idleSpeed;
            animator.SetBool("isWalking", true);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Vector3 left = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * detectionRange;
        Vector3 right = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * detectionRange;
        Gizmos.DrawLine(transform.position, transform.position + left);
        Gizmos.DrawLine(transform.position, transform.position + right);
    }
}
