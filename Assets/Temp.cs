using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Temp : MonoBehaviour
{
    [MenuItem("Tools/Remove Collider And Apply Prefab Changes %#p")]
    static public void removeColliderAndApplyPrefabChanges()
    {
        string log = "";
        var obj = Selection.gameObjects;
        if (obj != null)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                bool modified = false;
                // check to see if selected object is connected to a prefab
         
                var prefab_root = PrefabUtility.GetOutermostPrefabInstanceRoot(obj[i]);
                var prefab_src = PrefabUtility.GetCorrespondingObjectFromSource(prefab_root);
                if (prefab_src != null)
                {
                    log += "<color=white>CHECKING PREFAB:</color> " + obj[i].name + "\n";

                    // now check to see if has a collider
                    MeshRenderer[] meshRs = obj[i].GetComponentsInChildren<MeshRenderer>();
                    foreach(MeshRenderer meshR in meshRs  )
                    {
                        meshR.stitchLightmapSeams = true;
                        modified = true;
                    }


                  

                    if (modified)
                    {
                        // apply updated
                        
                        PrefabUtility.SaveAsPrefabAsset(prefab_root, AssetDatabase.GetAssetPath(prefab_src));
                        log += "\t<color=yellow>APPLYING PREFAB:</color> " + AssetDatabase.GetAssetPath(prefab_src) + "\n\n";
                    }
                }
            }
            Debug.Log(log);
        }
        else
        {
            Debug.Log("Nothing selected");
        }
    }
}

