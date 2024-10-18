using RuntimeNodeEditor.Node.UIFunctions.Component;
using UnityEngine.UI;
using TMPro;

namespace RuntimeNodeEditor.Node.UIFunctions.Elements
{
    public partial class NodeUIElements
    {
        public NodeUIElements(int numOfInputsFields = 0, int numOfBooleanButtons = 0, int numOfSliders = 0, int numOfDropdowns = 0) 
        {
            InputFields = new TMP_InputField[numOfInputsFields];
            Buttons = new BooleanButton[numOfBooleanButtons];
            Sliders = new Slider[numOfSliders];
            Dropdowns = new Component.Dropdown[numOfDropdowns];
        }

        public void SetElements(string[] texts, bool[] booleans, float[] values, int[] dropdownContext, string[] dropdownText)
        {
            SetInputFields(texts);
            SetBooleans(booleans);
            SetSliders(values);
            SetDropdowns(dropdownContext, dropdownText);
        }

        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.InputFields);
            SetBooleans(elementsToCopy.Buttons);
            SetSliders(elementsToCopy.Sliders);
            SetDropdowns(elementsToCopy.Dropdowns);
        }
    }
}
