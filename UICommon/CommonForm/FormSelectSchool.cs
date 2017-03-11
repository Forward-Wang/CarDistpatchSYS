﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DS.MSClient.UICommon.MessageBox;
using DS.MSClient.UICommon;
using DS.MSClient;
using DS.Model;
using DS.Data;

namespace DS.MSClient.UICommon
{
    public partial class FormSelectSchool : FormBase
    {
        #region 初始化
        public FormSelectSchool()
        {
            InitializeComponent();
            InitEvent();
        }
        private void InitEvent()
        {
            //加载数据
            this.Load += FormSelectDeparment_Load;
            this.Btn_Ok.Click += Btn_Ok_Click;
            this.Btn_Cancel.Click += Btn_Cancel_Click;
        }



        #endregion

        #region 属性
        public int ParentID = 0;
        private List<Department> _list = null;
        public Department _department = null;
        public Department Data = null;
        #endregion

        #region 方法
        private void BindData()
        {
            _list = new DepartmentDAO().GetList();
        }


        #endregion

        #region 事件

        private void FormSelectDeparment_Load(object sender, EventArgs e)
        {
             if (ThreadExcute(BindData))
             {
                 if(_list!=null)
                 {
                     this.trl_Left.RowHeight = 20;
                     this.trl_Left.Padding = new Padding(3, 4, 2, 2);
                     this.trl_Left.CustomDrawNodeImages += treeList_CustomDrawNodeImages;
                     this.trl_Left.DataSource = this._list;


                     this.trl_Left.KeyFieldName = "DepartmentID";
                     this.trl_Left.ParentFieldName = "ParentDepartmentID";
                     this.trl_Left.ExpandToLevel(0);
                     this.trl_Left.OptionsBehavior.Editable = false;
                     this.trl_Left.MoveFirst();

                 }
             }
        }
        /// <summary>
        /// 确定按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Ok_Click(object sender, EventArgs e)
        {
            _department = (Department)this.trl_Left.GetDataRecordByNode(this.trl_Left.FocusedNode);
            if (_department != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MsgBox.ShowWarn("请选中数据");
                return;
            }
        }
        /// <summary>
        /// 取消按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void treeList_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            e.SelectImageIndex = 20;
        }
        #endregion

    }
}