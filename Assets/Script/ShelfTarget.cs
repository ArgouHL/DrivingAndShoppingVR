using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShelfTarget : MonoBehaviour
{
    [SerializeField] private GameObject[] goods;
    

   public GameObject GetGoodsTarget()
    {
        var target = goods[Random.Range(0, goods.Length)];
        var outline = target.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 10;
        outline.OutlineColor = Color.green;
        return target;


    }


}
