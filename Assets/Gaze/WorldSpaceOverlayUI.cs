using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceOverlayUI : MonoBehaviour
{
    private const string shaderTestMode = "unity_GUIZTestMode";
    [SerializeField] UnityEngine.Rendering.CompareFunction desiredUIComparison = UnityEngine.Rendering.CompareFunction.Always;
    [SerializeField] private Graphic[] uiEllenemtsToApply;
    private Dictionary<Material, Material> materialMapping = new Dictionary<Material, Material>();

    private void Start()
    {
        foreach (var graphic in uiEllenemtsToApply)
        {
            //uiEllenemtsToApply = gameObject.GetComponentInChildren<Graphic>();
            Material material = graphic.materialForRendering;
            if(material == null)
            {
                Debug.Log("Error");
                continue;
            }
            if (!materialMapping.TryGetValue(material, out Material materialCopy))
            {
                materialCopy = new Material(material);
                materialMapping.Add(material, materialCopy);
            }
            materialCopy.SetInt(shaderTestMode, (int)desiredUIComparison);
            graphic.material = materialCopy;


        }
    }
}
