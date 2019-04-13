using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] StageManager stageManager;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            stageManager.ShowClearUI();

        }
    }
}
