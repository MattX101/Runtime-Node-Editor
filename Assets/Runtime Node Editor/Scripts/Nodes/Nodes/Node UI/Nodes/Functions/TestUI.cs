using RuntimeNodeEditor.RuntimeNode.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.RuntimeNode.UI
{
    public class TestUI : NodeUI
    {
        public TestUI()
        {
            CreateRoot("Test");
            Test testNode = root.AddComponent<Test>();
            testNode.nodeUI = this;

            inputs = new InputPointer[2];
            numOfInputs = inputs.Length;
            outputs = new OutputPointer[1];
            numOfOutputs = outputs.Length;

            togglePreviewImage = true;
            CreateNodeUI(Color.red, "Test");

            inputs[0] = CreateInputPointer("Int In 1", ValueType.Int, 0).AddComponent<InputPointer>();
            inputs[0].name = "Int In 1";
            inputs[0].node = testNode;
            inputs[0].valueType = ValueType.Int;

            inputs[1] = CreateInputPointer("Int In 2", ValueType.Int, 1).AddComponent<InputPointer>();
            inputs[1].name = "Int In 2";
            inputs[1].node = testNode;
            inputs[1].valueType = ValueType.Int;

            outputs[0] = CreateOutputPointer("Out", ValueType.Float, 0).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = testNode;
            outputs[0].valueType = ValueType.Float;

            testNode.AddPointers(inputs, outputs);
        }
    }
}
