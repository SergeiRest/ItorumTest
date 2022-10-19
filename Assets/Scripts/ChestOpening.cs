using DG.Tweening;
using UnityEngine;

public class ChestOpening : MonoBehaviour
{
    [SerializeField] private GameObject _top;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _duration;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnMouseDown()
    {
        Open();
    }

    private void Open()
    {
        _top.transform.DOLocalRotate(_offset, _duration).OnComplete(() =>
        {
            _particleSystem.Play();
            Destroy(gameObject, 3f);
        });
    }
}
