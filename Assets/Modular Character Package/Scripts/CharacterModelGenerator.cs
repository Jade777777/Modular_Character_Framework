using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModelGenerator
{
    private List<CModel> characterModels;

    public CharacterModelGenerator(List<CModel> characterModels)
    {
        this.characterModels = characterModels;
    }

    private void AttachSkinnedMeshRenderer(SkinnedMeshRenderer smr, Transform targetRootBone, Transform targetSMRContainer)
    {
        smr.transform.SetParent(targetSMRContainer);
        smr.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);



        Transform[] newBones = new Transform[smr.bones.Length];
        Dictionary<string, Transform> boneMap = GetAllSkinnedMeshRenderers(targetSMRContainer);

        for (int i = 0; i < smr.bones.Length; ++i)
        {
            GameObject bone = smr.bones[i].gameObject;
            if (!boneMap.TryGetValue(bone.name, out newBones[i]))
            {
                Debug.Log("Unable to map bone \"" + bone.name + "\" to target skeleton.");
            }
        }



        smr.bones = newBones;
        smr.rootBone = targetRootBone;
    }



    Dictionary<string, Transform> GetAllSkinnedMeshRenderers(Transform targetSMRContainer)
    {
        SkinnedMeshRenderer[] renderers = targetSMRContainer.GetComponentsInChildren<SkinnedMeshRenderer>();
        Dictionary<string, Transform> boneMap = new Dictionary<string, Transform>();

        foreach (SkinnedMeshRenderer smr in renderers)
        {
            foreach (Transform bone in smr.bones)
            {
                if (!boneMap.ContainsKey(bone.gameObject.name)) boneMap[bone.gameObject.name] = bone;
            }
        }
        return boneMap;
    }
}
