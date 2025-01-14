﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZXE.Core.Infrastructure.Interfaces;
using ZXE.Core.System;
using ZXE.Core.Z80;

namespace ZXE.Common.DebugHelpers;

public class FileTracer : IDisposable, ITracer
{
    private readonly FileStream _file;

    public FileTracer()
    {
        if (File.Exists("trace.log"))
        {
            File.Delete("trace.log");

        }

        _file = File.OpenWrite("trace.log");
    }

    public void TraceBefore(Instruction instruction, byte[] data, State state, Ram ram)
    {
        Trace(instruction, data, state, ram, true);
    }

    public void TraceAfter(Instruction instruction, byte[] data, State state, Ram ram)
    {
        Trace(instruction, data, state, ram, false);
    }

    public List<string> GetTrace()
    {
        throw new NotImplementedException();
    }

    public void ClearTrace()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        _file.Close();

        _file.Dispose();
    }

    private void Trace(Instruction instruction, byte[] data, State state, Ram ram, bool showMnemonic)
    {
        var builder = new StringBuilder();

        if (showMnemonic)
        {
            builder.Append($"{instruction.Mnemonic,-15}");
        }
        else
        {
            builder.Append("               ");
        }

        for (var i = 0; i < 7; i++)
        {
            if (i < data.Length)
            {
                builder.Append($"{data[i]:X2} ");
            }
            else
            {
                builder.Append("   ");
            }
        }

        builder.Append($"BANKS: {ram.BankNumbers[0]}{ram.BankNumbers[1]}{ram.BankNumbers[2]}{ram.BankNumbers[3]} ");

        builder.Append($"SCR: {ram.Screen} ");

        builder.Append($"ROM: {ram.Rom} ");

        builder.Append($"IM: {(int) state.InterruptMode} ");

        builder.Append("INT: ");

        switch (state.InterruptType)
        {
            case InterruptType.Maskable:
                builder.Append("MSK ");

                break;

            case InterruptType.NonMaskable:
                builder.Append("NMI ");

                break;
            default:
                builder.Append("--- ");

                break;
        }

        builder.Append($"PC: {state.ProgramCounter:X4} ");

        builder.Append($"SP: {state.StackPointer:X4} ");

        builder.Append($"AF: {state.Registers.ReadPair(Register.AF):X4} ");

        builder.Append($"BC: {state.Registers.ReadPair(Register.BC):X4} ");

        builder.Append($"DE: {state.Registers.ReadPair(Register.DE):X4} ");

        builder.Append($"HL: {state.Registers.ReadPair(Register.HL):X4} ");

        builder.Append($"IX: {state.Registers.ReadPair(Register.IX):X4} ");

        builder.Append($"IY: {state.Registers.ReadPair(Register.IY):X4} ");

        builder.Append($"I: {state.Registers[Register.I]:X2} ");

        builder.Append($"R: {state.Registers[Register.R]:X2} ");

        builder.Append($"AF': {state.Registers.ReadPair(Register.AF_):X4} ");

        builder.Append($"BC': {state.Registers.ReadPair(Register.BC_):X4} ");

        builder.Append($"DE': {state.Registers.ReadPair(Register.DE_):X4} ");

        builder.Append($"HL': {state.Registers.ReadPair(Register.HL_):X4} ");

        builder.Append(Environment.NewLine);

        _file.Write(Encoding.UTF8.GetBytes(builder.ToString()));

        _file.Flush();    
    }
}