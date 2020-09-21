using UnityEngine;
using TMPro;

public class RewardScreenScore : MonoBehaviour
{
    void Start()
    {
        ScoreKeeper.Instance.RewardScore = this.gameObject.GetComponent<TextMeshProUGUI>();
    }
}
