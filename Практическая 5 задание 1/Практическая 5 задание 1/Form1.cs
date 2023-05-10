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

namespace Практическая_5_задание_1
{
    public partial class Form1 : Form
    {
        MeasureLengthDevice device;
        public Form1()
        {
            InitializeComponent();  
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(radioMet.Checked == true)
            {
                // Если выбрана метрическая система, создаем
                // экземпляр устройства измерения длины в метрах.
                device = new MeasureLengthDevice(Units.Metric);
            }
            if (radioImp.Checked == true)
            {
                // Если выбрана имперская система, создаем
                // экземпляр устройства измерения длины в дюймах.
                device = new MeasureLengthDevice(Units.Imperial);
            }
            // Включаем кнопки сбора и отображения данных.
            button2.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Запускаем сбор данных устройством.
            device.StartCollecting();
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
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

        private void Button4_Click(object sender, EventArgs e)
        {
            // Отображаем последнее измеренное значение в метрической системе.
            textBox2.Text = device.MetricValue().ToString();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Отображаем последнее измеренное значение в имперской системе.
            textBox1.Text = device.ImperialValue().ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Останавливаем сбор данных устройством и выключаем кнопки.
            device.StopCollecting();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }
    }
    // Класс для управления устройством.
    class DeviceControl
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
    // Перечисление для единиц измерения.
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
    // Интерфейс для устройства измерения.
    public interface IMeasuringDevice
    {
        /// <summary>/// Converts the raw data collected by the measuring device into a metric value
        /// </summary>
        ///<returns>The latest measurement from the device converted to metric units.</returns>
        decimal MetricValue();
        /// <summary>
        /// Converts the raw data collected by the measuring device into an imperial value.
        /// </summary>
        ///<returns>The latest measurement from the device converted to imperial units.</returns>
        decimal ImperialValue();
        /// <summary>
        /// Starts the measuring device.
        /// </summary>
        void StartCollecting();
        /// <summary>
        /// Stops the measuring device. 
        /// </summary>
        void StopCollecting();
        /// <summary>
        /// Enables access to the raw data from the device in whatever units are native to the device
        /// </summary>
        /// <returns>The raw data from the device in native format.</returns>
        int[] GetRawData();
    }
    public interface IMeasureLengthDevice
    {
        int[] GetRawData();
        decimal ImperialValue();
        decimal MetricValue();
        void StartCollecting();
        void StopCollecting();
    }
    // Класс для устройства измерения длины.
    public class MeasureLengthDevice : IMeasuringDevice
    {
        private Units unitsToUse;
        private int[] dataCaptured;
        private int mostRecentMeasure;
        private DeviceControl controller;
        private const DeviceType measurementType = DeviceType.LENGTH;

        public MeasureLengthDevice(Units units)
        {
            this.unitsToUse = units;
        }
        // Реализация метода интерфейса IMeasuringDevice для получения значения в метрической системе.
        public decimal MetricValue()
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
        public decimal ImperialValue()
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
        // Запуск сбора данных устройством.
        public void StartCollecting()
        {
            controller = DeviceControl.StartDevice(measurementType);
            GetMeasurements();
        }
        // Остановка сбора данных устройством.
        public void StopCollecting()
        {
            if (controller != null)
            {
                controller = controller.StopDevice();
            }
        }
        // Получение сырых данных от устройства.
        public int[] GetRawData()
        {
            return dataCaptured;
        }
        // Запуск процесса получения значений от устройства.
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
