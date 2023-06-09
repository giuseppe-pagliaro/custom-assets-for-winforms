﻿using CustomAssetsCommons;

namespace CustomItemManagers
{
    public partial class FieldsForm : Form
    {
        public FieldsForm()
        {
            InitializeComponent();

            this.style = new();
        }

        private ItemDatas? itemDatas;
        private Style style;

        #region Properties

        public ItemDatas ItemDatas
        {
            get
            {
                if (itemDatas is null)
                {
                    return new ItemDatas();
                }

                return itemDatas.Clone();
            }
            set
            {
                this.itemDatas = value;
                this.Populate();
            }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;
                this.ApplyStyle();
            }
        }

        #endregion

        protected virtual void Populate()
        {
            if (itemDatas is null)
            {
                this.Text = "(Item ID is Null)";
            }
            else
            {
                this.Text = this.itemDatas.ClassNameToString() + " #" + this.itemDatas.Id.ToString();
            }
        }

        protected virtual void ApplyStyle()
        {
            Style.Apply(this, style, BgType.Primary);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (this == obj)
            {
                return true;
            }

            if (!obj.GetType().IsSubclassOf(typeof(FieldsForm)))
            {
                return false;
            }

            FieldsForm other = (FieldsForm)obj;

            return other.ItemDatas.Equals(ItemDatas) && other.GetType() == GetType();
        }

        public override int GetHashCode()
        {
            int prime = 31, result = 1;

            result = prime * result + GetType().GetHashCode();
            result = prime * result + ItemDatas.GetHashCode();

            return result;
        }
    }
}