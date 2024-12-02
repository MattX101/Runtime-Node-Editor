using System;

namespace RuntimeNodeEditor.Node.UI.Functions.Elements
{
    [Serializable]
    public partial class NodeUIElements
    {
        public void SetElements(string[] texts, bool[] booleans, float[] values, int[] dropdownValues)
        {
            SetInputFields(texts);
            SetBooleans(booleans);
            SetSliders(values);
            SetDropdowns(dropdownValues);
        }

        public void SetElements(NodeUIElements elementsToCopy)
        {
            SetInputFields(elementsToCopy.inputFields);
            SetBooleans(elementsToCopy.buttons);
            SetSliders(elementsToCopy.sliders);
            SetDropdowns(elementsToCopy.dropdowns);
        }
    }
}
