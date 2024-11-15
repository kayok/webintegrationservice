/*
* (c) Copyright, Real-Time Innovations, 2021.  All rights reserved.
* RTI grants Licensee a license to use, modify, compile, and create derivative
* works of the software solely for use with RTI Connext DDS. Licensee may
* redistribute copies of the software provided that all such copies are subject
* to this license. The software is provided "as is", with no warranty of any
* type, including any warranty for fitness for any purpose. RTI is under no
* obligation to maintain or support the software. RTI shall not be liable for
* any incidental or consequential damages arising out of the use or inability
* to use the software.
*/

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Rti.Dds.Core;
using Rti.Dds.Domain;
using Rti.Dds.Publication;
using Rti.Dds.Topics;

namespace web
{
    /// <summary>
    /// Example application that publishes web.SensorData.
    /// </summary>
    public static class SensorDataPublisher
    {
        /// <summary>
        /// Runs the publisher example.
        /// </summary>
        public static void RunPublisher(int domainId, int sampleCount)
        {
            // A DomainParticipant allows an application to begin communicating in
            // a DDS domain. Typically there is one DomainParticipant per application.
            // DomainParticipant QoS is configured in USER_QOS_PROFILES.xml
            //
            // A participant needs to be Disposed to release middleware resources.
            // The 'using' keyword indicates that it will be Disposed when this
            // scope ends.
            using DomainParticipant participant = DomainParticipantFactory.Instance.CreateParticipant(domainId);

            // A Topic has a name and a datatype.
           // Topic<SensorData> topic = participant.CreateTopic<SensorData>("t");
              Topic<SensorData> topic = participant.CreateTopic<SensorData>("RTI_Sensor_Topic", TopicQos.Default);

            // A Publisher allows an application to create one or more DataWriters
            // Publisher QoS is configured in USER_QOS_PROFILES.xml
            Publisher publisher = participant.CreatePublisher();

            // This DataWriter will write data on Topic "Example SensorData"
            // DataWriter QoS is configured in USER_QOS_PROFILES.xml
            DataWriter<SensorData> writer = publisher.CreateDataWriter(topic);

            // var sample = new SensorData();
            // for (int count = 0; count < sampleCount; count++)
            // {
            //     // Modify the data to be sent here
            //     sample.datetime = count;

            //     Console.WriteLine($"Writing SensorData, count {count}");

            //     writer.Write(sample);

            //     Thread.Sleep(1000);
            // }

            // สร้างและกำหนดค่า Sample
            // สร้าง DateTime ปัจจุบัน
DateTime now = DateTime.Now;

// แปลงเป็น Unix timestamp (จำนวนวินาทีจาก Epoch)
long unixTimestamp = ((DateTimeOffset)now).ToUnixTimeSeconds();
        SensorData sample = new SensorData();
        sample.datetime = 1700000000;
        sample.machine = "Machine_1";
        sample.temperature = 25.5f;
        sample.humidity = 60.0f;
        sample.pressure = 1013.25f;
        sample.feellike = 27.0f;

        // ส่ง Sample ไปยัง Topic
        writer.Write(sample);
        Console.WriteLine("Data sent: " + sample);

        // รอจนกว่าจะออก
        Console.WriteLine("Press Enter to exit...");
        Console.ReadLine();

        // ปิดการเชื่อมต่อ
        participant.Dispose();
        }
    }
} // namespace web
