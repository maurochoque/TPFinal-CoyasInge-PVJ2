using UnityEngine;
using Mirror;
using TMPro;
using Cinemachine;

public class HeroKnightPS : NetworkBehaviour
{
    //[SerializeField] private float m_speed = 5.0f;
    //[SerializeField] private float m_jumpForce = 12.0f;
    //[SerializeField] private Transform hero;
    [SerializeField] private TextMeshProUGUI nameDisplay = null;

    private MovementController movementController;
    private AnimationController animationController;
    private HealthController healthController;
    private AttackController attackController;
    private BlockController blockController;

    [SyncVar(hook = nameof(OnNickNameChange))]
    private string nickName = "";

    void Start()
    {
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<AnimationController>();
        healthController = GetComponent<HealthController>();
        attackController = GetComponent<AttackController>();
        blockController = GetComponent<BlockController>();

        if (isLocalPlayer)
        {
            var vCam = FindObjectOfType<CinemachineVirtualCamera>();
            vCam.Follow = transform;
            vCam.LookAt = transform;
        }
    }

    public void SetNickName(string name)
    {
        nickName = name;
    }

    private void OnNickNameChange(string oldName, string newName)
    {
        nameDisplay.text = newName;
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        movementController.HandleMovement();

        animationController.UpdateAnimations(
            movementController.IsGrounded,
            movementController.InputX
        );

        animationController.TriggerSlide(movementController.IsWallSliding);

        attackController.HandleAttack();

        blockController.Bloquear();
    }
  
}

