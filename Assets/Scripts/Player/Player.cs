using System;
using UnityEngine;

public class Player : MonoBehaviour {
    private BoxCollider groundCollider;
    private PlayerControls m_controls;
    private PlayerInteraction m_interaction;
    private PlayerSounds m_sounds;

    [SerializeField] private int m_health;
    [SerializeField] private int m_maxHealth;
    [SerializeField] private int m_stamina;
    [SerializeField] private int m_maxStamina;
    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_jumpPower;

    [SerializeField] private float jumpCheckDistance;
    [SerializeField] private LayerMask whatIsGround;



    #region Properties

    public int health {
        get => m_health;
        set => m_health = Mathf.Clamp(value, 0, maxHealth);
    }

    public int maxHealth {
        get => m_maxHealth;
    }

    public int stamina {
        get => m_stamina;
        set => m_stamina = Mathf.Clamp(value, 0, maxStamina);
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

    public PlayerControls controls {
        get => m_controls;
    }

    public PlayerInteraction interaction {
        get => m_interaction;
    }

    public PlayerSounds sounds {
        get => m_sounds;
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
        m_controls = GetComponent<PlayerControls>();
        m_interaction = GetComponent<PlayerInteraction>();
        m_sounds = GetComponent<PlayerSounds>();
    }

    private void OnDestroy() {
        Global.player = null;
    }
}
