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

public unsafe partial class Z80Cpu : Cpu<byte, Z80Pins, Z80Regs>
{
    public Z80Cpu(IMemoryBuffer<byte> buffer, IMemory<byte>? memory = null) : base(buffer ?? new MemoryBuffer8Bit(), 3, 1, 3, memory) { }

#if Z80_OPCODES_TEST
private bool instrNotImp=false;
#endif

    public override void Instrfetch()
    {
        var opcode = Memory.ReadOpCode(Tick, Regs.GetPCAndInc());

        Regs.RefreshR();

        ExecOpCode(opcode);
    }

    public void Nop() { }

    // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    ~Z80Cpu()
    {
        // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        Dispose(disposing: false);
    }
}