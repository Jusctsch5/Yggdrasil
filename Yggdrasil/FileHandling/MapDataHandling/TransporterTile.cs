﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.ComponentModel;

namespace Yggdrasil.FileHandling.MapDataHandling
{
    class TransporterTile : BaseTile
    {
        public TransporterTile(GameDataManager gameDataManager, MapDataFile mapDataFile, int offset, System.Drawing.Point coordinates, PropertyChangedEventHandler propertyChanged = null) :
            base(gameDataManager, mapDataFile, offset, coordinates, propertyChanged) { }

        byte destinationFloor;
        [TypeConverter(typeof(TypeConverters.FloorNumberConverter))]
        public byte DestinationFloor
        {
            get { return destinationFloor; }
            set { base.SetProperty(ref destinationFloor, value, () => this.DestinationFloor); }
        }
        public bool ShouldSerializeDestinationFloor() { return !(this.DestinationFloor == (dynamic)base.originalValues["DestinationFloor"]); }
        public void ResetDestinationFloor() { this.DestinationFloor = (dynamic)base.originalValues["DestinationFloor"]; }

        Point destinationCoords;
        public Point DestinationCoords
        {
            get { return destinationCoords; }
            set { base.SetProperty(ref destinationCoords, value, () => this.DestinationCoords); }
        }
        public bool ShouldSerializeDestinationCoords() { return !(this.DestinationCoords == (dynamic)base.originalValues["DestinationCoords"]); }
        public void ResetDestinationCoords() { this.DestinationCoords = (dynamic)base.originalValues["DestinationCoords"]; }

        protected override void Load()
        {
            destinationFloor = this.Data[8];
            destinationCoords = new Point(this.Data[9], this.Data[10]);

            base.Load();
        }

        public override void Save()
        {
            destinationFloor.CopyTo(this.Data, 8);
            destinationCoords.X.CopyTo(this.Data, 9);
            destinationCoords.Y.CopyTo(this.Data, 10);

            base.Save();
        }
    }
}
