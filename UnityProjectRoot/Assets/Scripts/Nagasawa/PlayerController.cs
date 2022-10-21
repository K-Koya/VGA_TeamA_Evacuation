using UnityEngine;

/// <summary>
/// �v���C���[�𓮂����R���|�[�l���g
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Tooltip("�ړ��p�^�[���̐��� Velocity�͂�������,AddForce�̓X�[�b��"), SerializeField]
    PlayerMovePatternTest _movePattern;

    [Tooltip("�v���C���[�̃X�s�[�h"), SerializeField]
    float _playerSpeed = 5.0f;

    [Tooltip("�v���C���[�̈ړ����͂ɑ΂���Ǐ]�x�APlayerSpeed�ɏ��� AddForce�̂�"), SerializeField]
    float _playerSpeedMultiply = 5.0f;

    [Tooltip("�X�s�[�h�̏�� AddForce�̂�"), SerializeField]
    float _maximizePlayerSpeed = 5.0f;

    [Tooltip("�W�����v��"), SerializeField]
    float _playerJumpSpeed = 3.0f;

    [Tooltip("�n�ʂ̃��C���["), SerializeField]
    LayerMask _groundLayer;

    [Tooltip("�ݒu������������邩�ǂ���")]
    bool _isGroundDebug = true;

    [Tooltip("�ݒu����̃T�C�Y"), SerializeField]
    Vector3 _groundCollisionSize;

    [Tooltip("�v���C���[�̒��S�_"), SerializeField]
    Vector3 _playerCentor;

    [Tooltip("�n�ʂɂ���Ƃ��̏d��"), SerializeField]
    float _groundDrag = 0f;

    [Tooltip("�󒆂ɂ���Ƃ��̏d��"), SerializeField]
    float _airDrag = 0f;

    Vector3 _centor;

    Rigidbody _rb;

    void Start()
    {
        SetUp();
    }

    /// <summary>
    /// Start�ōs�������Z�b�g�A�b�v
    /// </summary>
    void SetUp()
    {
        if (!TryGetComponent(out _rb))
        {
            _rb = gameObject.AddComponent<Rigidbody>();
        }

        //Contains��RotationX,Z���Œ�
        _rb.constraints = (RigidbodyConstraints)80;
    }

    void Update()
    {
        PlayerState();
        ControlDrag();
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    /// <summary>
    /// Player�̈ړ����@�����肷��X�e�[�g
    /// </summary>
    void PlayerMove()
    {
        switch (_movePattern)
        {
            case PlayerMovePatternTest.Velocity:
                VelocityMove();
                break;
            case PlayerMovePatternTest.AddForce:
                AddForceMove();
                break;
            default:
                Debug.LogError("�ړ��p�^�[�����w�肵�Ă�������");
                break;
        }
    }

    /// <summary>
    /// Rigidbody��velocity���g���Ĉړ�������B
    /// ����������������
    /// </summary>
    void VelocityMove()
    {
        Vector3 dir = PlayerVec(InputUtility.GetDirectionMove);
        _rb.velocity = dir;
    }

    /// <summary>
    /// Rigidbody��AddForce���g���ړ�����B
    /// �X�[�b�Ɠ����āA�X�[�b�Ǝ~�܂�B�Ǐ]�x�ݒ�\�B
    /// </summary>
    void AddForceMove()
    {
        if (_rb.velocity.magnitude <= _maximizePlayerSpeed)
        {
            Vector3 dir = PlayerVec(InputUtility.GetDirectionMove);
            _rb.AddForce(_playerSpeedMultiply * (dir - _rb.velocity));
        }
    }

    /// <summary>
    /// �i�s���������肷��֐�
    /// </summary>
    /// <param name="inputVec">���͕�����Vector2��</param>
    /// <returns>�i�s����</returns>
    Vector3 PlayerVec(Vector2 inputVec)
    {
        Vector3 vec = new Vector3(inputVec.x, 0, inputVec.y);
        vec.Normalize();
        vec *= _playerSpeed;
        vec.y = _rb.velocity.y;
        vec = transform.TransformDirection(vec);
        return vec;
    }

    /// <summary>
    /// �d�͊Ǘ�
    /// </summary>
    void ControlDrag()
    {
        if (IsGround())
        {
            _rb.drag = _groundDrag;
        }
        else
        {
            _rb.drag = _airDrag;
        }
    }

    /// <summary>
    /// �v���C���[���W�����v����@�\
    /// ���Ǘ\��
    /// </summary>
    void PlayerJump()
    {
        if (InputUtility.GetDownJump)
        {
            _rb.AddForce(Vector3.up * _playerJumpSpeed, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Update�ŉ�Player��State
    /// </summary>
    void PlayerState()
    {
        _centor = transform.position + _playerCentor;
    }

    /// <summary>
    /// �ݒu����
    /// </summary>
    /// <returns>�ݒu���Ă��邩�ǂ���</returns>
    bool IsGround()
    {
        Collider[] collision = Physics.OverlapBox(_centor, _groundCollisionSize, Quaternion.identity, _groundLayer);
        if (collision.Length != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Layer�����Gizmo�\��
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(_isGroundDebug)
        {
            Gizmos.DrawCube(_centor, _groundCollisionSize);
        }
    }

    /// <summary>
    /// �v�����i�[����Ƀe�X�g���Ă����������߂̗�
    /// </summary>
    enum PlayerMovePatternTest
    {
        Velocity,
        AddForce,
    }
}
