using UnityEditor;

#if UNITY_EDITOR
namespace RuntimeNodeEditor.UI.Canvas.Node.UI.Editor
{
    internal partial class UIPrefabMenu
    {
        /// Inputs Fields

        // Base
        [MenuItem(GameObjectPath + "Elements/Inputfield/Input Field", false, 0), MenuItem(AssetsPath + "Elements/Inputfield/Input Field", false, 0)]
        private static void CreateInputField() => CreateUIPrefab(ElementsPath + "Inputs/Input Field");

        [MenuItem(GameObjectPath + "Elements/Inputfield/Mini Input Field", false, 1), MenuItem(AssetsPath + "Elements/Inputfield/Mini Input Field", false, 1)]
        private static void CreateMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/Mini Input Field");

        // Integer
        [MenuItem(GameObjectPath + "Elements/Inputfield/Integer Input Field", false, 2), MenuItem(AssetsPath + "Elements/Inputfield/Integer Input Field", false, 2)]
        private static void CreateIntegerInputField() => CreateUIPrefab(ElementsPath + "Inputs/Integer/Integer Input Field");

        [MenuItem(GameObjectPath + "Elements/Inputfield/Integer Mini Input Field", false, 3), MenuItem(AssetsPath + "Elements/Inputfield/Integer Mini Input Field", false, 3)]
        private static void CreateIntegerMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/Integer/Integer Mini Input Field");

        // Decimal
        [MenuItem(GameObjectPath + "Elements/Inputfield/Decimal Input Field", false, 4), MenuItem(AssetsPath + "Elements/Inputfield/Decimal Input Field", false, 4)]
        private static void CreateDecimalInputField() => CreateUIPrefab(ElementsPath + "Inputs/Decimal/Decimal Input Field");

        [MenuItem(GameObjectPath + "Elements/Inputfield/Decimal Mini Input Field", false, 5), MenuItem(AssetsPath + "Elements/Inputfield/Decimal Mini Input Field", false, 5)]
        private static void CreateDecimalMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/Decimal/Decimal Mini Input Field");

        // String
        [MenuItem(GameObjectPath + "Elements/Inputfield/String Input Field", false, 6), MenuItem(AssetsPath + "Elements/Inputfield/String Input Field", false, 6)]
        private static void CreateStringInputField() => CreateUIPrefab(ElementsPath + "Inputs/String/String Input Field");

        [MenuItem(GameObjectPath + "Elements/Inputfield/String Mini Input Field", false, 7), MenuItem(AssetsPath + "Elements/Inputfield/String Mini Input Field", false, 7)]
        private static void CreateStringMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/String/String Mini Input Field");

        // Char
        [MenuItem(GameObjectPath + "Elements/Inputfield/Character Mini Input Field", false, 8), MenuItem(AssetsPath + "Elements/Inputfield/Character Mini Input Field", false, 8)]
        private static void CreateCharacterMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/Character Mini Input Field");

        // HEX
        [MenuItem(GameObjectPath + "Elements/Inputfield/HEX Mini Input Field", false, 9), MenuItem(AssetsPath + "Elements/Inputfield/HEX Mini Input Field", false, 9)]
        private static void CreateHEXMiniInputField() => CreateUIPrefab(ElementsPath + "Inputs/HEX Mini Input Field");
    }
}
#endif
