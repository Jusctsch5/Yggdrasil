﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Yggdrasil.FileTypes;

namespace Yggdrasil.TableParsers
{
    [ParserUsage("ItemCompound.tbb", 0)]
    public class ItemCompoundData : BaseParser
    {
        ushort itemNumber;
        public ushort ItemNumber
        {
            get { return itemNumber; }
            set { base.SetProperty(ref itemNumber, value, () => this.ItemNumber); }
        }

        ushort itemCompound1;
        public ushort ItemCompound1
        {
            get { return itemCompound1; }
            set { base.SetProperty(ref itemCompound1, value, () => this.ItemCompound1); }
        }

        ushort itemCompound2;
        public ushort ItemCompound2
        {
            get { return itemCompound2; }
            set { base.SetProperty(ref itemCompound2, value, () => this.ItemCompound2); }
        }

        ushort itemCompound3;
        public ushort ItemCompound3
        {
            get { return itemCompound3; }
            set { base.SetProperty(ref itemCompound3, value, () => this.ItemCompound3); }
        }

        ushort unknown1;
        public ushort Unknown1
        {
            get { return unknown1; }
            set { base.SetProperty(ref unknown1, value, () => this.Unknown1); }
        }

        ushort unknown2;
        public ushort Unknown2
        {
            get { return unknown2; }
            set { base.SetProperty(ref unknown2, value, () => this.Unknown2); }
        }

        byte itemCount1;
        public byte ItemCount1
        {
            get { return itemCount1; }
            set { base.SetProperty(ref itemCount1, value, () => this.ItemCount1); }
        }

        byte itemCount2;
        public byte ItemCount2
        {
            get { return itemCount2; }
            set { base.SetProperty(ref itemCount2, value, () => this.ItemCount2); }
        }

        byte itemCount3;
        public byte ItemCount3
        {
            get { return itemCount3; }
            set { base.SetProperty(ref itemCount3, value, () => this.ItemCount3); }
        }

        byte unknown3;
        public byte Unknown3
        {
            get { return unknown3; }
            set { base.SetProperty(ref unknown3, value, () => this.Unknown3); }
        }

        byte unknown4;
        public byte Unknown4
        {
            get { return unknown4; }
            set { base.SetProperty(ref unknown4, value, () => this.Unknown4); }
        }

        byte unknown5;
        public byte Unknown5
        {
            get { return unknown5; }
            set { base.SetProperty(ref unknown5, value, () => this.Unknown5); }
        }

        public ItemCompoundData(GameDataManager game, TBB.TBL1 table, byte[] data, PropertyChangedEventHandler propertyChanged = null) : base(game, table, data, propertyChanged) { OnLoad(); }

        protected override void OnLoad()
        {
            itemNumber = BitConverter.ToUInt16(RawData, 0);
            itemCompound1 = BitConverter.ToUInt16(RawData, 2);
            itemCompound2 = BitConverter.ToUInt16(RawData, 4);
            itemCompound3 = BitConverter.ToUInt16(RawData, 6);
            unknown1 = BitConverter.ToUInt16(RawData, 8);
            unknown2 = BitConverter.ToUInt16(RawData, 10);
            itemCount1 = RawData[12];
            itemCount2 = RawData[13];
            itemCount3 = RawData[14];
            unknown3 = RawData[15];
            unknown4 = RawData[16];
            Unknown4 = RawData[17];

            base.OnLoad();
        }
    }
}
