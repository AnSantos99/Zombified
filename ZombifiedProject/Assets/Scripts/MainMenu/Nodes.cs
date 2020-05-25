using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Nodes : MonoBehaviour
{
    public Transform CameraPos;

    public void ClickIt ()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(Camera.main.transform.DOMove(CameraPos.position, 0.75f));
        seq.Join(Camera.main.transform.DORotate(CameraPos.rotation.eulerAngles, 0.75f));
    }
}
