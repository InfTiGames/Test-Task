using DG.Tweening;
using UnityEngine;

public class ScreenSwiper : MonoBehaviour {

    private bool _isSwiped;
    private const float EndValue = -2225f, StartValue = 0f, MoveDuration = 1.5f;

    /// <summary>
    /// Shows settings screen
    /// </summary>
    public void Settings() {
        if (!_isSwiped) transform.DOLocalMoveX(EndValue, MoveDuration);
        else transform.DOLocalMoveX(StartValue, MoveDuration);
        _isSwiped = !_isSwiped;
    }

    /// <summary>
    /// Shows lobby screen
    /// </summary>
    public void Play() {
        if (!_isSwiped) transform.DOLocalMoveX(-EndValue, MoveDuration);
        else transform.DOLocalMoveX(StartValue, MoveDuration);
        _isSwiped = !_isSwiped;
    }
}