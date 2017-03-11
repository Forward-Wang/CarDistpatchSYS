using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraEditors.Repository;
using QuickFrame.UI.Common.Search;

namespace DS.MSClient.UICommon
{
    ///<summary> 
    ///ģ���ţ� 
    ///���ã�����Grid��ѯ����
    ///���ߣ�phq
    ///��д���ڣ�2015-6-9
    ///</summary> 
    public partial class FormSearchCondition : FormBase
    {
        /// <summary>
        /// 
        /// </summary>
        public FormSearchCondition()
        {
            InitializeComponent();
        }

        #region ����
  

        #endregion

        public  DevExpress.XtraGrid.Views.Grid.GridView gv_current = null;
        /// <summary>
        /// ��ѯ���������б�
        /// </summary>
        public List<Condition> CondtionList = new List<Condition>();

        /// <summary>
        /// ����������ѯҳ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormSearchCondition_Load(object sender, EventArgs e)
        {
            try
            {
                if (gv_current != null)
                {
                    this.BindConditionGrid();
                }
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// ȷ����ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.CondtionList.Clear();
                for (int i = 0; i < this.dt_MyDataSet.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dt_MyDataSet.Rows[i]["Choose"]))
                    {
                        SearchValueType t = new SearchValueType();
                        t = SearchValueType.String;
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(Decimal).Name)
                        {
                            t = SearchValueType.Number;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(String).Name)
                        {
                            t = SearchValueType.String;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(DateTime).Name)
                        {
                            t = SearchValueType.Date;
                        }
                        if (dt_MyDataSet.Rows[i]["Type"].ToString() == typeof(Object).Name)
                        {
                            t = SearchValueType.String;
                        }
                        Condition cond = new Condition(dt_MyDataSet.Rows[i]["ColumnFiledName"].ToString(),
                                                      dt_MyDataSet.Rows[i]["ColumnName"].ToString(),
                                                      dt_MyDataSet.Rows[i]["ValueDisplay"].ToString(), t); 
                           
                        cond.Operator = ToSqlString(dt_MyDataSet.Rows[i]["Operater"].ToString());
                        CondtionList.Add(cond);
                    }
                }
                 
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// �����ĵķ���ת��Ϊsqlstring
        /// </summary>
        /// <param name="oldstring">��string</param>
        /// <returns>��string </returns>
        private string ToSqlString(string oldstring)
        {
            switch (oldstring)
            {
                case "����":
                    return "=";
                case "���Ƶ���":
                    return "Like";
                case "����":
                    return ">";
                case "С��":
                    return "<";
                case "���ڵ���":
                    return ">=";
                case "С�ڵ���":
                    return "<=";
                case "������":
                    return "<>";
                default:
                    return "=";
            }
        }

        /// <summary>
        /// ��ѯ���
        /// </summary>
        private void BindConditionGrid()
        {
            this.dt_MyDataSet.Rows.Clear();
            for (int i = 0; i < gv_current.Columns.Count; i++)
            {
                if (gv_current.Columns[i].UnboundType != DevExpress.Data.UnboundColumnType.Bound)
                {
                    DataRow dr = this.dt_MyDataSet.NewRow();
                    dr["Choose"] = false;
                    dr["ValueDisplay"] = "";
                    dr["TextDisplay"] = "";
                    dr["Type"] = gv_current.Columns[i].UnboundType.ToString();
                    dr["Operater"] = "����";
                 
                    dr["ColumnName"] = gv_current.Columns[i].Caption;
                    dr["ColumnFiledName"] = gv_current.Columns[i].FieldName;
                    if (dr["ColumnName"] != null && dr["ColumnName"].ToString() != "") 
                    {
                        if (dr["ColumnName"].ToString().Contains("���") )
                        {
                            dr["Operater"] = "���Ƶ���";
                        }
                    }

                    if (gv_current.Columns[i].Tag != null)
                    {
                        if (gv_current.Columns[i].Tag.ToString() == "Pickstatus")
                        {
                            dr["ButtonEdit"] = gv_current.Columns[i].Tag.ToString();
                        }
                        else
                        {
                            dr["ButtonEdit"] = gv_current.Columns[i].Tag.ToString();
                        }
                    }
                    if (dr["Type"].ToString() == typeof(DateTime).Name)
                    {
                            dr["Operater"] = "���ڵ���";
                            DataRow dr1 = this.dt_MyDataSet.NewRow();
                            dr1["Choose"] = false;
                            dr1["ValueDisplay"] = "";
                            dr1["TextDisplay"] = "";
                            dr1["Type"] = gv_current.Columns[i].UnboundType.ToString();
                            dr1["Operater"] = "С�ڵ���";
                            dr1["ColumnName"] = gv_current.Columns[i].Caption;
                            dr1["ColumnFiledName"] = gv_current.Columns[i].FieldName;
                            dt_MyDataSet.Rows.Add(dr);
                            dt_MyDataSet.Rows.Add(dr1);
                        
                    }
                    else if (dr["Type"].ToString() == typeof(Object).Name)
                    {
                        dr["ButtonEdit"] = gv_current.Columns[i].FieldName;
                        dt_MyDataSet.Rows.Add(dr);
                    }
                    else
                    {
                        dt_MyDataSet.Rows.Add(dr);
                    }
                }
                              
            }
            this.gc_Condition.RefreshDataSource();
        }

        /// <summary>
        /// ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_LoadGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.FocusedRowHandle)];
                string type = dr["Type"].ToString();
                this.comb_Operater.Items.Clear();
                if (dr["Type"].ToString() == typeof(Decimal).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "����",
                        "����",
                        "С��",
                        "���ڵ���",
                        "С�ڵ���",
                        "������"
                    });
                    gridCol_Value.ColumnEdit = null;
                }
                else if (dr["Type"].ToString() == typeof(String).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "����",
                        "���Ƶ���",
                        "����",
                        "С��",
                        "���ڵ���",
                        "С�ڵ���",
                        "������"
                    });
                    gridCol_Value.ColumnEdit = null;
                }
                else if (dr["Type"].ToString() == typeof(DateTime).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "����",
                        "����",
                        "С��",
                        "���ڵ���",
                        "С�ڵ���",
                        "������"
                    });
                     
                    gridCol_Value.ColumnEdit = this.dateEdit_Value;
                    
                 
                }
                else if (dr["Type"].ToString() == typeof(Object).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "����"
                    });
                    string fieldName = dr["ButtonEdit"].ToString();
                    gridCol_Value.ColumnEdit =gv_current.Columns[fieldName].ColumnEdit;
                }
                else if (dr["Type"].ToString() == typeof(Boolean).Name)
                {
                    this.comb_Operater.Items.AddRange(new object[]
                    {
                        "����"
                    });
                    gridCol_Value.ColumnEdit = comb_TrueOrFalse;
                }
                if (dr["ButtonEdit"].ToString() != "" && dr["Type"].ToString() != typeof(Object).Name)
                {
                    gridCol_Value.ColumnEdit = this.btnEdit_Value;
                }
                string temp = dr["ButtonEdit"].ToString();
                //����ֵΪ:����������
                if (dr["ButtonEdit"].ToString() == "VehicleType")
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_VehicleType;
                }
                else if (dr["ButtonEdit"].ToString() == "DutyType")//�����װ࣬���
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_DutyType;
                }
                else if (dr["ButtonEdit"].ToString() == "NJDutyType")//����������
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_NJDutyType;
                }
                else if (dr["ButtonEdit"].ToString() == "IsCreatedByPDA")//�Ƿ�pda������ "�ֹ���","PDAˢ����", "PDA�ֹ�¼��"
                {
                    this.gridCol_Value.ColumnEdit = repositoryItemComboBox_IsCreatedByPDA;
                }
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// ��ѯ��ť�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Value_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (this.gv_Condition.FocusedRowHandle >= 0)
                {
                   
                    DataRow dr = dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()];

                     // ����Ƕ����ѯ��
                   if (dr["ButtonEdit"].ToString().Contains("Driver"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Driver);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//��������ѯ���ͣ�������׺
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Driver bc = (Driver)form.SearchObject;
                       //    dr["TextDisplay"] = bc.DriverName;
                       //    dr["ValueDisplay"] = bc.DriverID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   // ����Ƕ����ѯ��
                   else if (dr["ButtonEdit"].ToString().Contains( "Vehicle"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Vehicle);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//��������ѯ���ͣ�������׺
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Vehicle bc = (Vehicle)form.SearchObject;
                       //    dr["TextDisplay"] = bc.VehicleNO;
                       //    dr["ValueDisplay"] = bc.VehicleID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString() == "Employee")
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Employee); 
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Employee bc = (Employee)form.SearchObject;
                       //    dr["TextDisplay"] = bc.EmployeeName;
                       //    dr["ValueDisplay"] = bc.EmployeeID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains ("ConstructionSite"))
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(ConstructionSite);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//��������ѯ���ͣ�������׺
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    ConstructionSite bc = (ConstructionSite)form.SearchObject;
                       //    dr["TextDisplay"] = bc.ConstructionName;
                       //    dr["ValueDisplay"] = bc.ConstructionSiteID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString() == "Project")
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Project);
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Project bc = (Project)form.SearchObject;
                       //    dr["TextDisplay"] = bc.ProjectName;
                       //    dr["ValueDisplay"] = bc.ProjectID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains("DataDictionary"))//�ֵ����
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(DataDictionary);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//��������ѯ���ͣ�������׺
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    DataDictionary bc = (DataDictionary)form.SearchObject;
                       //    dr["TextDisplay"] = bc.DataDictionaryName;
                       //    dr["ValueDisplay"] = bc.DataDictionaryID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   }
                   else if (dr["ButtonEdit"].ToString().Contains("Customer"))//�ͻ����׷���λ���������
                   {
                       //FormSearching form = new FormSearching();
                       //form.SearchType = typeof(Customer);
                       //form.SearchType_Suffix = dr["ButtonEdit"].ToString();//��������ѯ���ͣ�������׺
                       //if (form.ShowDialog(this) == DialogResult.OK)
                       //{
                       //    Customer bc = (Customer)form.SearchObject;
                       //    dr["TextDisplay"] = bc.CustomerName;
                       //    dr["ValueDisplay"] = bc.CustomerID;

                       //    dt_MyDataSet.Rows[gv_Condition.GetFocusedDataSourceRowIndex()]["Choose"] = true;//��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                       //}
                   } 
                }
                this.gc_Condition.RefreshDataSource();
                this.gv_Condition.RefreshRow(this.gv_Condition.GetFocusedDataSourceRowIndex());
            }
            catch (Exception ee)
            {
               // Program.MsgBoxError(ee);
            }
        }

        /// <summary>
        /// �޸�ֵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gv_Condition_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "TextDisplay") 
                {
                    string temp = e.Value.ToString();
                    if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(DateTime).Name)
                    {

                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = Convert.ToDateTime(e.Value);
                    }
                    else
                    {
                        if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "VehicleType" ||//�Զ���������ֵ���Ҫ���� 
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "DutyType" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "NJDutyType" ||
                             dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ButtonEdit"].ToString() == "IsCreatedByPDA" ||
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(Object).Name)
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = e.Value;
                        }
                    }
                    if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(Boolean).Name)
                    {
                        if (e.Value.ToString() == "��")
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = "True";  
                        }
                        else
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = "False"; 
                        }
                    }

                    if (e.Value != null && e.Value.ToString() != "")
                    {
                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Choose"] = true;// ��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                    }
                    else
                    {
                        dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Choose"] = false;// ��ѯ���У����ֵ���붫������ô���������Ĭ��ѡ�С���Ҫ�û���ȥ��ѡǰ��Ĺ�����
                    }
                }
                if (e.Value.ToString().Trim() != "")
                {

                    if (e.Column.FieldName == "Choose" && (bool)e.Value)
                    {
                        if (dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["Type"].ToString() == typeof(DateTime).Name)
                        {
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["TextDisplay"] = DateTime.Now.Date.ToString("yyyy-MM-dd");
                            dt_MyDataSet.Rows[gv_Condition.GetDataSourceRowIndex(e.RowHandle)]["ValueDisplay"] = DateTime.Now.Date.ToString("yyyy-MM-dd");                 
 
                        }
                    }
                    
                }
            }
            catch
            {
               // ignored
            }        


        }
    }
}