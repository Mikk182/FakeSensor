using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PubNubMessaging.Core;

namespace FakeSensor
{
    public partial class Form1 : Form
    {
        Pubnub pubnub;
        public Form1()
        {
            InitializeComponent();
            pubnub = new Pubnub("pub-c-4c63bcfd-ef3d-49ff-a17a-5db83c247fe0", "sub-c-476b1cce-9904-11e6-bb35-0619f8945a4f");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pubnub.Publish<string>(
            //      "my_channel",
            //      "Hello from the PubNub C# SDK!",
            //      null,null
            //);
            pubnub.Publish<string>(
                  "Sensors",
                  new
                  {id = 11, lt = 49.4876274, lg = 0.5741083, gasrate = 8 },
                  true,
                  "test",
                  DisplayReturnMessage,
                  DisplayErrorMessage
            );
        }
        void DisplayReturnMessage(string result)
        {
            Console.WriteLine("PUBLISH STATUS CALLBACK");
            Console.WriteLine(result);

            //return new Action<string>("DisplayErrorMessage");
        }

        void DisplayErrorMessage(PubnubClientError pubnubError)
        {
            Console.WriteLine(pubnubError.StatusCode);
        }
    }
}
