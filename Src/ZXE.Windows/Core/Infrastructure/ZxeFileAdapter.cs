﻿using System.IO;
using System.Text.Json;
using ZXE.Core.Infrastructure.Models;
using ZXE.Core.System;
using ZXE.Core.Z80;

namespace ZXE.Core.Infrastructure;

public class ZxeFileAdapter
{
    private readonly State _state;

    private readonly Ram _ram;

    public ZxeFileAdapter(State state, Ram ram)
    {
        _state = state;

        _ram = ram;
    }

    public string? Load(string filename)
    {
        var json = File.ReadAllText(filename);

        var model = JsonSerializer.Deserialize<ZxeFile>(json);

        if (model == null)
        {
            return null;
        }

        _state.Halted = model.State.Halted;

        _state.InterruptFlipFlop1 = model.State.InterruptFlipFlop1;

        _state.InterruptFlipFlop2 = model.State.InterruptFlipFlop2;

        _state.InterruptMode = model.State.InterruptMode;

        _state.MemPtr = model.State.MemPtr;

        _state.OpcodePrefix = model.State.OpcodePrefix;

        _state.ProgramCounter = model.State.ProgramCounter;

        _state.Q = model.State.Q;

        _state.StackPointer = model.State.StackPointer;

        _state.Registers.WritePair(Register.AF, model.Registers["AF"]);
        _state.Registers.WritePair(Register.BC, model.Registers["BC"]);
        _state.Registers.WritePair(Register.DE, model.Registers["DE"]);
        _state.Registers.WritePair(Register.HL, model.Registers["HL"]);

        _state.Flags = Flags.FromByte(_state.Registers[Register.F]);

        _state.Registers.WritePair(Register.AF_, model.Registers["AF'"]);
        _state.Registers.WritePair(Register.BC_, model.Registers["BC'"]);
        _state.Registers.WritePair(Register.DE_, model.Registers["DE'"]);
        _state.Registers.WritePair(Register.HL_, model.Registers["HL'"]);

        _state.Registers.WritePair(Register.IX, model.Registers["IX"]);
        _state.Registers.WritePair(Register.IY, model.Registers["IY"]);

        _state.Registers[Register.I] = (byte) ((model.Registers["IR"] & 0xFF00) >> 8);
        _state.Registers[Register.R] = (byte) (model.Registers["IR"] & 0x00FF);

        for (var i = 0; i < 8; i++)
        {
            _ram.LoadIntoPage(i, model.RamBanks[i]);
        }
        
        for (var i = 0; i < 4; i++)
        {
            _ram.SetBankBySlotNumber(i, model.PageConfiguration[i]);
        }

        _ram.LoadRom(model.Rom!, model.RomNumber, true);

        _state.Last7ffd = model.Last7Ffd;

        _state.Last1ffd = model.Last1Ffd;

        return model.RomTitle;
    }

    public void Save(string filename, string romTitle, Model model)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filename)!);

        var data = new ZxeFile
                   {
                       State = _state,
                       RomTitle = romTitle
                   };

        data.Model = model;

        data.Registers.Add("AF", _state.Registers.ReadPair(Register.AF));
        data.Registers.Add("BC", _state.Registers.ReadPair(Register.BC));
        data.Registers.Add("DE", _state.Registers.ReadPair(Register.DE));
        data.Registers.Add("HL", _state.Registers.ReadPair(Register.HL));

        data.Registers.Add("AF'", _state.Registers.ReadPair(Register.AF_));
        data.Registers.Add("BC'", _state.Registers.ReadPair(Register.BC_));
        data.Registers.Add("DE'", _state.Registers.ReadPair(Register.DE_));
        data.Registers.Add("HL'", _state.Registers.ReadPair(Register.HL_));

        data.Registers.Add("IX", _state.Registers.ReadPair(Register.IX));
        data.Registers.Add("IY", _state.Registers.ReadPair(Register.IY));

        data.Registers.Add("IR", (ushort) ((_state.Registers[Register.I] << 8)| _state.Registers[Register.R]));

        for (var i = 0; i < 8; i++)
        {
            data.RamBanks.Add(i, _ram.ReadBank(i));
        }

        for (var i = 0; i < 4; i++)
        {
            data.PageConfiguration.Add(i, _ram.BankNumbers[i]);
        }

        data.Rom = _ram.ReadBank(8);

        data.RomNumber = _ram.Rom;

        data.Last7Ffd = _state.Last7ffd;

        data.Last1Ffd = _state.Last1ffd;

        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
                                                  {
                                                      WriteIndented = true
                                                  });

        File.WriteAllText(filename, json);
    }
}