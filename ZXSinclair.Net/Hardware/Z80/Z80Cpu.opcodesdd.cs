#region LICENSE
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

namespace ZXSinclair.Net.Hardware.Z80;

public partial class Z80Cpu
{

    public void LD_M_IX_PLUS_D_M_A()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.A);
    }

    public void LD_M_IX_PLUS_D_M_B()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.B);
    }

    public void LD_M_IX_PLUS_D_M_C()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.C);
    }

    public void LD_M_IX_PLUS_D_M_D()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.D);
    }

    public void LD_M_IX_PLUS_D_M_E()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.E);
    }

    public void LD_M_IX_PLUS_D_M_H()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.H);
    }

    public void LD_M_IX_PLUS_D_M_L()
    {
        var r = Regs;
        var d = (sbyte)ReadMemory(Regs.GetPCAndInc());

        Ticks.AddCycles(5);

        var nn =r.GetIX_d(d);

        WriteMemory(nn, r.L);
    }

    public void ExecOpCodeDD(byte opcode)
    {
        switch (opcode)
        {
			// 0x09 ADD REGISTER,BC
			case (byte)Z80OpCodesDD.ADD_IX_BC:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x19 ADD REGISTER,DE
			case (byte)Z80OpCodesDD.ADD_IX_DE:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x21 LD REGISTER,nnnn
			case (byte)Z80OpCodesDD.LD_IX_nnnn:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x22 LD (nnnn),REGISTER
			case (byte)Z80OpCodesDD.LD_MM_nnnn_MM_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x23 INC REGISTER
			case (byte)Z80OpCodesDD.INC_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x24 INC REGISTERH
			case (byte)Z80OpCodesDD.INC_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x25 DEC REGISTERH
			case (byte)Z80OpCodesDD.DEC_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x26 LD REGISTERH,nn
			case (byte)Z80OpCodesDD.LD_IXH_nn:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x29 ADD REGISTER,REGISTER
			case (byte)Z80OpCodesDD.ADD_IX_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x2a LD REGISTER,(nnnn)
			case (byte)Z80OpCodesDD.LD_IX_MM_nnnn_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x2b DEC REGISTER
			case (byte)Z80OpCodesDD.DEC_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x2c INC REGISTERL
			case (byte)Z80OpCodesDD.INC_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x2d DEC REGISTERL
			case (byte)Z80OpCodesDD.DEC_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x2e LD REGISTERL,nn
			case (byte)Z80OpCodesDD.LD_IXL_nn:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x34 INC (REGISTER+dd)
			case (byte)Z80OpCodesDD.INC_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x35 DEC (REGISTER+dd)
			case (byte)Z80OpCodesDD.DEC_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x36 LD (REGISTER+dd),nn
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_nn:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x39 ADD REGISTER,SP
			case (byte)Z80OpCodesDD.ADD_IX_SP:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x44 LD B,REGISTERH
			case (byte)Z80OpCodesDD.LD_B_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x45 LD B,REGISTERL
			case (byte)Z80OpCodesDD.LD_B_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x46 LD B,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_B_MM_IX_PLUS_dd_MM:
			Regs.SetB_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x4c LD C,REGISTERH
			case (byte)Z80OpCodesDD.LD_C_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x4d LD C,REGISTERL
			case (byte)Z80OpCodesDD.LD_C_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x4e LD C,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_C_MM_IX_PLUS_dd_MM:
			Regs.SetC_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x54 LD D,REGISTERH
			case (byte)Z80OpCodesDD.LD_D_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x55 LD D,REGISTERL
			case (byte)Z80OpCodesDD.LD_D_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x56 LD D,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_D_MM_IX_PLUS_dd_MM:
			Regs.SetD_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x5c LD E,REGISTERH
			case (byte)Z80OpCodesDD.LD_E_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x5d LD E,REGISTERL
			case (byte)Z80OpCodesDD.LD_E_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x5e LD E,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_E_MM_IX_PLUS_dd_MM:
			Regs.SetE_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x60 LD REGISTERH,B
			case (byte)Z80OpCodesDD.LD_IXH_B:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x61 LD REGISTERH,C
			case (byte)Z80OpCodesDD.LD_IXH_C:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x62 LD REGISTERH,D
			case (byte)Z80OpCodesDD.LD_IXH_D:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x63 LD REGISTERH,E
			case (byte)Z80OpCodesDD.LD_IXH_E:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x64 LD REGISTERH,REGISTERH
			case (byte)Z80OpCodesDD.LD_IXH_IXH:
			break;
			// 0x65 LD REGISTERH,REGISTERL
			case (byte)Z80OpCodesDD.LD_IXH_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x66 LD H,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_H_MM_IX_PLUS_dd_MM:
			Regs.SetH_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x67 LD REGISTERH,A
			case (byte)Z80OpCodesDD.LD_IXH_A:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x68 LD REGISTERL,B
			case (byte)Z80OpCodesDD.LD_IXL_B:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x69 LD REGISTERL,C
			case (byte)Z80OpCodesDD.LD_IXL_C:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x6a LD REGISTERL,D
			case (byte)Z80OpCodesDD.LD_IXL_D:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x6b LD REGISTERL,E
			case (byte)Z80OpCodesDD.LD_IXL_E:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x6c LD REGISTERL,REGISTERH
			case (byte)Z80OpCodesDD.LD_IXL_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x6d LD REGISTERL,REGISTERL
			case (byte)Z80OpCodesDD.LD_IXL_IXL:
			break;
			// 0x6e LD L,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_L_MM_IX_PLUS_dd_MM:
			Regs.SetL_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x6f LD REGISTERL,A
			case (byte)Z80OpCodesDD.LD_IXL_A:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x70 LD (REGISTER+dd),B
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_B:
			LD_M_IX_PLUS_D_M_B();
			break;
			// 0x71 LD (REGISTER+dd),C
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_C:
			LD_M_IX_PLUS_D_M_C();
			break;
			// 0x72 LD (REGISTER+dd),D
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_D:
			LD_M_IX_PLUS_D_M_D();
			break;
			// 0x73 LD (REGISTER+dd),E
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_E:
			LD_M_IX_PLUS_D_M_E();
			break;
			// 0x74 LD (REGISTER+dd),H
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_H:
			LD_M_IX_PLUS_D_M_H();
			break;
			// 0x75 LD (REGISTER+dd),L
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_L:
			LD_M_IX_PLUS_D_M_L();
			break;
			// 0x77 LD (REGISTER+dd),A
			case (byte)Z80OpCodesDD.LD_MM_IX_PLUS_dd_MM_A:
			LD_M_IX_PLUS_D_M_A();
			break;
			// 0x7c LD A,REGISTERH
			case (byte)Z80OpCodesDD.LD_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x7d LD A,REGISTERL
			case (byte)Z80OpCodesDD.LD_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x7e LD A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.LD_A_MM_IX_PLUS_dd_MM:
			Regs.SetA_n(Read_M_IX_PLUS_D_M());
			break;
			// 0x84 ADD A,REGISTERH
			case (byte)Z80OpCodesDD.ADD_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x85 ADD A,REGISTERL
			case (byte)Z80OpCodesDD.ADD_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x86 ADD A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.ADD_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x8c ADC A,REGISTERH
			case (byte)Z80OpCodesDD.ADC_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x8d ADC A,REGISTERL
			case (byte)Z80OpCodesDD.ADC_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x8e ADC A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.ADC_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x94 SUB A,REGISTERH
			case (byte)Z80OpCodesDD.SUB_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x95 SUB A,REGISTERL
			case (byte)Z80OpCodesDD.SUB_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x96 SUB A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.SUB_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x9c SBC A,REGISTERH
			case (byte)Z80OpCodesDD.SBC_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x9d SBC A,REGISTERL
			case (byte)Z80OpCodesDD.SBC_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0x9e SBC A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.SBC_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xa4 AND A,REGISTERH
			case (byte)Z80OpCodesDD.AND_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xa5 AND A,REGISTERL
			case (byte)Z80OpCodesDD.AND_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xa6 AND A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.AND_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xac XOR A,REGISTERH
			case (byte)Z80OpCodesDD.XOR_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xad XOR A,REGISTERL
			case (byte)Z80OpCodesDD.XOR_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xae XOR A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.XOR_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xb4 OR A,REGISTERH
			case (byte)Z80OpCodesDD.OR_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xb5 OR A,REGISTERL
			case (byte)Z80OpCodesDD.OR_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xb6 OR A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.OR_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xbc CP A,REGISTERH
			case (byte)Z80OpCodesDD.CP_A_IXH:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xbd CP A,REGISTERL
			case (byte)Z80OpCodesDD.CP_A_IXL:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xbe CP A,(REGISTER+dd)
			case (byte)Z80OpCodesDD.CP_A_MM_IX_PLUS_dd_MM:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xcb shift DDFDCB
			case (byte)Z80OpCodesDD.shift_DDFDCB:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xe1 POP REGISTER
			case (byte)Z80OpCodesDD.POP_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xe3 EX (SP),REGISTER
			case (byte)Z80OpCodesDD.EX_MM_SP_MM_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xe5 PUSH REGISTER
			case (byte)Z80OpCodesDD.PUSH_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xe9 JP REGISTER
			case (byte)Z80OpCodesDD.JP_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;
			// 0xf9 LD SP,REGISTER
			case (byte)Z80OpCodesDD.LD_SP_IX:
			// not implement
			#if Z80_OPCODES_TEST
			instrNotImp=true;
			#endif
			break;

            default:
                //Nop();
                ExecOpCode(opcode);
                break;
        }
    }
}
