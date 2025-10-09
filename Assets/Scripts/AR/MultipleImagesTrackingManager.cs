using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class MultipleImagesTrackingManager : MonoBehaviour
{
    // Prefabs para instanciar
    [SerializeField] List<GameObject> prefabsToSpawn = new List<GameObject>();

    // Referencia a ARTrackedImageManager
    private ARTrackedImageManager _trackedImageManager;

    // Diccionario para referenciar prefabs instanciados por nombre de imagen rastreada
    private Dictionary<string, GameObject> _arPrefabs;

    // Inicialización y asignación de referencias
    private void Start()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
        if (_trackedImageManager == null)
        {
            Debug.LogError("ARTrackdImageManage component not found in the GameObject.");
            return;
        }

        _trackedImageManager.trackablesChanged.AddListener(OnImagesTrackedChanged);
        _arPrefabs = new Dictionary<string, GameObject>();
        SetupSceneElements();
    }

    private void OnDestroy()
    {
        if (_trackedImageManager != null)
        {
            _trackedImageManager.trackablesChanged.RemoveListener(OnImagesTrackedChanged);
        }
    }
    // Configurar elementos de la escena
    private void SetupSceneElements()
    {
        foreach (var prefab in prefabsToSpawn)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            newPrefab.SetActive(false);
            _arPrefabs.Add(newPrefab.name, newPrefab);
        }
    }

    // Actualizar imágenes rastreadas y prefabs
    private void OnImagesTrackedChanged(ARTrackablesChangedEventArgs<ARTrackedImage> eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            UpdateTrackedImage(trackedImage);
        }
        foreach (var trackedImage in eventArgs.updated)
        {
            UpdateTrackedImage(trackedImage);
        }
        foreach (var removed in eventArgs.removed)
        {
            // eventArgs.removed puede ser una colección de KeyValuePair<TrackableId, ARTrackedImage>
            // Hacemos boxing a object y tratamos de extraer el ARTrackedImage de forma segura
            object boxed = removed;
            ARTrackedImage img = boxed as ARTrackedImage;
            if (img == null)
            {
                var type = boxed.GetType();
                var prop = type.GetProperty("Value");
                if (prop != null)
                {
                    var val = prop.GetValue(boxed);
                    img = val as ARTrackedImage;
                }
            }

            if (img == null) continue;

            if (_arPrefabs.TryGetValue(img.referenceImage.name, out var prefab))
            {
                prefab.SetActive(false);
            }
        }

    }

    private void UpdateTrackedImage(ARTrackedImage trackedImage)
    {
        if (trackedImage == null)
        {
            Debug.LogError("TrackedImage is null.");
            return;
        }
        if (trackedImage.trackingState is TrackingState.Limited or TrackingState.None)
        {
            if (_arPrefabs.TryGetValue(trackedImage.referenceImage.name, out var prefab))
                prefab.SetActive(false);
            return;
        }

        // Obtener el prefab asociado de forma segura
        if (!_arPrefabs.TryGetValue(trackedImage.referenceImage.name, out var arPrefab))
            return;

        // Hacer que el prefab sea hijo del trackedImage para que siga su anclaje
        arPrefab.transform.SetParent(trackedImage.transform, false);
        arPrefab.SetActive(true);

        // Asegurarnos de que el prefab esté en la posición local correcta respecto al trackedImage
        arPrefab.transform.localPosition = Vector3.zero;
        arPrefab.transform.localRotation = Quaternion.identity;
    }
}
