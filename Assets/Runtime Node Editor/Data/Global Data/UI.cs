using UnityEngine;

namespace RuntimeNodeEditor.Data
{
    public static partial class GlobalData
    {
        public static bool TabOpened = false;
        public static bool WindowOpened = false;
        
        public static GameObject NodeUIPanel
        {
            get;
            internal set;
        }
        
        public static bool TabOrWindowOpened
        {
            get 
            {
                return TabOpened || WindowOpened;
            }
        }
    }
}
