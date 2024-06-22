using UnityEngine;

namespace RuntimeNodeEditor.Data
{
    public static class UIData
    {
        public static bool TabOpened, WindowOpened = false;
        
        public static GameObject NodePanel;
        
        public static bool NodesCanvasIsActive => TabOpened || WindowOpened;
    }
}
