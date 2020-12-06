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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXSinclair.Machines.Z80
{
    // http://www.z80.info/zip/z80cpu_um.pdf
    // http://www.z80.info/zip/z80-documented.pdf
    // https://worldofspectrum.org/z88forever/dn327/z80undoc.htm
    // https://worldofspectrum.org/faq/resources/documents.htm
    // http://biblioteca.museo8bits.es/index.php
    // https://trastero.speccy.org/cosas/Libros/Libros.htm
    // https://www.imd.guru/retropedia/desarrollo/z80/opcodes.html

    public class MachineZ80 : Machine
    {
        protected Regs mRegs = new Regs();

        public MachineZ80() : base()
        {
            mTSatesFetchOpCode = 4;
            mTSatesReadMem = 3;
            mTSatesCounterSync = mTSatesToSync = 224 * 312;
        }

        public Regs Regs => mRegs;

        public override void Reset()
        {
            base.Reset();
            mRegs.Reset();
        }

        protected override byte FetchOpCode() => PeekByte(mRegs.GetPCAndInc());

        protected byte ReadMemBytePC() => ReadMemByte(mRegs.GetPCAndInc());

        protected override void ExecOpCode(int argOpCode)
        {
            mRegs.RefreshR();

            base.ExecOpCode(argOpCode);
        }

        protected override void FillTableOpCodes()
        {
            var qR_R1 = from r in OpCodes.Rs from r1 in OpCodes.Rs select (r << 3) | r1;

            Parallel.ForEach(qR_R1, r_r1 => mOpCodes[OpCodes.LD_r_r1 | r_r1] = mRegs.CreateLDR_R1(r_r1));
            Parallel.ForEach(OpCodes.Rs, r =>
                 {
                     var pSet = mRegs.CreateSetR_N(r);

                     mOpCodes[OpCodes.LD_r_n | (r << 3)] = () => LD_R_N(pSet);
                 }
            );
            //FillTableOpCodes
            //(
            //    new Dictionary<byte, Action>
            //    {
            //        [OpCodes.LD_A_N] = LD_A_N,
            //        [OpCodes.LD_B_N] = LD_B_N,
            //        [OpCodes.LD_C_N] = LD_C_N,
            //        [OpCodes.LD_D_N] = LD_D_N,
            //        [OpCodes.LD_E_N] = LD_E_N,
            //        [OpCodes.LD_H_N] = LD_H_N,
            //        [OpCodes.LD_L_N] = LD_L_N,
            //    }
            //);
        }

        //protected void LD_A_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.A = n;
        //}
        //protected void LD_B_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.B = n;
        //}
        //protected void LD_C_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.C = n;
        //}
        //protected void LD_D_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.D = n;
        //}
        //protected void LD_E_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.E = n;
        //}
        //protected void LD_H_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.H = n;
        //}
        //protected void LD_L_N()
        //{
        //    var n = ReadMemBytePC();

        //    mRegs.L = n;
        //}

        protected void LD_R_N(Action<byte> argSetR_N)
        {
            var n = ReadMemBytePC();

            argSetR_N.Invoke(n);
        }
    }
}
