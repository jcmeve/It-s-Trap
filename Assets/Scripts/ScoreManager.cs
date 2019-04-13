using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int currentScore;
    public int GetCurrentScore() {return currentScore;}
    public static int extraScore;
    int distanceScore;
    float maxDistance;//플레이어가 이동한 최대Z
    float originPosz;
    [SerializeField] Text txt_Score;
    [SerializeField] Transform tf_Player;

    private void Start() {

        originPosz = tf_Player.position.z;
    }
    public void MakeZeroMaxDistance() {
        maxDistance = 0f;
    }


    // Update is called once per frame
    void Update()
    {
        if (tf_Player.position.z >= maxDistance) {
            maxDistance = tf_Player.position.z;
            distanceScore = Mathf.RoundToInt(maxDistance-originPosz);
        }
        currentScore = extraScore+distanceScore;

        txt_Score.text = string.Format(" {0:000,000}", currentScore);
    }
}
