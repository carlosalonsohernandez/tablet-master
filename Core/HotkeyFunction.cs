using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TabletMaster.Core
{
    public class HotkeyFunction 
    {
        public ModifierKeys Modifier { get; set; }
        public Key Key { get; set; }
        public Action CallbackFunction { get; set; }
        public bool CanExecute { get; set; }
        public HotkeyFunction(ModifierKeys modifier, Key key, Action callbackFunc, bool canExecute = true)
        {
            this.Modifier = modifier;
            this.Key = key;
            this.CallbackFunction = callbackFunc;
            this.CanExecute = canExecute;
        }
    }
}