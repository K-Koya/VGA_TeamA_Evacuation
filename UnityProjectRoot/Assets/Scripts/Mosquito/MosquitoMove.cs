using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

/// <summary>
/// ��̓����𐧌䂷��R���|�[�l���g
/// </summary>
public class MosquitoMove : MonoBehaviour
{
    [Header("��̏���n�_")]
    [SerializeField, Tooltip("��̏���n�_")] GameObject[] _wayPoints;
    [SerializeField, Tooltip("���b�����Ĉړ����邩")] float _moveTime;
    [SerializeField, Tooltip("�e����n�_�֑΂��Ă̓�����")] PathType _pathType;

    private void Start()
    {
        transform.DOPath
            (
            _wayPoints.Select(wayPoints => wayPoints.transform.position).ToArray(),
            _moveTime,
            _pathType
            )
            .SetLookAt(0.01f) // �O�������悤�ɂ���
            .SetLoops(-1, LoopType.Yoyo);
    }
}
