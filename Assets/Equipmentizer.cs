using System.Collections.Generic;
using UnityEngine;

public class Equipmentizer : MonoBehaviour
{
    public Transform targetRootBone;
    public Transform targetSMRContainer;

    void Start()
    {
        ReattachAllMeshRenderers(gameObject, targetRootBone, targetSMRContainer);
    }

    private void ReattachAllMeshRenderers(GameObject model, Transform targetRootBone, Transform targetSMRContainer)
    {
        SkinnedMeshRenderer[] meshes = model.GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer mesh in meshes)
        {
            ReattachSkinnedMeshRenderer(mesh, targetRootBone, targetSMRContainer);
        }
    }

    private void ReattachSkinnedMeshRenderer(SkinnedMeshRenderer smr, Transform targetRootBone, Transform targetSMRContainer)
    {
        smr.transform.SetParent(targetSMRContainer);
        smr.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);


        Transform[] newBones = new Transform[smr.bones.Length];

        Dictionary<string, Transform> boneMap = GetAllBonesFromSMR(targetSMRContainer);

        for (int i = 0; i < smr.bones.Length; ++i)
        {
            string bone = smr.bones[i].name;
            if (!boneMap.TryGetValue(bone, out newBones[i]))
            {
                Debug.Log("Unable to map bone \"" + bone+ "\" to target skeleton.");
            }
        }


        smr.bones = newBones;

        smr.rootBone = targetRootBone;
        
    }



    Dictionary<string, Transform> GetAllBonesFromSMR(Transform targetSMRContainer)
    {
        SkinnedMeshRenderer[] renderers = targetSMRContainer.GetComponentsInChildren<SkinnedMeshRenderer>();
        Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>();

        foreach (SkinnedMeshRenderer smr in renderers)
        {
            foreach (Transform bone in smr.bones)
            {
                if (!boneMap.ContainsKey(bone.name)) boneMap[bone.name] = bone;
            }

        }

        return boneMap;
    }
}
