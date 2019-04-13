using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StatusManager : MonoBehaviour
{
    [SerializeField] int firstmaxHP;
    int maxHP;
    int currentHP;
    //    [SerializeField] Text[] txt_HPArray;
    List<Text> txt_HPArray;


    [SerializeField] float blinkSpeed;
    [SerializeField] int blinkCount;

    [SerializeField] GameObject HPUI;
    [SerializeField] GameObject go_HeartPrefab;
    [SerializeField] MeshRenderer mesh_PlayerGraphics;
    Coroutine currentBlink;
    bool isBlink;//bool isInvincibleMode;

    private void Start() {
        txt_HPArray = new List<Text>();

        IncreasemaxHP(firstmaxHP);
        currentHP = firstmaxHP;
        UpdateStatus();
    }

    void IncreasemaxHP(int increase) {
        for (int i = 0; i < increase; i++) {
            GameObject temp = Instantiate(go_HeartPrefab);
            temp.transform.SetParent(HPUI.transform);
            temp.transform.localPosition = new Vector3(maxHP * 100f, 0f, 0f);
            txt_HPArray.Add(temp.GetComponent<Text>());
            maxHP++;
            
            UpdateStatus();
        }
    }

    public void DecreaseHP(int _num) {
        if (!isBlink) {
            currentHP -= _num;
            UpdateStatus();
            if (currentHP <= 0)
                PlayerDead();
            if (isBlink) {
                StopCoroutine(currentBlink);
            }
            currentBlink = StartCoroutine(BlinkCoroutine());
            SoundManager.instance.PlaySE("Hurt");
        }
    }

    public void IncreaseHP(int _num) {
 
        currentHP += _num;
        if (currentHP > firstmaxHP)
            currentHP = firstmaxHP;
        UpdateStatus();
    }

    IEnumerator BlinkCoroutine() {
        isBlink = true;
        for (int i = 0; i < blinkCount*2; i++) {
            mesh_PlayerGraphics.enabled=!mesh_PlayerGraphics.enabled;
            yield return new WaitForSeconds(blinkSpeed);
        }
        mesh_PlayerGraphics.enabled = true;
        isBlink = false;

    }

    void UpdateStatus() {

        for (int i = 0; i < txt_HPArray.Count; i++) {
            if (i < currentHP)
                txt_HPArray[i].gameObject.SetActive(true);
            else
                txt_HPArray[i].gameObject.SetActive(false);

        }
    }
    void PlayerDead() {
        SceneManager.LoadScene("Title");
    }
}
