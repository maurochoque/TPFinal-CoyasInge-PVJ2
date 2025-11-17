using UnityEngine;
using TMPro;
using Cinemachine;

public class HeroKnightPS : MonoBehaviour
{
    //[SerializeField] private float m_speed = 5.0f;
    //[SerializeField] private float m_jumpForce = 12.0f;
    //[SerializeField] private Transform hero;

    private MovementController movementController;
    private AnimationController animationController;
    private HealthController healthController;
    private AttackController attackController;
    private BlockController blockController;


    void Start()
    {
        movementController = GetComponent<MovementController>();
        animationController = GetComponent<AnimationController>();
        healthController = GetComponent<HealthController>();
        attackController = GetComponent<AttackController>();
        blockController = GetComponent<BlockController>();

        var vCam = FindObjectOfType<CinemachineVirtualCamera>();
        vCam.Follow = transform;
        vCam.LookAt = transform;

    }

    void Update()
    {

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

