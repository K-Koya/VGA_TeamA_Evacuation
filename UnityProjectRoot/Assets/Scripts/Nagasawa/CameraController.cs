using UnityEngine;
using Cinemachine;
using System;

/// <summary>
/// �J�����𐧌䂵�Ă���R���|�[�l���g
/// </summary>
public class CameraController : MonoBehaviour
{
    [Tooltip("�J�����̃p�^�[��"), SerializeField]
    CameraPattern _cameraPattern;

    [Tooltip("���x�ݒ�"), SerializeField] 
    float _xSensityvity,_ySensityvity = 3f;

    [Tooltip("Y���̏������ �p�^�[��1"), SerializeField]
    float _minY = -2, _maxY = 7;

    [Tooltip("Y���̏������ �p�^�[��2"), SerializeField]
    float _minYb = -45.0f, _maxYb = 45.0f;

    [Tooltip("�J�����̒Ǐ]�x"), SerializeField]
    float _cameraDamping = 0.5f;

    [Tooltip("Player�̃J����"), SerializeField] 
    CinemachineVirtualCamera _vcam;

    bool _cursorLock = true;
    Cinemachine3rdPersonFollow _tpf;
    CinemachineComposer _composer;
   
    void Start()
    {
        SetUp();
    }

    void Update()
    {
        CameraState();
        MoveCameraMethod();
        UpdateCursorLock();
    }

    void CameraState()
    {
        _composer.m_HorizontalDamping = _cameraDamping;
        _composer.m_VerticalDamping = _cameraDamping;
    }

    /// <summary>
    /// �ŏ��̃Z�b�g�A�b�v
    /// </summary>
    void SetUp()
    {
        _tpf = _vcam.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
        _composer = _vcam.GetCinemachineComponent<CinemachineComposer>();
    }

    /// <summary>
    /// �J�����𓮂����Ă���Ƃ���
    /// </summary>
    void MoveCameraMethod()
    {
        switch (_cameraPattern)
        {
            case CameraPattern.Pattern1:
                transform.localRotation *= Quaternion.Euler(0, InputUtility.GetDirectionCameraMove.x * _xSensityvity / 10, 0);

                _tpf.VerticalArmLength -= InputUtility.GetDirectionCameraMove.y * _ySensityvity / 100;
                _tpf.VerticalArmLength = Mathf.Clamp(_tpf.VerticalArmLength, _minY, _maxY);
                break;
            case CameraPattern.Pattern2:
                transform.localRotation *= Quaternion.Euler(0, InputUtility.GetDirectionCameraMove.x * _xSensityvity / 10, 0);

                transform.localRotation *= Quaternion.Euler(-InputUtility.GetDirectionCameraMove.y * _ySensityvity / 10, 0, 0);
                transform.localRotation = ClampRotation(transform.localRotation);
                break;
            default:
                Debug.LogError("�ړ��p�^�[�����w�肵�Ă�������");
                break;
        }
    }

    /// <summary>
    /// �J�[�\�������b�N����֐��@��΂����ɏ����Ȃ��ق��������C������
    /// </summary>
    public void UpdateCursorLock()
    {
        if (_cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!_cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    /// <summary>
    /// �p�x�����֐��̍쐬
    /// </summary>
    /// <param name="q"></param>
    /// <returns></returns>
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,z�̓x�N�g���i�ʂƌ����j�Fw�̓X�J���[�i���W�Ƃ͖��֌W�̗ʁj)
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;
        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;
        angleX = Mathf.Clamp(angleX, _minYb, _maxYb);
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);
        return q;
    }

    /// <summary>
    /// �v�����i�[����Ɍ��߂Ă��������p�^�[��
    /// </summary>
    enum CameraPattern
    {
        Pattern1,
        Pattern2,
    }
}
