using UnityEditor;

#if UNITY_EDITOR
namespace RuntimeNodeEditor.UI.Canvas.Node.UI.Editor
{
    internal partial class UIPrefabMenu
    {
        /// Sliders

        [MenuItem(GameObjectPath + "Elements/Slider/Slider", false, 0), MenuItem(AssetsPath + "Elements/Slider/Slider", false, 0)]
        private static void CreateSlider() => CreateUIPrefab(ElementsPath + "Slider/Slider");

        [MenuItem(GameObjectPath + "Elements/Slider/Value Slider", false, 1), MenuItem(AssetsPath + "Elements/Slider/Value Slider", false, 1)]
        private static void CreateValueSlider() => CreateUIPrefab(ElementsPath + "Slider/Value Slider");
    }
}
#endif
