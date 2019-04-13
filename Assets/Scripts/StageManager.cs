using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageManager : MonoBehaviour
{
    [SerializeField] Text txt_CurrentScore;
    [SerializeField] GameObject go_UI;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject[] go_Stages;
    
    int currentStage = 0;

    [SerializeField] Transform tf_OriginPos;


    public void ShowClearUI() {
        go_UI.SetActive(true);
        txt_CurrentScore.text = string.Format("{0:000,000}", scoreManager.GetCurrentScore()) ;
        playerController.CanMove = false;
        playerController.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void NextButton() {
        if (currentStage < go_Stages.Length - 1) {
            go_UI.SetActive(false);
            playerController.CanMove = true;
            playerController.gameObject.transform.position = tf_OriginPos.position;
            go_Stages[currentStage++].SetActive(false);
            go_Stages[currentStage].SetActive(true);
            playerController.GetComponent<Rigidbody>().isKinematic = false;
            scoreManager.MakeZeroMaxDistance();
        }
        else
            Debug.Log("다꺰");
    }

}
