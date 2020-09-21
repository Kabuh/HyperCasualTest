using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper Instance;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    public TextMeshProUGUI RewardScore;

    private int _score;
    [SerializeField]
    private int fuelExplodersAllCount;
    [SerializeField]
    private int dustExplodersAllCount;

    int collectedFuel = 0;
    int collectedStar = 0;

    public float fuelfCollectedFract() {
        return ((float)collectedFuel / (float)fuelExplodersAllCount);
    }
    
    public float starfCollectedFract()
    {
        return ((float)collectedStar / (float)dustExplodersAllCount);
    }

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(int value, OrbType orbType) {
        _score += value;
        scoreText.text = _score.ToString();
        switch (orbType) {
            case OrbType.FuelOrb:
                collectedFuel++;
                break;
            case OrbType.DustOrb:
                collectedStar++;
                break;
        };
    }

    public void FillScore(float unloadDuration) {
        StartCoroutine(FillScoreAnimation(unloadDuration));
    }

    IEnumerator FillScoreAnimation(float unloadDuration) {
        float score = 0;
        float timePassed = 0;
        while (score < _score) {
            timePassed += Time.deltaTime;
            score = (timePassed/unloadDuration*_score);
            RewardScore.text = Mathf.FloorToInt(score).ToString();
            yield return null;
        }
        RewardScore.text = _score.ToString();
    }
}
