﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

using Yggdrasil.FileTypes;

namespace Yggdrasil.TableParsers
{
    public class BaseParser : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [Browsable(false)]
        public GameDataManager Game { get; private set; }
        [Browsable(false)]
        public TBB.TBL1 ParentTable { get; private set; }
        [Browsable(false)]
        public int EntryNumber { get; private set; }
        [Browsable(false)]
        public bool HasChanged { get; private set; }

        [Browsable(false)]
        public virtual string EntryDescription { get; private set; }

        public BaseParser(GameDataManager game, TBB.TBL1 table, int entryNumber, PropertyChangedEventHandler propertyChanged = null)
        {
            Game = game;
            ParentTable = table;
            EntryNumber = entryNumber;

            HasChanged = false;

            EntryDescription = string.Format("Entry #{0}", entryNumber);

            PropertyChanged = propertyChanged;
        }

        public void SetProperty<T>(ref T field, T value, Expression<Func<T>> member)
        {
            if (member == null) throw new NullReferenceException("member must not be null.");

            MemberExpression memberExpression = (member.Body as MemberExpression);
            if (memberExpression == null) throw new InvalidOperationException("member.Body must be a MemberExpression");

            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                this.HasChanged = true;

                var handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
            }
        }

        protected virtual void Load()
        {
            HasChanged = false;
        }

        public virtual void Save()
        {
            HasChanged = false;
        }
    }
}