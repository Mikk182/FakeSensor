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
    public partial class Form2 : Form
    {
        Pubnub pubnub;
        List<Sensor> sensorArray = null;

        public Form2()
        {
            InitializeComponent();

            pubnub = new Pubnub("pub-c-4c63bcfd-ef3d-49ff-a17a-5db83c247fe0", "sub-c-476b1cce-9904-11e6-bb35-0619f8945a4f");

            sensorArray = new List<Sensor>();

            //Capteur 1
            textBox1.Text = "49,463645";
            textBox2.Text = "0,121272";
            textBox3.Text = "1";
            textBox4.Text = "1";
            textBox5.Text = "1";
            textBox6.Text = "1";

            // Capteur 2
            textBox7.Text = "49,459193";
            textBox8.Text = "0,152331";
            textBox9.Text = "1";
            textBox10.Text = "1";
            textBox11.Text = "1";
            textBox12.Text = "1";

            // Capteur 3
            textBox13.Text = "49,467037";
            textBox14.Text = "0,150580";
            textBox15.Text = "1";
            textBox16.Text = "1";
            textBox17.Text = "1";
            textBox18.Text = "1";
            
            // Capteur 4
            textBox19.Text = "49,470711";
            textBox20.Text = "0,126258";
            textBox21.Text = "1";
            textBox22.Text = "1";
            textBox23.Text = "1";
            textBox24.Text = "1";
        }

        private Sensor getSensor1()
        {
            var sensor = new Sensor
            {
                id = 1,
                lt = double.Parse(textBox1.Text),
                lg = double.Parse(textBox2.Text),
                gasArray = new Dictionary<string, int>
                {
                    {"CH4", int.Parse(textBox3.Text) },
                    {"AS", int.Parse(textBox4.Text) },
                    {"CO", int.Parse(textBox5.Text) },
                    {"C", int.Parse(textBox6.Text) }
                }
            };
            return sensor;
        }

        private Sensor getSensor2()
        {
            var sensor = new Sensor
            {
                id = 2,
                lt = double.Parse(textBox7.Text),
                lg = double.Parse(textBox8.Text),
                gasArray = new Dictionary<string, int>
                {
                    {"CH4", int.Parse(textBox9.Text) },
                    {"AS", int.Parse(textBox10.Text) },
                    {"CO", int.Parse(textBox11.Text) },
                    {"C", int.Parse(textBox12.Text) }
                }
            };
            return sensor;
        }

        private Sensor getSensor3()
        {
            var sensor = new Sensor
            {
                id = 3,
                lt = double.Parse(textBox13.Text),
                lg = double.Parse(textBox14.Text),
                gasArray = new Dictionary<string, int>
                {
                    {"CH4", int.Parse(textBox15.Text) },
                    {"AS", int.Parse(textBox16.Text) },
                    {"CO", int.Parse(textBox17.Text) },
                    {"C", int.Parse(textBox18.Text) }
                }
            };
            return sensor;
        }

        private Sensor getSensor4()
        {
            var sensor = new Sensor
            {
                id = 4,
                lt = double.Parse(textBox19.Text),
                lg = double.Parse(textBox20.Text),
                gasArray = new Dictionary<string, int>
                {
                    {"CH4", int.Parse(textBox21.Text) },
                    {"AS", int.Parse(textBox22.Text) },
                    {"CO", int.Parse(textBox23.Text) },
                    {"C", int.Parse(textBox24.Text) }
                }
            };
            return sensor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sensor = getSensor1();

            sensorArray = new List<Sensor> { sensor };

            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
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

        private void button2_Click(object sender, EventArgs e)
        {
            var sensor = getSensor2();

            sensorArray = new List<Sensor> { sensor };

            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sensor = getSensor3();

            sensorArray = new List<Sensor> { sensor };

            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var sensor = getSensor4();

            sensorArray = new List<Sensor> { sensor };

            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var sensor1 = getSensor1();
            var sensor2 = getSensor2();
            var sensor3 = getSensor3();
            var sensor4 = getSensor4();

            sensorArray = new List<Sensor> { sensor1, sensor2, sensor3, sensor4 };

            pubnub.Publish<string>(
                       "Sensors",
                       sensorArray,
                       true,
                       "test",
                       DisplayReturnMessage,
                       DisplayErrorMessage
                 );
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
