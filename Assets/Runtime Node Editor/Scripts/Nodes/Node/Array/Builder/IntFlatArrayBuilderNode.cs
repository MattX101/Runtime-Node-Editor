using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntFlatArrayBuilderNode : Node
    {
        protected override void CodeToExecute()
        {
            MultiConnectionInputPointer multiInput = GetMulti(0);
            if (multiInput)
            {
                IntArrayOutputPointer outputArray = outputs[0].GetComponent<IntArrayOutputPointer>();
                outputArray.values = new int[GetArrayLength(multiInput)];

                int arrayIndex = 0;
                for (int pointerIndex = 0; pointerIndex < multiInput.connectedOutputPointers.Count; pointerIndex++)
                {
                    if (multiInput.connectedOutputPointers[pointerIndex].pointerType == Pointer.Type.PointerType.Array)
                    {
                        IntArrayOutputPointer array = multiInput.connectedOutputPointers[pointerIndex].GetComponent<IntArrayOutputPointer>();

                        if (array.values == null)
                            continue;

                        for (int valuesIndex = 0; valuesIndex < array.values.Length; valuesIndex++, arrayIndex++)
                            outputArray.values[arrayIndex] = array.values[valuesIndex];

                        continue;
                    }

                    outputArray.values[arrayIndex] = PointerValue.GetInt(multiInput.connectedOutputPointers[pointerIndex]);
                    arrayIndex++;
                }
            }
        }

        private int GetArrayLength(MultiConnectionInputPointer multiInput)
        {
            int arrayLength = 0;

            for (int pointerIndex = 0; pointerIndex < multiInput.connectedOutputPointers.Count; pointerIndex++)
            {
                multiInput.connectedOutputPointers[pointerIndex].node.Execute();

                if (multiInput.connectedOutputPointers[pointerIndex].pointerType == Pointer.Type.PointerType.Array)
                {
                    IntArrayOutputPointer array = multiInput.connectedOutputPointers[pointerIndex].GetComponent<IntArrayOutputPointer>();
                    array.node.Execute();

                    arrayLength += array.values == null ? 0 : array.values.Length;
                    continue;
                }

                arrayLength++;
            }

            return arrayLength;
        }
    }
}
