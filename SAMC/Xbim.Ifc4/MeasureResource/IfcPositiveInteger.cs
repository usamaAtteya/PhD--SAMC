// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Common;
using Xbim.Common.Exceptions;

namespace Xbim.Ifc4.MeasureResource
{
	[ExpressType("IfcPositiveInteger", 995)]
	[DefinedType(typeof(long))]
    // ReSharper disable once PartialTypeWithSinglePart
	public partial struct IfcPositiveInteger : IfcSimpleValue, IExpressValueType, IExpressIntegerType, System.IEquatable<long>
	{ 
		private long _value;
        
		public object Value
        {
            get { return _value; }
        }

 
		long IExpressIntegerType.Value { get { return _value; } }

		public override string ToString()
        {
			return _value.ToString();
        }
        public IfcPositiveInteger(long val)
        {
            _value = val;
        }

		public IfcPositiveInteger(string val)
        {
			_value = System.Convert.ToInt64(val);
        }

        public static implicit operator IfcPositiveInteger(long value)
        {
            return new IfcPositiveInteger(value);
        }

        public static implicit operator long(IfcPositiveInteger obj)
        {
            return obj._value;

        }


        public override bool Equals(object obj)
        {
			if (obj == null && Value == null)
                return true;

            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return ((IfcPositiveInteger) obj)._value == _value;
        }

		public bool Equals(long other)
	    {
	        return this == other;
	    }

        public static bool operator ==(IfcPositiveInteger obj1, IfcPositiveInteger obj2)
        {
            return Equals(obj1, obj2);
        }

        public static bool operator !=(IfcPositiveInteger obj1, IfcPositiveInteger obj2)
        {
            return !Equals(obj1, obj2);
        }

        public override int GetHashCode()
        {
            return Value != null ? _value.GetHashCode() : base.GetHashCode();
        }

		#region IPersist implementation
		void IPersist.Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
		{
			if (propIndex != 0)
				throw new XbimParserException(string.Format("Attribute index {0} is out of range for {1}", propIndex + 1, GetType().Name.ToUpper()));
            _value = value.IntegerVal;
            
		}
		#endregion

		#region IExpressValueType implementation
        System.Type IExpressValueType.UnderlyingSystemType { 
			get 
			{
				return typeof(long);
			}
		}
		#endregion


	}
}
