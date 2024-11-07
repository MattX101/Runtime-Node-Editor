using RuntimeNodeEditor.Data;
using UnityEngine;
using UnityEngine.UI;

namespace RuntimeNodeEditor.UI.Canvas.Node.UI
{
    public static partial class UISlider
    {
        public static Slider AddLinearSlider(Transform parent, Color color, bool pointerIsInput)
        {
            return CreateLinearSlider(
                CreateSliderObject(parent, color, pointerIsInput).transform, 
                color);
        }

        public static Slider AddIntegerSlider(Transform parent, Color color, int min, int max, bool pointerIsInput)
        {
            return CreateIntegerSlider(
                CreateSliderObject(parent, color, pointerIsInput).transform, 
                min, 
                max, 
                color);
        }

        private static GameObject CreateSliderObject(Transform parent, Color color, bool pointerIsInput)
        {
            // Root
            GameObject sliderObject = UIElement.Create(
                parent,
                "Slider Element",
                Vector2.zero,
                new Vector3(
                    -GlobalData.NodeWidth + GlobalData.BorderSize,
                    0,
                    -1)
                );

            CreateBackground(sliderObject.transform, color);
            SetPosition(sliderObject, pointerIsInput);

            return sliderObject;
        }

        private static void CreateBackground(Transform parent, Color color)
        {
            // Background
            float scaleX = GlobalData.NodeWidth;
            scaleX -= GlobalData.PointerSize / 2;
            scaleX -= GlobalData.BorderSize * 4;

            GameObject background = UIElement.Create(
                parent,
                "Background",
                new Vector2(scaleX, GlobalData.PointerSize),
                new Vector3(scaleX / 2, 0, 0));

            RawImage backgroundImage = background.AddComponent<RawImage>();
            backgroundImage.color = color * 0.75f;
        }

        private static void SetPosition(GameObject sliderObject, bool pointerIsInput)
        {
            float posX = sliderObject.transform.localPosition.x;
            if (pointerIsInput)
            {
                posX += GlobalData.NodeWidth;
                posX += GlobalData.SliderTextFieldWidth;
                posX += GlobalData.BorderSize;
                posX += GlobalData.PointerSize * 1.5f;
            }
            sliderObject.transform.localPosition = new Vector3(posX, 0, -1);
        }
    }
}
