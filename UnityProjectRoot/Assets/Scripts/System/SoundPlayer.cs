using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

/// <summary>
/// ����炷�N���X
/// </summary>
[RequireComponent(typeof(CriAtomSource))]
public class SoundPlayer : MonoBehaviour
{
    CriAtomSource _source;

    private void Awake()
    {
        _source = GetComponent<CriAtomSource>();
    }

    void PlaySound()
    {
        
    }
}
