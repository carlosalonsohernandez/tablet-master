using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;

namespace TabletMaster.Core
{
    /// <summary>
    /// Class responsible for the addition of Hotkey Functionality. Hotkeys will allow the 
    /// logging and execution of functions regardless of the focus on the application.
    /// This means that we can minimize to system tray for convenience.
    /// </summary>
    internal class HotkeysHandler
    {
        // Used by windows for the hook
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // specifies a static method for call back
        private static LowLevelKeyboardProc LowLevelProc = HookCallback;
        private static List<HotkeyFunction> Hotkeys { get; set; }

        //Used for the hook action in Windows ID
        private const int WH_KEYBOARD_LL = 13;
        private static IntPtr HookID = IntPtr.Zero;

        public static bool IsHookSetup { get; set; }

        static HotkeysHandler()
        {
            Hotkeys = new List<HotkeyFunction>();
        }

        public static void StartSysHook()
        {
            HookID = SetHook(LowLevelProc);
            IsHookSetup = true;
        }

        public static void ShutdownSysHook()
        {
            if (IsHookSetup)
            {
                UnhookWindowsHookEx(HookID);
                IsHookSetup = false;
            }

        }

        public static void AddHotkey(HotkeyFunction hotkey)
        {
            Hotkeys.Add(hotkey);
        }

        public static void RemoveHotkey(HotkeyFunction hotkey)
        {
            Hotkeys.Remove(hotkey);
        }

        public static List<HotkeyFunction> getHotkeyList()
        {
            var copiedHotkeysList = new List<HotkeyFunction>(Hotkeys);
            return copiedHotkeysList;
        }

        //Gives the hook the callback
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using(Process currentProcess = Process.GetCurrentProcess())
            {
                using(ProcessModule currentModule = currentProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(currentModule.ModuleName), 0);
                }
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // hotkey scan at this point

            if(nCode >= 0)
            {
                //Check Hotkeys
                foreach(var hotkey in Hotkeys)
                {
                    //use kb class instead of storing in class
                    if(Keyboard.Modifiers == hotkey.Modifier && Keyboard.IsKeyDown(hotkey.Key))
                    {
                        // if callback method can be run
                        if (hotkey.CanExecute)
                        {
                            // ? applies a null check before invoking
                            hotkey.CallbackFunction?.Invoke();
                        }
                    }
                }
            }

            return CallNextHookEx(HookID, nCode, wParam, lParam);  
        }

        // DLL imported methods for setting up the hooks
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int hookID, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr UnhookWindowsHookEx(IntPtr hHookEx);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hHookEx, int nCode, IntPtr wParam, IntPtr lParam);

        //Get the Module Handle
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
