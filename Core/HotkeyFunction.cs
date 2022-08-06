using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TabletMaster.Core
{
    public class HotkeyFunction
    {
        // Properties
        public ModifierKeys Modifier { get; set; }
        public Key Key { get; set; }
        public Action CallbackFunction { get; set; }
        public bool CanExecute { get; set; }

        private MousePosition MousePosition { get; set; }

        private Dictionary<HotkeyFunction, MousePosition> MousePositionDict = new Dictionary<HotkeyFunction, MousePosition>();


        // Simple constructor
        public HotkeyFunction(ModifierKeys modifier, Key key, Action callbackFunc, MousePosition mousePos = null, bool canExecute = true)
        {
            this.Modifier = modifier;
            this.Key = key;
            this.CallbackFunction = callbackFunc;
            this.CanExecute = canExecute;
            this.MousePosition = mousePos;

            MousePositionDict.Add(this, mousePos);
        }

        // We create a constructor that takes strings in order to use XML and app values or strings to instantiate Hotkeys
        public HotkeyFunction(string modifier, string key, Action callbackFunc, MousePosition mousePos = null, bool canExecute = true)
        {
            // Use our regulate methods in order to work with the new strings in this constructor
            this.Modifier = RegulateModifier(modifier);
            this.Key = RegulateKey(key);

            // The rest get normal value declarations
            this.CallbackFunction = callbackFunc;
            this.CanExecute = canExecute;
            this.MousePosition = mousePos;

            MousePositionDict.Add(this, mousePos);
        }

        /// <summary>
        /// This method regulates the strings passed into it as ModifierKeys, and returns the matching ModifierKey, or returns none.
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns> a ModifierKeys value matching the string passed </returns>
        private ModifierKeys RegulateModifier(string modifier)
        {
            switch (modifier)
            {
                case "Control":
                case "CTRL":
                    return ModifierKeys.Control;
                case "Alt":
                case "ALT":
                    return ModifierKeys.Alt;
                case "Shift":
                case "SHIFT":
                    return ModifierKeys.Shift;

                default:
                    return ModifierKeys.None;
            }
        }

        /// <summary>
        /// This method regulates the strings passed into it as keys, and returns the key it has parsed, or throws an exception.
        /// </summary>
        /// <param name="key"></param>
        /// <returns> a matching Key from the string passed into it </returns>
        /// <exception cref="ArgumentNullException"></exception>
        private Key RegulateKey(string key)
        {
            Key keyParsed;
            bool keyWasParsed = Enum.TryParse(key, out keyParsed);

            if (keyWasParsed)
            {
                return keyParsed;
            }

            throw new ArgumentNullException(nameof(keyParsed));
        }

        public MousePosition getMousePos()
        {
            if(MousePositionDict.TryGetValue(this, out var mousePos))
            {
                return mousePos;
            }
            return new MousePosition(0, 0);
        }

        // Override ToString to get a more pleasant string returned when using it
        public override string ToString()
        {
            if(this.MousePosition != null)
            {
                return $"Modifier: {Modifier} Key: {Key} MousePos(X,Y): {MousePosition.ToString()}";
            }
            return $"Modifier: {Modifier} Key: {Key}";
        }

    }
}