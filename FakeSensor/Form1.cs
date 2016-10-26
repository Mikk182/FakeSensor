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
using System.Threading;

namespace FakeSensor
{
    public partial class Form1 : Form
    {
        Pubnub pubnub;
        Thread moveSensorThread;
        Sensor[] sensorArray =
            {
                new Sensor{
                    id = 0,
                    lt = 49.4876274,
                    lg = 0.5741083,
                    gasrate = 8
                  },
                new Sensor{
                    id = 1,
                    lt = 49.4876274,
                    lg = 0.5741083,
                    gasrate = 8
                  },
                new Sensor{
                    id = 2,
                    lt = 49.4876274,
                    lg = 0.5741083,
                    gasrate = 8
                  }
            };

        public Form1()
        {
            InitializeComponent();
            pubnub = new Pubnub("pub-c-4c63bcfd-ef3d-49ff-a17a-5db83c247fe0", "sub-c-476b1cce-9904-11e6-bb35-0619f8945a4f");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSensorThread = new Thread(moveSensor);
            moveSensorThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveSensorThread.Abort();
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

        void moveSensor()
        {
            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );

            while (true)
            {
                Random r = new Random();
                
                foreach (var sensor in sensorArray)
                {
                    var iNumlt = r.Next(-100, 101);
                    var iNumlg = r.Next(-100, 101);
                    var iNumGasrate = r.Next(-1, 2);
                    sensor.lt = sensor.lt + (iNumlt * 0.00002);
                    sensor.lg = sensor.lg + (iNumlg * 0.00002);
                    sensor.gasrate = sensor.gasrate + iNumGasrate;

                    //richTextBox1.Lines = richTextBox1.Lines.Concat(new[] {
                    //    string.Format("{0} {1} {2} {3} {4}", sensor.id, sensor.lt, sensor.lg, sensor.gasrate) }).ToArray();
                }
                
                pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );
                Thread.Sleep(5000);
            }
        }
    }
}
