﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Yggdrasil.FileHandling;
using Yggdrasil.FileHandling.TableHandling;
using Yggdrasil.Attributes;

namespace Yggdrasil.TableParsing
{
	public abstract class BaseItemParser : BaseParser
	{
		string name;
		[DisplayName("(Name)"), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("In-game item name.")]
		[CausesNodeUpdate(true)]
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value, () => Name); }
		}
		public bool ShouldSerializeName() { return !(Name == (dynamic)originalValues["Name"]); }
		public void ResetName() { Name = (dynamic)originalValues["Name"]; }

		string description;
		[DisplayName("(Description)"), Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("In-game item description.")]
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value, () => Description); }
		}
		public bool ShouldSerializeDescription() { return !(Description == (dynamic)originalValues["Description"]); }
		public void ResetDescription() { Description = (dynamic)originalValues["Description"]; }

		ushort itemNumber;
		[DisplayName("(ID)"), ReadOnly(true), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("Internal ID number of item.")]
		public ushort ItemNumber
		{
			get { return itemNumber; }
			set { SetProperty(ref itemNumber, value, () => ItemNumber); }
		}

		public BaseItemParser(GameDataManager gameDataManager, DataTable table, int entryNumber, PropertyChangedEventHandler propertyChanged = null) :
			base(gameDataManager, table, entryNumber, propertyChanged)
		{ Load(); }

		protected override void Load()
		{
			itemNumber = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 0);

			name = GameDataManager.ItemNames[ItemNumber];
			description = GameDataManager.ItemDescriptions[ItemNumber];

			base.Load();
		}

		public override void Save()
		{
			itemNumber.CopyTo(ParentTable.Data[EntryNumber], 0);

			base.Save();
		}
	}
}
