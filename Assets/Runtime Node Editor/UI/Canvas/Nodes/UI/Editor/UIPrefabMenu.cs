using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
namespace RuntimeNodeEditor.UI.Canvas.Node.UI.Editor
{
    internal partial class UIPrefabMenu
    {
        private const string GameObjectPath = "GameObject/Runtime Node Editor/";
        private const string AssetsPath = "Assets/Create/Runtime Node Editor/";

        private const string ElementsPath = "Assets/Runtime Node Editor/Assets/Prefabs/Nodes/Elements/";

        [MenuItem(GameObjectPath + "Elements/Boolean Button", false, 0), MenuItem(AssetsPath + "Elements/Boolean Button", false, 0)]
        private static void CreateBooleanButton() => CreateUIPrefab(ElementsPath + "Boolean Button");

        [MenuItem(GameObjectPath + "Elements/Dropdown", false, 1), MenuItem(AssetsPath + "Elements/Dropdown", false, 1)]
        private static void CreateDropdown() => CreateUIPrefab(ElementsPath + "Dropdown");

        [MenuItem(GameObjectPath + "Elements/Colour Picker", false, 2), MenuItem(AssetsPath + "Elements/Colour Picker", false, 2)]
        private static void CreateColourPicker() => CreateUIPrefab(ElementsPath + "Colour Picker");

        private static void CreateUIPrefab(string path)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path + ".prefab");

            if (!prefab)
            {
                Debug.LogError("UI Prefab not found at the specified path.");

                return;
            }

            GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

            if (Selection.activeGameObject)
            {
                instance.transform.parent = Selection.activeGameObject.transform;
            }

            instance.transform.localPosition = Vector3.zero;
            instance.transform.localScale = Vector3.one;

            Selection.activeGameObject = instance;
        }
    }
}
#endif
