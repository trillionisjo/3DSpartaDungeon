using System;
using UnityEngine;

public class Player : MonoBehaviour {
    private BoxCollider groundCollider;

    [SerializeField] private int m_health;
    [SerializeField] private int m_maxHealth;
    [SerializeField] private int m_stamina;
    [SerializeField] private int m_maxStamina;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpPower;

    [SerializeField] private float jumpCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public event Action Jumped;

    #region Properties

    public int health {
        get => m_health;
        private set => m_health = Mathf.Clamp(value, 0, maxHealth);
    }

    public int maxHealth {
        get => m_maxHealth;
    }

    public int stamina {
        get => m_stamina;
        private set => m_stamina = Mathf.Clamp(value, 0, maxHealth);
    }

    public int maxStamina {
        get => m_maxStamina;
    }

    public float moveSpeed {
        get => m_moveSpeed;
    }

    public float jumpPower {
        get => m_jumpPower;
    }

    public bool isDead {
        get => health == 0;
    }

    public bool isGrounded {
        get {
            bool isHit = Physics.BoxCast(
                center: groundCollider.bounds.center,
                halfExtents: groundCollider.bounds.extents,
                direction: Vector3.down,
                orientation: Quaternion.identity,
                maxDistance: jumpCheckDistance, whatIsGround);
            return isHit;
        }
    }

    #endregion

    private void Awake() {
        Global.player = this;
        groundCollider = GetComponentInChildren<BoxCollider>();
    }

    private void OnDestroy() {
        Global.player = null;
    }

    private void Start() {
        health = maxHealth;
        stamina = maxStamina;
    }
}
