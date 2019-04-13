using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager instance;

    [SerializeField] GameObject go_Prefab_FloatingText;

    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
        
    }

    public void CreatingFloatingText(Vector3 pos,string _text) {
        var clone = Instantiate(go_Prefab_FloatingText, pos, go_Prefab_FloatingText.transform.rotation);
        clone.GetComponentInChildren<Text>().text = _text;
    }
}
