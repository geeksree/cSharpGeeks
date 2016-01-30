using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AuScGen.TestExecutionUtil
{
    public class TestExecute
    {
        public IScreenPrint Print { get; set; }

        public void DoStep(string message, Action action)
        {
            try
            {
                action();
            }
            finally
            {
                Print.ScreenPrint(message);
            }
            //Telerik.ActiveBrowser.Capture().Save(@".\TC02_NavigateToAccountBalancePage\Image" + Guid.NewGuid() + ".png");
        }

        public void DoStep(Action action)
        {
            try
            {
                action();
            }
            finally
            {
                Print.ScreenPrint();
            }
            //Telerik.ActiveBrowser.Capture().Save(@".\TC02_NavigateToAccountBalancePage\Image" + Guid.NewGuid() + ".png");
        }

        public ReadOnlyCollection<StepMessage> GetMessages(string path)
        {
            //var myDeserializer = new XmlSerializer(typeof(StepMessage));
            List<StepMessage> messages = new List<StepMessage>();
            //using (var myFileStream = new FileStream(string.Format(@"{0}\message.xml",path), FileMode.Open))
            //{
            //    messages = (List<StepMessage>)myDeserializer.Deserialize(myFileStream);
            //}

            List<string> lines = File.ReadAllLines(string.Format(@"{0}\message.xml", path)).ToList();
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                messages.Add(new StepMessage
                {
                    StepName = values[0],
                    Message = values[1]
                });
            }
            return messages.AsReadOnly();
        }

    }
}
