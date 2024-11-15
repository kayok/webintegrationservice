
/*
WARNING: THIS FILE IS AUTO-GENERATED. DO NOT MODIFY.

This file was generated from web.idl
using RTI Code Generator (rtiddsgen) version 3.1.2.
The rtiddsgen tool is part of the RTI Connext DDS distribution.
For more information, type 'rtiddsgen -help' at a command shell
or consult the Code Generator User's Manual.
*/

using System;
using System.Reflection;
using System.Collections.Generic;
using Rti.Types;
using System.Linq;
using Omg.Types;

namespace web
{

    public class SensorData :  IEquatable<SensorData>
    {
        public int datetime { get; set; }

        [Bound(255)]
        public string machine { get; set; } = string.Empty;

        public float temperature { get; set; }

        public float humidity { get; set; }

        public float pressure { get; set; }

        public float feellike { get; set; }

        public SensorData()
        {
        }

        public SensorData(int  datetime, string  machine, float  temperature, float  humidity, float  pressure, float  feellike)
        {
            this.datetime = datetime;
            this.machine = machine;
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            this.feellike = feellike;
        }

        public SensorData(SensorData other)
        {
            if (other == null)
            {
                return;
            }

            this.datetime = other.datetime;
            this.machine = other.machine;
            this.temperature = other.temperature;
            this.humidity = other.humidity;
            this.pressure = other.pressure;
            this.feellike = other.feellike;

        }

        public override int GetHashCode()
        {
            var hash = new HashCode();

            hash.Add(datetime);
            hash.Add(machine);
            hash.Add(temperature);
            hash.Add(humidity);
            hash.Add(pressure);
            hash.Add(feellike);

            return hash.ToHashCode();
        }

        public bool Equals(SensorData other)
        {
            if (other == null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.datetime.Equals(other.datetime) &&
            this.machine.Equals(other.machine) &&
            this.temperature.Equals(other.temperature) &&
            this.humidity.Equals(other.humidity) &&
            this.pressure.Equals(other.pressure) &&
            this.feellike.Equals(other.feellike);
        }

        public override bool Equals(object obj) => this.Equals(obj as SensorData);

        public override string ToString() => SensorDataSupport.Instance.ToString(this);
    }

} // namespace web
