﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DS.MSClient.UICommon;
using DS.MSClient.UICommon.CommonForm;
using DevExpress.XtraEditors.Repository;
using DS.MSClient.UIControl;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UIControl
{
    [ToolboxItem(true)]
    public class CLookChargeItem : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;
			//Properties.Buttons.Clear();
			//Properties.Buttons.AddRange(new[]
			//{
			//	new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
			//	new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false}
			//});
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
					new LookUpColumnInfo("ChargeItemName", "收费名称")
				});
            }
            Properties.CharacterCasing = CharacterCasing.Upper;
            Properties.NullText = string.Empty;
            Properties.NullValuePrompt = string.Empty;
            Properties.NullValuePromptShowForEmptyValue = true;
            Properties.PopupSizeable = true;
            Properties.ShowFooter = true;
            Properties.ShowHeader = true;
            Refresh(true);
        }

        #region 属性

        public List<ChargeItem> ListIsValid { get; set; }
        public ChargeItem Currentduty { get; set; }
        private int _ChargeTypeID { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(_ChargeTypeID,false);
        }
        protected override void OnNewButtonClick()
        {
            //FormDuty form = new FormDuty();
            //form.FormClosed += (s, e) =>
            //{
            //    BindList(false);
            //};
            //form.Show();
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(int ChargeTypeID, bool getFromCache = true)
        {
            if(ChargeTypeID!=-1)
            {
                _ChargeTypeID = ChargeTypeID;
                ListIsValid = (List<ChargeItem>)ClientCache.GetUpdate("ChargeItem", () => new ChargeItemDAO().GetListByChargeTypeID(_ChargeTypeID));
            }
            else
            {
                ListIsValid = (List<ChargeItem>)ClientCache.GetUpdate("ChargeItem", () => new ChargeItemDAO().GetList());
            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "ChargeItemName";
            Properties.ValueMember = "ChargeItemID";
            Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            Properties.SearchMode = SearchMode.AutoFilter;
            Properties.CaseSensitiveSearch = true;
            Properties.AutoSearchColumnIndex = 2;
        }

        /// <summary>
        ///     值改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cLookUp_EditValueChanged(object sender, EventArgs e)
        {
            if (ListIsValid == null) return;
             Currentduty = EditValue == null
                    ? null
                    : ListIsValid.Find(model => model.ChargeItemID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
