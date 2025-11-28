using RuntimeNodeEditor.Node.Pointer;
using Utils.IO.Serialization;
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
        private byte[] id;

        [Space]

        [SerializeField]
        private List<InputPointer> _inputs = new();
        public List<InputPointer> Inputs => _inputs;

        [SerializeField]
        private List<OutputPointer> _outputs = new();
        public List<OutputPointer> Outputs => _outputs;

        public void Awake()
        {
            NodeList.Add(this.gameObject.GetHashCode(), this);

            Init();
        }

        protected virtual void Init()
        {
            return;
        }

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

        // TODO - Optimize to a more effient process
        public void ResetAndExecute()
        {
            foreach (Node node in NodeList.Nodes.Values)
            {
                node.ResetExecution();
            }

            foreach (Node endNode in NodeList.Nodes.Values.Where(node => node.EndNode))
            {
                endNode.Execute();
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
        }

        protected void ExecuteInputConnection(int i)
        {
            if (IsValid(Inputs[i]))
            {
                Inputs[i].ConnectedOutputPointer.Node.Execute();
            }
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

        public void CodeToSave(FileWriter writer)
        {
            writer.Write((byte)id.Length);

            if (id.Length > 0)
            {
                for (int i = 0; i < id.Length; i++)
                {
                    writer.Write(id[i]);
                }
            }

            OnSave(writer);
        }
        public virtual void OnSave(FileWriter writer) { }
        
        public virtual void OnLoad(FileReader reader) { }
    }
}
