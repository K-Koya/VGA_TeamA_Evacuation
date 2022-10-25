using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// ��̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class MosquitoMove : MonoBehaviour
{
    [Header("��̏���n�_")]
    [SerializeField, Tooltip("��̏���n�_")] Vector3[] _wayPoints;

    private void Start()
    {
        transform.DOPath(_wayPoints, 10f).SetLookAt(0.01f)
                                         .SetLoops(-1); ;
    }
}
