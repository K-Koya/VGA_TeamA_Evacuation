using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] TestCameraPattern _cameraPattern;

    /// <summary>
    /// Test�p�̃J�����̃p�^�[��
    /// �v�����i�[����ɂ��̋������������ŏI�I�Ɍ��肵�Ă��������܂�
    /// </summary>
    enum TestCameraPattern
    {
        Pattern1,
        Pattern2,
    }
}
