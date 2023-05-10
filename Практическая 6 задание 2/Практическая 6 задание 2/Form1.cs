using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практическая_6_задание_2
{
    public partial class Form1 : Form
    {
        MeasureDataDevice device;
        public static Form1 myform = new Form1();
        public static int progress;
        public Form1()
        {
            InitializeComponent();
            
        }
        public enum Units
        {
            Imperial,
            Metric
        }
        public interface IMeasuringDevice
        {
            /// <summary>
            /// Converts the raw data collected by the measuring device into a metric value.
            /// </summary>
            /// <returns>The latest measurement from the device converted to metric units.</returns>
            decimal MetricValue();
            /// <summary>
            /// Converts the raw data collected by the measuring device into an imperial value.
            /// </summary>
            /// <returns>The latest measurement from the device converted to imperial units.</returns>
            decimal ImperialValue();
            /// <summary>
            /// Starts the measuring device.
            /// </summary>
            void StartCollecting();
            /// <summary>
            /// Stops the measuring device. 
            /// </summary>
            void StopCollecting();
            /// <summary
            /// Enables access to the raw data from the device in whatever units are native to the device
            /// </summary>
            /// <returns>The raw data from the device in native format.</returns>
            int[] GetRawData();
            /// <summary>
            /// Returns the file name of the logging file for the device.
            /// </summary>
            /// <returns>The file name of the logging file.</returns>
            string GetLoggingFile();
            /// <summary>
            /// Gets the Units used natively by the device.
            /// </summary>
            Units UnitsToUse { get; }
            /// <summary>
            /// Gets an array of the measurements taken by the device.
            /// </summary>
            int[] DataCaptured { get; }
            /// <summary>
            /// Gets the most recent measurement taken by the device.
            /// </summary>
            int MostRecentMeasure { get; }
            /// <summary>
            /// Gets or sets the name of the logging file used. 
            /// If the logging file changes this closes the current file and creates the new file
            /// </summary>
            string LoggingFileName { get; set; }
        }
        public interface IEventEnabledMeasuringDevice : IMeasuringDevice
        {
            event EventHandler NewMeasurementTaken;
            event HeartBeatEventHandler HeartBeat;
            int HeartBeatInterval { get; }

        }
        public class HeartBeatEventArgs : EventArgs
        {
            public DateTime TimeStamp { get; }

            public HeartBeatEventArgs() : base()
            {
                TimeStamp = DateTime.Now;
            }
        }
        public delegate void HeartBeatEventHandler(object sender, HeartBeatEventArgs args);
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
        public class MeasureLengthDevice : MeasureDataDevice, IMeasuringDevice
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
        public class MeasureMassDevice : MeasureDataDevice, IMeasuringDevice
        {
            public MeasureMassDevice(int interval, string logname, Units Units)
            {
                HeartBeatInterval = interval;
                logFileName = logname;
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
        public abstract class MeasureDataDevice : IEventEnabledMeasuringDevice
        {
            public string logFileName;
            private BackgroundWorker heartBeatTimer;
            protected int heartBeatIntervalTime;
            public int HeartBeatInterval { get; set; }
            public event HeartBeatEventHandler HeartBeat;
            public StreamWriter loggingFileWriter;
            public bool disposed = false;
            private BackgroundWorker dataCollector;
            protected Units unitsToUse;
            protected int[] dataCaptured;
            protected int mostRecentMeasure;
            protected DeviceControl controller;
            protected DeviceType measurementType;
            public event EventHandler NewMeasurementTaken;
            public Units UnitsToUse { get; set; }
            public int[] DataCaptured { get; set; }
            public int MostRecentMeasure { get; set; }
            public string LoggingFileName { get; set; }
            protected virtual void OnHeartBeat()
            {
                if (HeartBeat != null)
                {
                    HeartBeat(this, new HeartBeatEventArgs());
                }
            }
            protected virtual void OnNewMeasurementTaken()
            {
                if (NewMeasurementTaken != null)
                {
                    NewMeasurementTaken.Invoke(this, null);
                }
            }
            public void Dispose()
            {
                // Очистка ресурсов
                StopCollecting();
                StopHeartBeat();
                if (heartBeatTimer != null)
                {
                    heartBeatTimer.Dispose();
                }
                // Освобождение объекта BackgroundWorker
                if (dataCollector != null)
                {
                    dataCollector.Dispose();
                }
            }
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
                loggingFileWriter = new StreamWriter(logFileName);
                controller = DeviceControl.StartDevice(measurementType);
                StartHeartBeat();
                GetMeasurements();
            }
            /// <summary>
            /// Stops the measuring device.
            /// </summary>
            public void StopCollecting()
            {
                // Закрытие StreamWriter для записи данных в текстовый файл
                if (loggingFileWriter != null)
                {
                    loggingFileWriter.Close();
                }
                if (dataCollector != null)
                {
                    disposed = true;
                    dataCollector.CancelAsync();
                }
            }
            private void GetMeasurements()
            {
                // Создание экземпляра объекта dataCollector
                dataCollector = new BackgroundWorker();
                dataCollector.WorkerReportsProgress = true;
                dataCollector.ProgressChanged += dataCollector_ProgressChanged;
                // Добавление необходимых свойств для асинхронной операции
                dataCollector.WorkerSupportsCancellation = true;
                dataCollector.WorkerReportsProgress = true;

                // Добавление обработчика событий для выполнения асинхронной операции
                dataCollector.DoWork += new DoWorkEventHandler(dataCollector_DoWork);

                // Добавление обработчика событий для обновления прогресса выполнения задачи
                dataCollector.ProgressChanged += new ProgressChangedEventHandler(dataCollector_ProgressChanged);

                // Запуск выполнения асинхронной операции
                dataCollector.RunWorkerAsync();
            }
            private void dataCollector_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                // Вызов события NewMeasurementTaken для уведомления UI об обновленном значении
                OnNewMeasurementTaken();
                progress = e.ProgressPercentage;
            }
            public void dataCollector_DoWork(object sender, DoWorkEventArgs e)
            {
                // Создание массива для хранения измерений
                dataCaptured = new int[10];

                // Инициализация переменной, используемой для индексации массива
                int i = 0;
                Random timer = new Random();
                // Начало бесконечного цикла сборки данных
                while (!dataCollector.CancellationPending)
                {
                    System.Threading.Thread.Sleep(timer.Next(1000, 5000));
                    // Получение новых измерений
                    int newMeasurement = controller.TakeMeasurement();
                    // Добавление новых измерений в массив dataCaptured
                    dataCaptured[i] = newMeasurement;
                    // Обновление значения свойства mostRecentCapture
                    mostRecentMeasure = dataCaptured[i];
                    // Проверка, не уничтожен ли объект MeasureDataDevice
                    if (disposed)
                    {
                        break;
                    }
                    // Проверка, есть ли использование лог файла
                    if (loggingFileWriter != null)
                    {
                        // Пишем запись в лог файл
                        string logEntry = "Measurement - " + mostRecentMeasure.ToString();
                        loggingFileWriter.WriteLine(logEntry);
                    }
                    // Уведомляем о ходе работы
                    dataCollector.ReportProgress(i * 10);
                    // Увеличение значения i и проверка границ массива
                    i++;
                    if (i > 9)
                    {
                        i = 0;
                    }
                }
            }
            public string GetLoggingFile()
            {
                return LoggingFileName;
            }
            private void StartHeartBeat()
            {
                heartBeatTimer = new BackgroundWorker();
                heartBeatTimer.WorkerSupportsCancellation = true;
                heartBeatTimer.WorkerReportsProgress = true;

                heartBeatTimer.DoWork += (o, args) =>
                {
                    while (!heartBeatTimer.CancellationPending)
                    {
                        System.Threading.Thread.Sleep(HeartBeatInterval);

                        if (heartBeatTimer.CancellationPending)
                        {
                            break;
                        }

                        heartBeatTimer.ReportProgress(0);
                    }

                    args.Cancel = true;
                };

                heartBeatTimer.ProgressChanged += (sender, e) =>
                {
                    OnHeartBeat();
                };

                heartBeatTimer.RunWorkerAsync();
            }
            public void StopHeartBeat()
            {
                if (heartBeatTimer != null && heartBeatTimer.IsBusy)
                {
                    heartBeatTimer.CancelAsync();
                    heartBeatTimer.Dispose();
                    heartBeatTimer = null;
                }
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MASS")
            {
                if (comboBox2.Text == "Metric")
                {
                    device = new MeasureMassDevice(1000, "log.txt", Units.Metric);
                }
                else
                {
                    device = new MeasureMassDevice(1000, "log.txt", Units.Imperial);
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
            button3.Enabled = true;
            button4.Enabled = true;
            timer1.Start();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            device.StartCollecting();
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
            device.StopCollecting();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            device.HeartBeat += (o, args) =>
            {
                label1.Text = "HeartBeat Timestamp: " + args.TimeStamp.ToString();
            };
        }
    }
}
