using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoIt;
using System.Drawing;
using System.ComponentModel.Composition;
using Framework;

namespace AuScGen.CommonUtilityPlugin
{
    [Export(typeof(IContainerPlugin))]
    public class AutoITExtension : IContainerPlugin
    {
        private string thistitle;
        private IntPtr thiswindowHandle;

        public AutoITExtension()
        {
            thistitle = string.Empty;
            thiswindowHandle = GetWindowHandle(thistitle);
        }

        public AutoITExtension(string windowTitle, string text = "")
        {
            thistitle = windowTitle;
            thiswindowHandle = GetWindowHandle(windowTitle,text);
        }

        public AutoITExtension GetDialog(string title, string text = "", int timeout = 5000)
        {
            thistitle = title;
            thiswindowHandle = GetWindowHandle(title, text, timeout);
            return this;
        }

        public AutoITExtension(IntPtr windowHandle, int maxLen = 65535)
        {
            thiswindowHandle = windowHandle;
            WinGetTitle(thiswindowHandle, maxLen);
        }

        public bool WaitForWindow(string title, int timeOut)
        {
            DateTime start = DateTime.Now;

            while (!IsWinExists(title) && (DateTime.Now - start).TotalMilliseconds < timeOut) ;

            return (DateTime.Now - start).TotalMilliseconds < timeOut;            
        }

        public IntPtr GetWindowHandle(string title = "", string text = "", int timeout = 10000)
       {
           WaitForWindow(title, timeout);
           return AutoItX.WinGetHandle(title,text);
       }

        private bool IsWinExists(string title)
        {
            return (int)AutoItX.WinGetHandle(title) != 0 ? true : false;
        }

        public int AutoItSetOption(string option, int optionValue)
        {
            return AutoItX.AutoItSetOption(option,optionValue);
        }
        
        public string ClipGet(int maxLen = 1048576)
        {
            return AutoItX.ClipGet(maxLen);
        }

        public void ClipPut(string text)
        {
            AutoItX.ClipPut(text);
        }

        public int ControlClick(string control = "", string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            return AutoItX.ControlClick(thiswindowHandle, ControlGetHandle(control), button, numClicks, x, y);
        }

        public int ControlClick(string title, string text, string control, string button = "left", int numClicks = 1, int x = -2147483647, int y = -2147483647)
        {
            return AutoItX.ControlClick(title, text, control, button, numClicks, x, y);
        }

        public string ControlCommand(string command, string extra, int maxLen = 65535, string control = "")
        {
            return AutoItX.ControlCommand(thiswindowHandle, ControlGetHandle(control), command, extra, maxLen);
        }

        public string ControlCommand(string title, string text, string control, string command, string extra, int maxLen = 65535)
        {
            return AutoItX.ControlCommand(title, text, control, command, extra, maxLen);
        }

        public int ControlDisable(string control = "")
        {
            return AutoItX.ControlDisable(thiswindowHandle, ControlGetHandle(control));
        }

        public int ControlDisable(string title, string text, string control)
        {
            return AutoItX.ControlDisable(title, text, control);
        }

        public int ControlEnable(string control = "")
        {
            return AutoItX.ControlEnable(thiswindowHandle, ControlGetHandle(control));
        }

        public int ControlEnable(string title, string text, string control)
        {
            return AutoItX.ControlEnable(title, text, control);
        }

        public int ControlFocus(string control = "")
        {
            return AutoItX.ControlFocus(thiswindowHandle, ControlGetHandle(control));
        }
        
        public int ControlFocus(string title, string text, string control)
        {
            return AutoItX.ControlFocus(title, text, control);
        }

        public string ControlGetFocus(IntPtr winHandle, int maxLen = 65535)
        {
            return AutoItX.ControlGetFocus(thiswindowHandle, maxLen);
        }

        public string ControlGetFocus(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.ControlGetFocus(title = "", text = "", maxLen);
        }

        public IntPtr ControlGetHandle(string control = "")
        {
            return AutoItX.ControlGetHandle(thiswindowHandle, control);
        }

        public string ControlGetHandleAsText(string title = "", string text = "", string control = "", int maxLen = 65535)
        {
            return AutoItX.ControlGetHandleAsText(title, text, control, maxLen);
        }

        public Rectangle ControlGetPos(IntPtr winHandle, string control = "")
        {
            return AutoItX.ControlGetPos(thiswindowHandle, ControlGetHandle(control));
        }

        public Rectangle ControlGetPos(string title = "", string text = "", string control = "")
        {
            return AutoItX.ControlGetPos(title, text, control);
        }

        public string ControlGetText(string control = "", int maxLen = 65535)
        {
            return AutoItX.ControlGetText(thiswindowHandle, ControlGetHandle(control), maxLen);
        }

        public string ControlGetText(string title, string text, string control, int maxLen = 65535)
        {
            return AutoItX.ControlGetText(title, text, control, maxLen);
        }

        public int ControlHide(string control = "")
        {
            return AutoItX.ControlHide(thiswindowHandle, ControlGetHandle(control));
        }

        public int ControlHide(string title, string text, string control)
        {
            return AutoItX.ControlHide(title, text, control);
        }

        public string ControlListView(string command, string extra1, string extra2, string control = "", int maxLen = 65535)
        {
            return AutoItX.ControlListView(thiswindowHandle, ControlGetHandle(control), command, extra1, extra2, maxLen = 65535);
        }

        public string ControlListView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            return AutoItX.ControlListView(title, text, control, command, extra1, extra2, maxLen);
        }

        public int ControlMove(int x, int y, int width = -1, int height = -1, string control = "")
        {
            return AutoItX.ControlMove(thiswindowHandle, ControlGetHandle(control), x, y, width, height);
        }

        public int ControlMove(string title, string text, string control, int x, int y, int width = -1, int height = -1)
        {
            return AutoItX.ControlMove(title, text, control, x, y, width, height);
        }

        public int ControlSend(string sendText, int mode = 0, string control = "")
        {
            return AutoItX.ControlSend(thiswindowHandle, ControlGetHandle(control), sendText, mode);
        }

        public int ControlSend(string title, string text, string control, string sendText, int mode = 0)
        {
            return AutoItX.ControlSend(title, text, control, sendText, mode);
        }

        public int ControlSetText(string controlText, string control = "")
        {
            return AutoItX.ControlSetText(thiswindowHandle, ControlGetHandle(control), controlText);
        }
        public int ControlSetText(string title, string text, string control, string controlText)
        {
            return AutoItX.ControlSetText(title, text, control, controlText);
        }
        public int ControlShow(string control = "")
        {
            return AutoItX.ControlShow(thiswindowHandle, ControlGetHandle(control));
        }

        public int ControlShow(string title, string text, string control)
        {
            return AutoItX.ControlShow(title, text, control);
        }

        public string ControlTreeView(string command, string extra1, string extra2, string control = "", int maxLen = 65535)
        {
            return AutoItX.ControlTreeView(thiswindowHandle, ControlGetHandle(control), command, extra1, extra2, maxLen);
        }

        public string ControlTreeView(string title, string text, string control, string command, string extra1, string extra2, int maxLen = 65535)
        {
            return AutoItX.ControlTreeView(title, text, control, command, extra1, extra2, maxLen);
        }

        public string DriveMapAdd(string device, string share, int flags = 0, string user = "", string password = "")
        {
            return AutoItX.DriveMapAdd(device, share, flags = 0, user = "", password = "");
        }

        public int DriveMapDel(string device)
        {
            return AutoItX.DriveMapDel(device);
        }

        public string DriveMapGet(string device)
        {
            return AutoItX.DriveMapGet(device);
        }

        public int ErrorCode()
        {
            return AutoItX.ErrorCode();
        }

        public void Init()
        {
            AutoItX.Init();
        }

        public int IsAdmin()
        {
            return AutoItX.IsAdmin();
        }

        public int MouseClick(string button = "LEFT", int x = -2147483647, int y = -2147483647, int numClicks = 1, int speed = -1)
        {
            return AutoItX.MouseClick(button, x, y, numClicks, speed);
        }

        public int MouseClickDrag(string button, int x1, int y1, int x2, int y2, int speed = -1)
        {
            return AutoItX.MouseClickDrag(button, x1, y1, x2, y2, speed);
        }

        public void MouseDown(string button = "LEFT")
        {
            AutoItX.MouseDown(button);
        }
        public int MouseGetCursor()
        {
            return AutoItX.MouseGetCursor();
        }

        public Point MouseGetPos()
        {
            return AutoItX.MouseGetPos();
        }

        public int MouseMove(int x, int y, int speed = -1)
        {
            return AutoItX.MouseMove(x, y, speed);
        }

        public void MouseUp(string button = "LEFT")
        {
            AutoItX.MouseUp(button);
        }

        public void MouseWheel(string direction, int numClicks)
        {
            AutoItX.MouseWheel(direction, numClicks);
        }

        public uint PixelChecksum(Rectangle rect, int step = 1)
        {
            return AutoItX.PixelChecksum(rect, step);
        }

        public int PixelGetColor(int x, int y)
        {
            return AutoItX.PixelGetColor(x, y);
        }

        public Point PixelSearch(Rectangle rect, int color, int shade = 0, int step = 1)
        {
            return AutoItX.PixelSearch(rect, color, shade, step);
        }

        public int ProcessClose(string process)
        {
            return AutoItX.ProcessClose(process);
        }

        public int ProcessExists(string process)
        {
            return AutoItX.ProcessExists(process);
        }

        public int ProcessSetPriority(string process, int priority)
        {
            return AutoItX.ProcessSetPriority(process, priority);
        }

        public int ProcessWait(string process, int timeout)
        {
            return AutoItX.ProcessWait(process, timeout);
        }

        public int ProcessWaitClose(string process, int timeout)
        {
            return AutoItX.ProcessWaitClose(process, timeout);
        }

        public int Run(string program, string dir, int showFlag = 1)
        {
            return AutoItX.Run(program, dir, showFlag);
        }

        public int RunAs(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            return AutoItX.RunAs(user, domain, password, logonFlag, program, dir, showFlag);
        }

        public int RunAsWait(string user, string domain, string password, int logonFlag, string program, string dir, int showFlag = 1)
        {
            return AutoItX.RunAsWait(user, domain, password, logonFlag, program, dir);
        }

        public int RunWait(string program, string dir, int showFlag = 1)
        {
            return AutoItX.RunWait(program, dir, showFlag);
        }

        public void Send(string sendText, int mode = 0)
        {
            AutoItX.Send(sendText, mode);
        }

        public int Shutdown(int flag)
        {
            return AutoItX.Shutdown(flag);
        }

        public void Sleep(int milliseconds)
        {
            AutoItX.Sleep(milliseconds);
        }

        public string StatusBarGetText(int part = 1, int maxLen = 65535)
        {
            return AutoItX.StatusBarGetText(thiswindowHandle, part, maxLen);
        }

        public string StatusBarGetText(string title = "", string text = "", int part = 1, int maxLen = 65535)
        {
            return AutoItX.StatusBarGetText(title, text, part, maxLen);
        }

        public void ToolTip(string tip, int x = -2147483647, int y = -2147483647)
        {
            AutoItX.ToolTip(tip, x, y);
        }

        public int WinActivate()
        {
            return AutoItX.WinActivate(thiswindowHandle);
        }

        public int WinActivate(string title = "", string text = "")
        {
            return AutoItX.WinActivate(title, text);
        }

        public int WinActive()
        {
            return AutoItX.WinActive(thiswindowHandle);
        }

        public int WinActive(string title = "", string text = "")
        {
            return AutoItX.WinActive(title, text);
        }

        public int WinClose()
        {
            return AutoItX.WinClose(thiswindowHandle);
        }

        public int WinClose(string title = "", string text = "")
        {
            return AutoItX.WinClose(title, text);
        }

        public int WinExists()
        {
            return AutoItX.WinExists(thiswindowHandle);
        }

        public int WinExists(string title = "", string text = "")
        {
            return AutoItX.WinExists(title, text);
        }

        public Point WinGetCaretPos()
        {
            return AutoItX.WinGetCaretPos();
        }

        public string WinGetClassList(int maxLen = 65535)
        {
            return AutoItX.WinGetClassList(thiswindowHandle, maxLen);
        }

        public string WinGetClassList(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.WinGetClassList(title, text, maxLen);
        }

        public Rectangle WinGetClientSize()
        {
            return AutoItX.WinGetClientSize(thiswindowHandle);
        }

        public Rectangle WinGetClientSize(string title = "", string text = "")
        {
            return AutoItX.WinGetClientSize(title, text);
        }

        public IntPtr WinGetHandle(string title = "", string text = "")
        {
            return AutoItX.WinGetHandle(title, text);
        }

        public string WinGetHandleAsText(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.WinGetHandleAsText(title, text, maxLen);
        }

        public Rectangle WinGetPos()
        {
            return AutoItX.WinGetPos(thiswindowHandle);
        }

        public Rectangle WinGetPos(string title = "", string text = "")
        {
            return AutoItX.WinGetPos(title, text);
        }

        public uint WinGetProcess(int maxLen = 65535)
        {
            return AutoItX.WinGetProcess(thiswindowHandle, maxLen);
        }

        public uint WinGetProcess(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.WinGetProcess(title, text, maxLen);
        }

        public int WinGetState()
        {
            return AutoItX.WinGetState(thiswindowHandle);
        }

        public int WinGetState(string title = "", string text = "")
        {
            return AutoItX.WinGetState(title, text);
        }

        public string WinGetText(int maxLen = 65535)
        {
            return AutoItX.WinGetText(thiswindowHandle, maxLen);
        }

        public string WinGetText(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.WinGetText(title, text, maxLen);
        }

        public string WinGetTitle(IntPtr winHandle, int maxLen = 65535)
        {
            return AutoItX.WinGetTitle(thiswindowHandle, maxLen);
        }

        public string WinGetTitle(string title = "", string text = "", int maxLen = 65535)
        {
            return AutoItX.WinGetTitle(title, text, maxLen);
        }

        public int WinKill()
        {
            return AutoItX.WinKill(thiswindowHandle);
        }

        public int WinKill(string title = "", string text = "")
        {
            return AutoItX.WinKill(title, text);
        }

        public void WinMinimizeAll()
        {
            AutoItX.WinMinimizeAll();
        }
        public void WinMinimizeAllUndo()
        {
            AutoItX.WinMinimizeAllUndo();
        }

        public int WinMove(int x, int y, int width = -1, int height = -1)
        {
            return AutoItX.WinMove(thiswindowHandle, x, y, width, height);
        }

        public int WinMove(string title, string text, int x, int y, int width = -1, int height = -1)
        {
            return AutoItX.WinMove(title, text, x, y, width, height);
        }

        public int WinSetOnTop(int flag)
        {
            return AutoItX.WinSetOnTop(thiswindowHandle, flag);
        }

        public int WinSetOnTop(string title, string text, int flag)
        {
            return AutoItX.WinSetOnTop(title, text, flag);
        }

        public int WinSetState(int flags)
        {
            return AutoItX.WinSetState(thiswindowHandle, flags);
        }

        public int WinSetState(string title, string text, int flags)
        {
            return AutoItX.WinSetState(title, text, flags);
        }

        public int WinSetTitle(IntPtr winHandle, string newTitle)
        {
            return AutoItX.WinSetTitle(thiswindowHandle, newTitle);
        }

        public int WinSetTitle(string title, string text, string newTitle)
        {
            return AutoItX.WinSetTitle(title, text, newTitle);
        }

        public int WinSetTrans(int trans)
        {
            return AutoItX.WinSetTrans(thiswindowHandle, trans);
        }

        public int WinSetTrans(string title, string text, int trans)
        {
            return AutoItX.WinSetTrans(title, text, trans);
        }

        public int WinWait(int timeout = 0)
        {
            return AutoItX.WinWait(thiswindowHandle, timeout);
        }

        public int WinWait(string title = "", string text = "", int timeout = 0)
        {
            return AutoItX.WinWait(title, text, timeout);
        }

        public int WinWaitActive(int timeout = 0)
        {
            return AutoItX.WinWaitActive(thiswindowHandle, timeout);
        }

        public int WinWaitActive(string title = "", string text = "", int timeout = 0)
        {
            return AutoItX.WinWaitActive(title, text, timeout);
        }

        public int WinWaitClose(int timeout = 0)
        {
            return AutoItX.WinWaitClose(thiswindowHandle, timeout);
        }

        public int WinWaitClose(string title = "", string text = "", int timeout = 0)
        {
            return AutoItX.WinWaitClose(title, text, timeout);
        }

        public int WinWaitNotActive(int timeout = 0)
        {
            return AutoItX.WinWaitNotActive(thiswindowHandle, timeout);
        }

        public int WinWaitNotActive(string title = "", string text = "", int timeout = 0)
        {
            return AutoItX.WinWaitNotActive(title, text, timeout);
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
