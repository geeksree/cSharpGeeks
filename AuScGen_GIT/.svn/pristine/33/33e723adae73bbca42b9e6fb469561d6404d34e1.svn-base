using ArtOfTest.WebAii.Controls;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuScGen.Pages.Utils
{
    public class Wait
    {
        private TelerikPlugin.TelerikFramework Telerik;
        public Wait(TelerikPlugin.TelerikFramework telerik)
        {
            Telerik = telerik;
        }

        

        public delegate bool waitForTrueAction();
        public bool WaitforAction(waitForTrueAction decisionAction, int MaxWaitTime)
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;

            while (false == decisionAction() && timeElapsed < MaxWaitTime)
            {
                Telerik.ActiveBrowser.RefreshDomTree();
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return decisionAction();
        }

        public delegate HtmlControl waitForHtmlControlAction();
        public HtmlControl WaitforAction(waitForHtmlControlAction decisionAction, int MaxWaitTime)
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;

            while (null == decisionAction() && timeElapsed < MaxWaitTime)
            {
                Telerik.ActiveBrowser.RefreshDomTree();
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return decisionAction();
        }

        public delegate Object waitForObjectAction();
        public Object WaitforAction(waitForObjectAction decisionAction, int MaxWaitTime)
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;

            while (null == decisionAction() && timeElapsed < MaxWaitTime)
            {
                Telerik.ActiveBrowser.RefreshDomTree();
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return decisionAction();
        }

        public delegate T waitForObjectAction<T>();
        public T WaitforAction<T>(waitForObjectAction decisionAction, int MaxWaitTime)
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;
            if (!typeof(T).Name.Contains("ReadOnlyCollection"))
            {
                while (null == decisionAction() && timeElapsed < MaxWaitTime)
                {
                    Telerik.ActiveBrowser.RefreshDomTree();
                    timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
                }
            }
            else
            {
                while (null == decisionAction() && timeElapsed < MaxWaitTime / 2)
                {
                    Telerik.ActiveBrowser.RefreshDomTree();
                    timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
                }

                if (null != decisionAction())
                {
                    WaitforAction(() =>
                    {
                        return (int)typeof(T).GetProperty("Count").GetValue(decisionAction()) > 0;
                    }, Config.PageClassSettings.Default.MaxTimeoutValue / 2);
                }
            }

            return (T)decisionAction();
        }

        public T WaitforNullAction<T>(waitForObjectAction decisionAction, int MaxWaitTime)
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;
            while (null != decisionAction() && timeElapsed < MaxWaitTime)
            {
                var test = decisionAction();
                Telerik.ActiveBrowser.RefreshDomTree();
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return (T)decisionAction();
        }

        public delegate T waitForCountAction<T>() where T : ICollection;
        public T WaitforCountAction<T>(waitForCountAction<T> decisionAction, int countValue, int MaxWaitTime) where T : ICollection
        {
            DateTime start;
            double timeElapsed = 0;
            Telerik.ActiveBrowser.RefreshDomTree();

            start = DateTime.Now;

            int test = 3;
            while (decisionAction().Count != countValue && timeElapsed < MaxWaitTime)
            {
                test = decisionAction().Count;
                Telerik.ActiveBrowser.RefreshDomTree();
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }
            //int test2 = test;
            return (T)decisionAction();
        }
    }
}
