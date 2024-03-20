using RuntimeNodeEditor.Node;
using RuntimeNodeEditor.Node.Pointer;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Node
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
            CreateNodeUI(testNode, Color.red, "Test");

            inputs[0] = CreatePointer("Int In 1", ValueType.Int, 0, true, true).AddComponent<InputPointer>();
            inputs[0].name = "Int In 1";
            inputs[0].node = testNode;
            inputs[0].valueType = ValueType.Int;

            inputs[1] = CreatePointer("Int In 2", ValueType.Int, 1, true, true).AddComponent<InputPointer>();
            inputs[1].name = "Int In 2";
            inputs[1].node = testNode;
            inputs[1].valueType = ValueType.Int;

            outputs[0] = CreatePointer("Out", ValueType.Float, 0, true, false).AddComponent<OutputPointer>();
            outputs[0].name = "Out";
            outputs[0].node = testNode;
            outputs[0].valueType = ValueType.Float;

            testNode.AddPointers(inputs, outputs);
        }
    }
}
