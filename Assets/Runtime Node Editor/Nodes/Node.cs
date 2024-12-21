using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UI.Functions.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Node : MonoBehaviour
    {
        private bool _wasExecuted;

        [SerializeField]
        private bool _endNode = false;
        public bool EndNode => _endNode;

        [SerializeField]
        private List<InputPointer> _inputs = new();
        public List<InputPointer> Inputs => _inputs;

        [SerializeField]
        private List<OutputPointer> _outputs = new();
        public List<OutputPointer> Outputs => _outputs;

        public NodeUIElements Elements;

        public void AddPointer(InputPointer Input, int valueTypeIndex)
        {
            Input.AddInputPointer(this, Input, valueTypeIndex);
        }
        public void AddPointer(OutputPointer Output, int valueTypeIndex)
        {
            Output.AddOutputPointer(this, Output, valueTypeIndex);
        }

        public void DeletePointerConnections()
        {
            foreach (InputPointer Input in Inputs)
            {
                Input.DeleteConnection();
            }

            foreach (OutputPointer Output in Outputs)
            {
                Output.DeleteConnections();
            }
        }

        public void ExecuteChain()
        {
            if (EndNode)
            {
                Execute();

                return;
            }

            if (Outputs == null)
                return;

            foreach (InputPointer Input in Outputs.Where(Output => Output.ConnectedInputPointers != null).SelectMany(Output => Output.ConnectedInputPointers))
            {
                Input.Node.ExecuteChain();
            }
        }

        public void ChainReset()
        {
            ResetExecution();

            if (EndNode || Outputs == null)
                return;

            foreach (InputPointer Input in Outputs.Where(Output => Output.ConnectedInputPointers != null).SelectMany(Output => Output.ConnectedInputPointers))
            {
                Input.Node.ChainReset();
            }
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
            if (IsValid(Inputs[i]))
            {
                Inputs[i].ConnectedOutputPointer.Node.Execute();
            }
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

        public bool IsValid(InputPointer Input)
        {
            return Input && Input.ConnectedOutputPointer;
        }
    }
}
