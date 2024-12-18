using UnityEngine;

namespace RuntimeNodeEditor.Data
{
    internal class UIManager : MonoBehaviour
    {
        [Header("Transforms")]
        [SerializeField] private Transform _nodeSpawnTransform;
        [SerializeField] private Transform _windowSpawnParent;

        [Header("Textures")]
        [SerializeField] private Texture2D _pointerTexture;

        private void Awake()
        {
            GlobalData.NodeSpawnTransform = _nodeSpawnTransform;
            GlobalData.WindowSpawnParent = _windowSpawnParent;

            GlobalData.PointerTexture = _pointerTexture;
        }
    }
}
