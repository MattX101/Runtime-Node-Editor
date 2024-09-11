using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Node : MonoBehaviour
    {
        private bool _wasExecuted;
        public bool endNode = false;

        public readonly List<InputPointer> inputs = new();
        public readonly List<OutputPointer> outputs = new();

        public NodeUIElements Elements;

        public void AddPointer(InputPointer inputPointer, ValueType valueType)
        {
            inputPointer.node = this;
            inputPointer.valueType = valueType;

            inputs.Add(inputPointer);
        }
        public void AddPointer(OutputPointer outputPointer, ValueType valueType)
        {
            outputPointer.node = this;
            outputPointer.valueType = valueType;

            outputs.Add(outputPointer);
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

            foreach (InputPointer input in outputs.Where(output => output.connectedInputPointers != null).SelectMany(output => output.connectedInputPointers))
                input.node.MoveUp();

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

            foreach (InputPointer input in outputs.Where(output => output.connectedInputPointers != null).SelectMany(output => output.connectedInputPointers))
                input.node.OnValueChangeReset();

            return 1;
        }

        protected virtual void CodeToExecute() { }
        public void Execute()
        {
            if (!_wasExecuted)
            {
                Debug.Log("Executing node: " + gameObject.name + " " + gameObject.GetHashCode());

                CodeToExecute();
                _wasExecuted = true;
            }
            
            GetData();
        }
        protected void ExecuteConnection(int i)
        {
            if (IsValid(i))
                inputs[i].connectedOutputPointer.node.Execute();
        }

        protected virtual void DataToGetAndSet() { }
        private void GetData()
        {
            Debug.Log("Get data of node: " + gameObject.name + " " + gameObject.GetHashCode());

            DataToGetAndSet();
        }

        protected virtual void CodeToReset() { }
        public void Reset()
        {
            Debug.Log("Reseting node: " + gameObject.name + " " + gameObject.GetHashCode());

            CodeToReset();
            ResetExecution();
        }

        private void ResetExecution() => _wasExecuted = false;

        public bool IsValid(int i) => inputs[i] && inputs[i].connectedOutputPointer;
        public bool IsValid(InputPointer input) => input && input.connectedOutputPointer;
        protected bool IsConnected(int i) => inputs[i].hasConnection;
    }
}
