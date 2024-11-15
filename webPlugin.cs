/*
WARNING: THIS FILE IS AUTO-GENERATED. DO NOT MODIFY.

This file was generated from web.idl
using RTI Code Generator (rtiddsgen) version 3.1.2.
The rtiddsgen tool is part of the RTI Connext DDS distribution.
For more information, type 'rtiddsgen -help' at a command shell
or consult the Code Generator User's Manual.
*/

using System;
using System.Runtime.InteropServices;
using Omg.Types;
using Omg.Types.Dynamic;
using Rti.Types;
using Rti.Dds.Core;
using Rti.Types.Dynamic;
using Rti.Dds.NativeInterface.TypePlugin;

namespace web
{

    namespace Implementation
    {

        public struct SensorDataUnmanaged : Rti.Dds.NativeInterface.TypePlugin.INativeTopicType<web.SensorData>
        {

            private int datetime;
            private NativeString machine;
            private float temperature;
            private float humidity;
            private float pressure;
            private float feellike;

            public void Destroy(bool optionalsOnly)
            {
                if (optionalsOnly)
                {
                    return;
                }
                machine.Destroy();
            }

            public void FromNative(web.SensorData sample, bool keysOnly = false)
            {

                sample.datetime = datetime;
                sample.machine = machine.FromNative();
                sample.temperature = temperature;
                sample.humidity = humidity;
                sample.pressure = pressure;
                sample.feellike = feellike;
            }

            public void Initialize(bool allocatePointers = true, bool allocateMemory = true)
            {
                datetime = (int) 0;
                machine.Initialize(size: ((int) 255), allocateMemory: allocateMemory);
                temperature = (float) 0.0f;
                humidity = (float) 0.0f;
                pressure = (float) 0.0f;
                feellike = (float) 0.0f;
            }

            public void ToNative(web.SensorData sample, bool keysOnly = false)
            {
                datetime = sample.datetime;
                machine.ToNative(sample.machine, ((int) 255));
                temperature = sample.temperature;
                humidity = sample.humidity;
                pressure = sample.pressure;
                feellike = sample.feellike;
            }
        }

        internal class SensorDataPlugin : Rti.Dds.NativeInterface.TypePlugin.InterpretedTypePlugin<web.SensorData, SensorDataUnmanaged>
        {
            internal SensorDataPlugin() : base("web.SensorData", isKeyed: false, CreateDynamicType(isPublic: false))
            {
            }

            public static DynamicType CreateDynamicType(bool isPublic = true)
            {
                var dtf = ServiceEnvironment.Instance.Internal.GetTypeFactory(isPublic);
                var tsf = ServiceEnvironment.Instance.Internal.TypeSupportFactory;

                // SensorData struct
                var SensorDataStructMembers = new StructMember[]
                {
                    new StructMember("datetime", dtf.GetPrimitiveType<int>(), id: 0),
                    new StructMember("machine", dtf.CreateString(((int) 255)), id: 1),
                    new StructMember("temperature", dtf.GetPrimitiveType<float>(), id: 2),
                    new StructMember("humidity", dtf.GetPrimitiveType<float>(), id: 3),
                    new StructMember("pressure", dtf.GetPrimitiveType<float>(), id: 4),
                    new StructMember("feellike", dtf.GetPrimitiveType<float>(), id: 5)
                };

                return tsf.CreateTypeWithAccessInfo<SensorDataUnmanaged>(
                    dtf.BuildStruct()
                    .WithExtensibility(ExtensibilityKind.Extensible)
                    .WithName("web::SensorData")
                    .AddMembers(SensorDataStructMembers));
            }
        }
    }
    public class SensorDataSupport : Rti.Dds.Topics.TypeSupport<web.SensorData>
    {
        public SensorDataSupport() : base(
            new Implementation.SensorDataPlugin(),
            new Lazy<DynamicType>(() =>Implementation.SensorDataPlugin.CreateDynamicType(isPublic: true)))
        {
        }

        public static SensorDataSupport Instance { get; } =
        ServiceEnvironment.Instance.Internal.TypeSupportFactory.CreateTypeSupport<SensorDataSupport, web.SensorData>();
    }

} // namespace web

