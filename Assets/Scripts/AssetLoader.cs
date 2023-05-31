using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;

public class AssetLoader : MonoBehaviour
{
    [FormerlySerializedAs("_assetPath")] [SerializeField]
    private string assetPath;

    [SerializeField] Transform parent;


    IEnumerator Start()
    {
        AsyncOperationHandle<GameObject> asyncOperationHandle =
            Addressables.LoadAssetAsync<GameObject>(assetPath);
        yield return asyncOperationHandle;
        if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject obj = asyncOperationHandle.Result;
            Instantiate(obj, parent);
        }
        else
        {
            Debug.Log("Failed to load asset");
        }
    }
}