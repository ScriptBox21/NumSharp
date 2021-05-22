﻿using System;
using System.Threading.Tasks;
using DecimalMath;
using NumSharp.Utilities;

namespace NumSharp.Backends
{
    public partial class DefaultEngine
    {
        public override NDArray Exp2(in NDArray nd, Type dtype) => Exp2(nd, dtype?.GetTypeCode());

        public override NDArray Exp2(in NDArray nd, NPTypeCode? typeCode = null)
        {


            if (nd.size == 0)
                return nd.Clone();

            var @out = Cast(nd, typeCode ?? nd.typecode, copy: true);
            var len = @out.size;

            unsafe
            {
                switch (@out.GetTypeCode)
                {
#if _REGEN

                    %foreach except(supported_numericals, "Decimal"),except(supported_numericals_lowercase, "decimal")%
	                case NPTypeCode.#1:
	                {
                        var out_addr = (#2*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.To#1(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                %
                    case NPTypeCode.Decimal:
                    {
                        var out_addr = (decimal*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = DecimalEx.Pow(2, out_addr[i]);
                        return @out;
	                }
	                default:
		                throw new NotSupportedException();
#else
	                case NPTypeCode.Byte:
	                {
                        var out_addr = (byte*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToByte(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Int16:
	                {
                        var out_addr = (short*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToInt16(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.UInt16:
	                {
                        var out_addr = (ushort*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToUInt16(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Int32:
	                {
                        var out_addr = (int*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToInt32(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.UInt32:
	                {
                        var out_addr = (uint*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToUInt32(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Int64:
	                {
                        var out_addr = (long*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToInt64(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.UInt64:
	                {
                        var out_addr = (ulong*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToUInt64(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Char:
	                {
                        var out_addr = (char*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToChar(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Double:
	                {
                        var out_addr = (double*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToDouble(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
	                case NPTypeCode.Single:
	                {
                        var out_addr = (float*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = Converts.ToSingle(Math.Pow(2, out_addr[i]));
                        return @out;
	                }
                    case NPTypeCode.Decimal:
                    {
                        var out_addr = (decimal*)@out.Address;
                        for (int i = 0; i < len; i++) out_addr[i] = DecimalEx.Pow(2, out_addr[i]);
                        return @out;
	                }
	                default:
		                throw new NotSupportedException();
#endif
                }
            }
        }
    }
}
