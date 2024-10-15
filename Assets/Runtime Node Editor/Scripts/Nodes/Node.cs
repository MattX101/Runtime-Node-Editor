using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Node : MonoBehaviour
    {
        private bool _wasExecuted;
        public bool endNode = false;

        public readonly List<InputPointer> inputs = new();
        public readonly List<OutputPointer> outputs = new();

        public NodeUIElements Elements;
        
        public void AddPointer(InputPointer input, int valueTypeIndex)
        {
            input.AddInputPointer(this, input, valueTypeIndex);
        }
        public void AddPointer(OutputPointer output, int valueTypeIndex)
        {
            output.AddOutputPointer(this, output, valueTypeIndex);
        }

        public void DeletePointerConnections()
        {
            foreach (InputPointer input in inputs)
                input.DeleteConnection();

            foreach (OutputPointer output in outputs)
                output.DeleteConnections();
        }

        public int MoveUp()
        {
            if (endNode)
            {
                Execute();

                return 0;
            }

            if (outputs == null)
                return 0;

            foreach (InputPointer input in outputs.Where(output => output.ConnectedInputPointers != null).SelectMany(output => output.ConnectedInputPointers))
                input.Node.MoveUp();

            return 1;
        }

        public int OnValueChangeReset()
        {
            ResetExecution();

            if (endNode)
            {
                Execute();

                return 0;
            }

            if (outputs == null)
                return 0;

            foreach (InputPointer input in outputs.Where(output => output.ConnectedInputPointers != null).SelectMany(output => output.ConnectedInputPointers))
                input.Node.OnValueChangeReset();

            return 1;
        }

        protected virtual void CodeToExecute() { }
        internal void Execute()
        {
            if (!_wasExecuted)
            {
                Debug.Log("Executing node: " + gameObject.name + " " + gameObject.GetHashCode());

                CodeToExecute();
                _wasExecuted = true;
            }

            GetData();
        }

        protected void ExecuteInputConnection(int i)
        {
            if (IsValid(inputs[i]))
                inputs[i].ConnectedOutputPointer.Node.Execute();
        }

        protected virtual void DataToGetAndSet() { }
        private void GetData()
        {
            Debug.Log("Get data of node: " + gameObject.name + " " + gameObject.GetHashCode());

            DataToGetAndSet();
        }

        protected virtual void CodeToReset() { }
        internal void Reset()
        {
            Debug.Log("Reseting node: " + gameObject.name + " " + gameObject.GetHashCode());

            CodeToReset();
            ResetExecution();
        }

        internal void ResetExecution()
        {
            _wasExecuted = false;
        }

        public bool IsValid(InputPointer input)
        {
            return input && input.ConnectedOutputPointer;
        }
    }
}
