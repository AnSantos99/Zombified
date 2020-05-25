using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuNodes : MonoBehaviour
{
    public Transform OnScreen;

    public Transform OffScreen;

    public void EnterScreen ()
    {
        Sequence seq = DOTween.Sequence();
        this.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutQuad);
    }

    public void ExitScreen ()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(this.transform.DOMove(OffScreen.position, 0.75f));
    }
}
