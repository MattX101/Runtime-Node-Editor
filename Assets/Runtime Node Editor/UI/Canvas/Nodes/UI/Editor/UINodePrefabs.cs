using UnityEditor;

#if UNITY_EDITOR
namespace RuntimeNodeEditor.UI.Canvas.Node.UI.Editor
{
    internal partial class UIPrefabMenu
    {
        private const string NodesPath = "Assets/Runtime Node Editor/Assets/Prefabs/Nodes/";

        [MenuItem(GameObjectPath + "Nodes/Node", false, 0), MenuItem(AssetsPath + "Nodes/Node", false, 0)]
        private static void CreateNode() => CreateUIPrefab(NodesPath + "Node");

        [MenuItem(GameObjectPath + "Nodes/Node with Image", false, 1), MenuItem(AssetsPath + "Nodes/Node with Image", false, 1)]
        private static void CreateNodeWithImage() => CreateUIPrefab(NodesPath + "Node With Image");
    }
}
#endif
