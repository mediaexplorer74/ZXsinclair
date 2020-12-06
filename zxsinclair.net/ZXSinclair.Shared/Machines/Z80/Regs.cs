﻿#region LICENSE
/*
    ZXSinclair Emulador ZX Computers make in .Net and .Net CORE
    Copyright (C) 2016 Oscar Hernandez Bano
    This file is part of ZXSincalir.Net.
    ZXSincalir.Net is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.*/
#endregion

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using ZXSinclair.Common;

namespace ZXSinclair.Machines.Z80
{
    [StructLayout(LayoutKind.Explicit)]
    public partial class Regs : IReset
    {
        [FieldOffset(0)]
        public ushort AF = 0;
        [FieldOffset(2)]
        public ushort BC = 0;
        [FieldOffset(4)]
        public ushort DE = 0;
        [FieldOffset(6)]
        public ushort HL = 0;
        //[FieldOffset(8)]
        //public ushort _AF = 0;
        //[FieldOffset(10)]
        //public ushort _BC = 0;
        //[FieldOffset(12)]
        //public ushort _DE = 0;
        //[FieldOffset(14)]
        //public ushort _HL = 0;
        [FieldOffset(16)]
        public ushort IX = 0;
        [FieldOffset(18)]
        public ushort IY = 0;
        [FieldOffset(20)]
        public ushort IR = 0;
        [FieldOffset(22)]
        public ushort PC = 0;
        [FieldOffset(24)]
        public ushort SP = 0;
        //[FieldOffset(26)]
        //public ushort MW = 0;    // MEMPTR


        [FieldOffset(1)]
        public byte A;
        [FieldOffset(0)]
        public byte F;
        [FieldOffset(3)]
        public byte B;
        [FieldOffset(2)]
        public byte C;
        [FieldOffset(5)]
        public byte D;
        [FieldOffset(4)]
        public byte E;
        [FieldOffset(7)]
        public byte H;
        [FieldOffset(6)]
        public byte L;
        //[FieldOffset(17)]
        //public byte XH;
        //[FieldOffset(16)]
        //public byte XL;
        //[FieldOffset(19)]
        //public byte YH;
        //[FieldOffset(18)]
        //public byte YL;
        [FieldOffset(21)]
        public byte I;
        [FieldOffset(20)]
        public byte R;

        //[FieldOffset(27)]
        //public byte MH;
        //[FieldOffset(26)]
        //public byte ML;

        public void Reset()
        {
            AF = BC = DE = HL = IX = IY = PC = SP = 0;
            I = 0;
        }

        public void RefreshR()
        {
            int r = R;

            R = (byte)((r + 1) & 0x7F | (r & 0x80));
        }

        public ushort GetPCAndInc()
        {
            unchecked
            {
                return PC++;
            }
        }

        public Func<byte> CreateGetR(int r) => r switch
        {
            OpCodes.R_A => () => A,
            OpCodes.R_B => () => B,
            OpCodes.R_C => () => C,
            OpCodes.R_D => () => D,
            OpCodes.R_E => () => E,
            OpCodes.R_H => () => H,
            OpCodes.R_L => () => L,
            _ => () => 0
        };

        public Action<byte> CreateSetR_N(int r) => r switch
        {
            OpCodes.R_A => n => A = n,
            OpCodes.R_B => n => B = n,
            OpCodes.R_C => n => C = n,
            OpCodes.R_D => n => D = n,
            OpCodes.R_E => n => E = n,
            OpCodes.R_H => n => H = n,
            OpCodes.R_L => n => L = n,
            _ => nn => { }
        };

        ///// <summary>
        ///// R=r1
        ///// 00rrrrRRR
        ///// </summary>
        ///// <param name="r_r1"></param>
        ///// <returns></returns>
        //public Action CreateLDR_R1(int r_r1)
        //{
        //    switch (r_r1)
        //    {
        //        case (OpCodes.R_A << 3) | OpCodes.R_A:
        //            return () => A = A;
        //    }

        //    return null;
        //}

        public Action CreateLDR_R1_2(int r_r1) => r_r1 switch
        {
            (OpCodes.R_A << 3) | OpCodes.R_A => () => A = A,
            (OpCodes.R_A << 3) | OpCodes.R_B => () => A = B,
        };
    }
}
