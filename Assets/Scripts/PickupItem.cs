using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] Gun[] guns;
    const int NORMAL_GUN = 0;

    GunController gunController;
    private void Start() {
        gunController = FindObjectOfType<GunController>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.transform.CompareTag("Item")) {
            Item item = other.GetComponent<Item>();
            int extra=0;
            if (item.itemType == ItemType.Score) {
                SoundManager.instance.PlaySE("Score");
                extra = item.extraScore;
                ScoreManager.extraScore += extra;
            }
            else if(item.itemType == ItemType.Normalgun_Bullet){
                SoundManager.instance.PlaySE("Bullet");
                extra = item.extraBullet;
                guns[NORMAL_GUN].bulletCount += extra;
                gunController.BulletUISetting();
            }
            string message = "+" + extra;
            FloatingTextManager.instance.CreatingFloatingText(other.transform.position,message);
            Destroy(other.gameObject);
        }
    }
}
