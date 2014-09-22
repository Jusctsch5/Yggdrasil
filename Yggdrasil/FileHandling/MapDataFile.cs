﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Yggdrasil.Attributes;
using Yggdrasil.FileHandling.MapDataHandling;

namespace Yggdrasil.FileHandling
{
    [MagicNumber("YGMD")]
    public class MapDataFile : BaseFile
    {
        public MapDataFile(GameDataManager gameDataManager, string path) : base(gameDataManager, path) { }

        public const int MapWidth = 35;
        public const int MapHeight = 30;

        public enum TileTypes : byte
        {
            Nothing = 0x0,
            Floor = 0x1,
            Wall = 0x2,
            StairsUp = 0x3,
            StairsDown = 0x4,
            OneWayShortcutN = 0x5,
            OneWayShortcutS = 0x6,
            OneWayShortcutW = 0x7,
            OneWayShortcutE = 0x8,
            DoorNS = 0x9,
            DoorWE = 0xA,
            TreasureChest = 0xB,
            GeomagneticField = 0xC,
            SandConveyorN = 0xD,
            SandConveyorS = 0xE,
            SandConveyorW = 0xF,
            SandConveyorE = 0x10,
            FOEFloor = 0x11, /* not sure, but seems FOE-related */
            CollapsingFloor = 0x12,
            Water = 0x13,
            Elevator = 0x14,
            RefreshingWater = 0x15,
            WarpEntrance = 0x16,
            WaterLily = 0x17,
            DamagingFloor = 0x18,
            Unknown0x19 = 0x19,
        };

        public static System.Collections.Hashtable IsTileWalkable = new System.Collections.Hashtable()
        {
            /* Maybe not "walkable" as such - treasure chest, etc. -, but at least for the sake of wall drawing... */
            { TileTypes.Nothing, false },
            { TileTypes.Floor, true },
            { TileTypes.Wall, false },
            { TileTypes.StairsUp, true },
            { TileTypes.StairsDown, true },
            { TileTypes.OneWayShortcutN, false },
            { TileTypes.OneWayShortcutS, false },
            { TileTypes.OneWayShortcutW, false },
            { TileTypes.OneWayShortcutE, false },
            { TileTypes.DoorNS, true },
            { TileTypes.DoorWE, true },
            { TileTypes.TreasureChest, true },
            { TileTypes.GeomagneticField, true },
            { TileTypes.SandConveyorN, true },
            { TileTypes.SandConveyorS, true },
            { TileTypes.SandConveyorW, true },
            { TileTypes.SandConveyorE, true },
            { TileTypes.FOEFloor, true },  
            { TileTypes.CollapsingFloor, true },
            { TileTypes.Water, false },
            { TileTypes.Elevator, true },
            { TileTypes.RefreshingWater, true },
            { TileTypes.WarpEntrance, true },
            { TileTypes.WaterLily, false },     
            { TileTypes.DamagingFloor, true },
            { TileTypes.Unknown0x19, false },
        };

        public int FloorNumber { get { return int.Parse(System.Text.RegularExpressions.Regex.Match(Path.GetFileNameWithoutExtension(this.Filename), @"\d+").Value); } }
        public string FloorName { get { return string.Format("B{0}F", FloorNumber); } }

        public string FileSignature { get; private set; }
        public uint Unknown1 { get; private set; }
        public uint Unknown2 { get; private set; }
        public uint Unknown3 { get; private set; }
        public BaseTile[,] Tiles { get; private set; }

        public override void Parse()
        {
            FileSignature = Encoding.ASCII.GetString(Stream.ToArray(), 0, 4);

            string magic = this.GetAttribute<MagicNumber>().Magic;
            if (FileSignature != magic) throw new Exception(string.Format("Invalid file signature, got '{0}' expected '{1}'", FileSignature, magic));

            BinaryReader reader = new BinaryReader(Stream);

            reader.BaseStream.Seek(4, SeekOrigin.Begin);
            Unknown1 = reader.ReadUInt32();
            Unknown2 = reader.ReadUInt32();
            Unknown3 = reader.ReadUInt32();

            Tiles = new BaseTile[MapWidth, MapHeight];

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    int offset = (int)Stream.Position;
                    TileTypes typeId = (TileTypes)reader.ReadByte();
                    switch (typeId)
                    {
                        case TileTypes.Floor:
                        case TileTypes.FOEFloor:
                        case TileTypes.DamagingFloor:
                        case TileTypes.CollapsingFloor:
                            Tiles[x, y] = new FloorTile(GameDataManager, this, offset);
                            break;
                        /*case TileTypes.StairsUp:
                        case TileTypes.StairsDown:
                            Tiles[x, y] = new Stairs(data, ofs);
                            break;
                        case TileTypes.TreasureChest:
                            Tiles[x, y] = new TreasureChest(data, ofs);
                            break;
                        case TileTypes.WaterLily:
                            Tiles[x, y] = new WaterLily(data, ofs);
                            break;*/
                        default:
                            Tiles[x, y] = new BaseTile(GameDataManager, this, offset);
                            break;
                    }
                }
            }
        }
    }
}
