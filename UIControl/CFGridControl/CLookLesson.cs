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
using DS.MSClient.UIModule;

namespace DS.MSClient.UIControl
{
     [ToolboxItem(true)]
    public partial class CLookLesson : CSmartLookUpEditBase
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            EditValueChanged += cLookUp_EditValueChanged;
            Properties.Buttons.Clear();
            Properties.Buttons.AddRange(new[]
			{
				new EditorButton(ButtonPredefines.Combo) {IsDefaultButton = true},
				new EditorButton(ButtonPredefines.Redo, "刷新") {IsDefaultButton = false},
                new EditorButton(ButtonPredefines.Plus, "新增") {IsDefaultButton = false}
			});
            if (Properties.Columns.Count == 0)
            {
                Properties.Columns.AddRange(new[]
				{
				//	new LookUpColumnInfo("SchoolCode", "学校编号"),
                    new LookUpColumnInfo("LessonName", "培训课程"),
                    new LookUpColumnInfo("Note", "备注")
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

        public List<Lesson> ListIsValid { get; set; }
        public Lesson Currentschool { get; set; }

        #endregion

        #region Method

        protected override void OnRefreshButtonClick()
        {
            BindList(false);
        }
        protected override void OnNewButtonClick()
        {
            FormLesson form = new FormLesson();
            form.FormClosed += (s, e) =>
            {
                BindList(false);
            };
            form.Show();
        }

        #region 绑定下拉框

        /// <summary>
        ///     绑定下拉控件数据集
        /// </summary>
        public void BindList(bool getFromCache = true)
        {
            if (getFromCache)
            {
                ListIsValid = (List<Lesson>)ClientCache.GetAuto("Lesson", () => new LessonDao().GetList());
            }
            else
            {
                ListIsValid = (List<Lesson>)ClientCache.GetUpdate("Lesson", () => new LessonDao().GetList());
            }
            Properties.DataSource = ListIsValid;
            Properties.DisplayMember = "LessonName";
            Properties.ValueMember = "LessonID";
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
            Currentschool = EditValue == null
                   ? null
                   : ListIsValid.Find(model => model.LessonID == Convert.ToInt32(EditValue));
        }

        #endregion

        #endregion
    }
}
