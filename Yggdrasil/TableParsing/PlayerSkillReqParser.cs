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
	[PrioritizedCategory("Player Skills", 2)]
	[ParserDescriptor("Class2Skill.tbb", 0, "Skill Requirements", 1)]
	public class PlayerSkillReqParser : BaseParser
	{
		string name;
		[DisplayName("(Name)"), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("In-game skill name.")]
		[CausesNodeUpdate(true)]
		public string Name
		{
			get { return name; }
			set { SetProperty(ref name, value, () => Name); }
		}
		public bool ShouldSerializeName() { return !(Name == (dynamic)originalValues["Name"]); }
		public void ResetName() { Name = (dynamic)originalValues["Name"]; }

		string shortDescription;
		[DisplayName("(Short Description)"), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("In-game short skill description.")]
		public string ShortDescription
		{
			get { return shortDescription; }
			set { SetProperty(ref shortDescription, value, () => ShortDescription); }
		}
		public bool ShouldSerializeShortDescription() { return !(ShortDescription == (dynamic)originalValues["ShortDescription"]); }
		public void ResetShortDescription() { ShortDescription = (dynamic)originalValues["ShortDescription"]; }

		string description;
		[DisplayName("(Description)"), Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor)), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("In-game skill description.")]
		public string Description
		{
			get { return description; }
			set { SetProperty(ref description, value, () => Description); }
		}
		public bool ShouldSerializeDescription() { return !(Description == (dynamic)originalValues["Description"]); }
		public void ResetDescription() { Description = (dynamic)originalValues["Description"]; }

		ushort skillNumber;
		[DisplayName("(ID)"), ReadOnly(true), PrioritizedCategory("Information", byte.MaxValue)]
		[Description("Internal ID number of skill.")]
		public ushort SkillNumber
		{
			get { return skillNumber; }
			set { SetProperty(ref skillNumber, value, () => SkillNumber); }
		}

		[Browsable(false)]
		public override string EntryDescription { get { return Name; } }

		ushort unknown1;
		[DisplayName("Unknown 1"), TypeConverter(typeof(TypeConverters.HexUshortConverter)), PrioritizedCategory("Unknown", 0)]
		public ushort Unknown1
		{
			get { return unknown1; }
			set { SetProperty(ref unknown1, value, () => Unknown1); }
		}
		public bool ShouldSerializeUnknown1() { return !(Unknown1 == (dynamic)originalValues["Unknown1"]); }
		public void ResetUnknown1() { Unknown1 = (dynamic)originalValues["Unknown1"]; }

		ushort requiredSkill1;
		[DisplayName("Required Skill"), TypeConverter(typeof(TypeConverters.PlayerSkillNameConverter)), PrioritizedCategory("1st Requirement", 2)]
		public ushort RequiredSkill1
		{
			get { return requiredSkill1; }
			set { SetProperty(ref requiredSkill1, value, () => RequiredSkill1); }
		}
		public bool ShouldSerializeRequiredSkill1() { return !(RequiredSkill1 == (dynamic)originalValues["RequiredSkill1"]); }
		public void ResetRequiredSkill1() { RequiredSkill1 = (dynamic)originalValues["RequiredSkill1"]; }

		ushort requiredSkillLevel1;
		[DisplayName("Skill Level"), PrioritizedCategory("1st Requirement", 2)]
		public ushort RequiredSkillLevel1
		{
			get { return requiredSkillLevel1; }
			set { SetProperty(ref requiredSkillLevel1, value, () => RequiredSkillLevel1); }
		}
		public bool ShouldSerializeRequiredSkillLevel1() { return !(RequiredSkillLevel1 == (dynamic)originalValues["RequiredSkillLevel1"]); }
		public void ResetRequiredSkillLevel1() { RequiredSkillLevel1 = (dynamic)originalValues["RequiredSkillLevel1"]; }

		ushort requiredSkill2;
		[DisplayName("Required Skill"), TypeConverter(typeof(TypeConverters.PlayerSkillNameConverter)), PrioritizedCategory("2nd Requirement", 1)]
		public ushort RequiredSkill2
		{
			get { return requiredSkill2; }
			set { SetProperty(ref requiredSkill2, value, () => RequiredSkill2); }
		}
		public bool ShouldSerializeRequiredSkill2() { return !(RequiredSkill2 == (dynamic)originalValues["RequiredSkill2"]); }
		public void ResetRequiredSkill2() { RequiredSkill2 = (dynamic)originalValues["RequiredSkill2"]; }

		ushort requiredSkillLevel2;
		[DisplayName("Skill Level"), PrioritizedCategory("2nd Requirement", 1)]
		public ushort RequiredSkillLevel2
		{
			get { return requiredSkillLevel2; }
			set { SetProperty(ref requiredSkillLevel2, value, () => RequiredSkillLevel2); }
		}
		public bool ShouldSerializeRequiredSkillLevel2() { return !(RequiredSkillLevel2 == (dynamic)originalValues["RequiredSkillLevel2"]); }
		public void ResetRequiredSkillLevel2() { RequiredSkillLevel2 = (dynamic)originalValues["RequiredSkillLevel2"]; }

		public PlayerSkillReqParser(GameDataManager gameDataManager, DataTable table, int entryNumber, PropertyChangedEventHandler propertyChanged = null) :
			base(gameDataManager, table, entryNumber, propertyChanged)
		{ Load(); }

		protected override void Load()
		{
			skillNumber = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 0);

			name = GameDataManager.PlayerSkillNames[SkillNumber];
			shortDescription = GameDataManager.PlayerSkillShortDescriptions[SkillNumber];
			description = GameDataManager.PlayerSkillDescriptions[SkillNumber];

			unknown1 = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 2);
			requiredSkill1 = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 4);
			requiredSkillLevel1 = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 6);
			requiredSkill2 = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 8);
			requiredSkillLevel2 = BitConverter.ToUInt16(ParentTable.Data[EntryNumber], 10);

			base.Load();
		}

		public override void Save()
		{
			skillNumber.CopyTo(ParentTable.Data[EntryNumber], 0);

			unknown1.CopyTo(ParentTable.Data[EntryNumber], 2);
			requiredSkill1.CopyTo(ParentTable.Data[EntryNumber], 4);
			requiredSkillLevel1.CopyTo(ParentTable.Data[EntryNumber], 6);
			requiredSkill2.CopyTo(ParentTable.Data[EntryNumber], 8);
			requiredSkillLevel2.CopyTo(ParentTable.Data[EntryNumber], 10);

			base.Save();
		}
	}
}
