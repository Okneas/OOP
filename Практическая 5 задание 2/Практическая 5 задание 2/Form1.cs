using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_5_задание_2
{
    public partial class Form1 : Form
    {
        MeasureDataDevice device;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                if(comboBox1.Text == "MASS")
                {
                    if(comboBox2.Text == "Metric")
                    {
                        device = new MeasureMassDevice(Units.Metric);
                    }
                    else
                    {
                        device = new MeasureMassDevice(Units.Imperial);
                    }
                }
                else
                {
                    if (comboBox2.Text == "Metric")
                    {
                        device = new MeasureLengthDevice(Units.Metric);
                    }
                    else
                    {
                        device = new MeasureLengthDevice(Units.Imperial);
                    }
                }
                button2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            device.StartCollecting();
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button7.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            device.StopCollecting();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button7.Enabled = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Очищаем таблицу и получаем сырые данные.
            dataGridView1.ColumnCount = 0;
            int[] RawData;
            RawData = device.GetRawData();
            // Добавляем нужное количество столбцов в таблицу
            // и заполняем ее полученными данными.
            dataGridView1.ColumnCount = RawData.Length;
            for (int i = 0; i < RawData.Length; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(RawData[i]);
                dataGridView1.Rows.Add(row.ToArray());
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Отображаем последнее измеренное значение в метрической системе.
            textBox1.Text = device.MetricValue().ToString();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // Отображаем последнее измеренное значение в имперской системе.
            textBox2.Text = device.ImperialValue().ToString();
        }
    }
    public enum Units
    {
        Metric,
        Imperial
    }
    // Перечисление для типа устройства.
    public enum DeviceType
    {
        LENGTH,
        MASS
    }
    public class DeviceControl
    {
        DeviceType d;
        // Запускаем устройство.
        public static DeviceControl StartDevice(DeviceType type)
        {
            DeviceControl DC = new DeviceControl();
            DC.d = type;
            return DC;
        }
        // Останавливаем устройство.
        public DeviceControl StopDevice()
        {
            return null;
        }
        // Получаем случайное значение от устройства.
        public int TakeMeasurement()
        {
            Random rnd = new Random();
            return rnd.Next(0, 100);
        }
    }
    public interface IMeasureDataDevice
    {
        int[] GetRawData();
        decimal ImperialValue();
        decimal MetricValue();
        void StartCollecting();
        void StopCollecting();
    }
    public class MeasureLengthDevice : MeasureDataDevice, IMeasureDataDevice
    {
        public MeasureLengthDevice(Units units)
        {
            measurementType = DeviceType.LENGTH;
            this.unitsToUse = units;
        }
        // Реализация метода интерфейса IMeasuringDevice для получения значения в метрической системе.
        public override decimal MetricValue()
        {
            if (unitsToUse == Units.Metric)
            {
                return mostRecentMeasure;
            }

            if (unitsToUse == Units.Imperial)
            {
                return mostRecentMeasure * 25.4M;
            }

            return 0;
        }
        // Реализация метода интерфейса IMeasuringDevice для получения значения в имперской системе.
        public override decimal ImperialValue()
        {
            if (unitsToUse == Units.Imperial)
            {
                return mostRecentMeasure;
            }

            if (unitsToUse == Units.Metric)
            {
                return mostRecentMeasure * 0.03937M;
            }

            return 0;
        }

    }
    public class MeasureMassDevice : MeasureDataDevice, IMeasureDataDevice
    {
        public MeasureMassDevice(Units Units)
        {
            measurementType = DeviceType.MASS;
            this.unitsToUse = Units;
        }
        public override decimal ImperialValue()
        {
            if (unitsToUse == Units.Imperial)
            {
                return mostRecentMeasure;
            }
            else
            {
                return mostRecentMeasure * 0.4536m;
            }
        }

        public override decimal MetricValue()
        {
            if (unitsToUse == Units.Metric)
            {
                return mostRecentMeasure;
            }
            else
            {
                return mostRecentMeasure * 2.2046m;
            }
        }
    }
    public abstract class MeasureDataDevice : IMeasureDataDevice
    {
        protected Units unitsToUse;
        protected int[] dataCaptured;
        protected int mostRecentMeasure;
        protected DeviceControl controller;
        protected DeviceType measurementType;
        public int[] GetRawData()
        {
            return dataCaptured;
        }
        /// <summary>
        /// Converts the raw data collected by the measuring device into a metric value.
        /// </summary>
        /// <returns>The latest measurement from the device converted to metric units.</returns>
        public abstract decimal MetricValue();
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        public abstract decimal ImperialValue();
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        public void StartCollecting()
        {
            controller = DeviceControl.StartDevice(measurementType);
            GetMeasurements();
        }
        /// <summary>
        /// Stops the measuring device.
        /// </summary>
        public void StopCollecting()
        {
            if (controller != null)
            {
                controller.StopDevice();
                controller = null;
            }
        }
        private void GetMeasurements()
        {
            dataCaptured = new int[10];
            System.Threading.ThreadPool.QueueUserWorkItem((dummy) =>
            {
                int x = 0;
                Random timer = new Random();
                while (controller != null)
                {
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                    dataCaptured[x] = controller != null ?
                        controller.TakeMeasurement() : dataCaptured[x];
                    mostRecentMeasure = dataCaptured[x];
                    x++;
                    if (x == 10)
                    {
                        x = 0;
                    }
                }
            });
        }

    }
}
