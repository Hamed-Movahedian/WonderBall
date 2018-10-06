using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    #region Instance

    private static GameController _gameController;

    public static GameController Instance
    {
        get
        {
            if (_gameController == null)
                _gameController = FindObjectOfType<GameController>();

            if (_gameController == null)
                throw new System.Exception("Player controller doesn't exist!!!");

            return _gameController;
        }
    }

    #endregion

    // Level Scene name

    public string LevelSceneName;

    public string MenuSceneName;

    public Transform EndLevel;

    public FloatEvent OnProgressChange;

    private float _levelPercentage;

    private Vector3 _startLevel;

    private void Start()
    {
        _startLevel = PlayerController.Instance.transform.position;
    }

    private void Update()
    {
        var percentage = Vector3.Distance(_startLevel, PlayerController.Instance.transform.position) /
                Vector3.Distance(_startLevel, EndLevel.position);

        if (percentage != _levelPercentage)
        {
            _levelPercentage = percentage;
            OnProgressChange.Invoke(percentage);
        }
    }


    public void Win(float delay)
    {
        StartCoroutine(WinCorotine(delay));
    }

    private IEnumerator WinCorotine(float delay)
    {
        // wait delay seconds
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(MenuSceneName);

    }

    public void Lose(float delay)
    {
        StartCoroutine(LoseCorotine(delay));
    }
    private IEnumerator LoseCorotine(float delay)
    {
        // wait delay seconds
        yield return new WaitForSeconds(delay);

        // Reload scene
        SceneManager.LoadScene(LevelSceneName);
    }
}
[System.Serializable]
public class FloatEvent : UnityEvent<float> { }
