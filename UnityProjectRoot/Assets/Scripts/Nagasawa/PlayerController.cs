using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerMovePatternTest _movePattern;
    [SerializeField] float _playerSpeed = 5.0f;
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
        if(!TryGetComponent(out _rb))
        {
            _rb =  gameObject.AddComponent<Rigidbody>();
        }

        //Contains��RotationX,Z���Œ�
        _rb.constraints = (RigidbodyConstraints)80;
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    //Player�̈ړ����@�����肷��X�e�[�g
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

    void VelocityMove()
    {
        Vector3 vec = new Vector3(InputUtility.GetDirectionMove.x * _playerSpeed, _rb.velocity.y, InputUtility.GetDirectionMove.y * _playerSpeed);
        vec =  transform.TransformDirection(vec);
        _rb.velocity = vec.normalized;
    }

    void AddForceMove()
    {

    }

    enum PlayerMovePatternTest
    {
        Velocity,
        AddForce,
    }
}
